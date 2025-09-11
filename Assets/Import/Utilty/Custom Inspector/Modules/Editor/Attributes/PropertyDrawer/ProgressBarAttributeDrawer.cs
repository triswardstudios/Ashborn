using CustomInspector.Extensions;
using CustomInspector.Helpers.Editor;
using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;


namespace CustomInspector.Editor
{
    [CustomPropertyDrawer(typeof(ProgressBarAttribute))]
    public class ProgressBarAttributeDrawer : PropertyDrawer
    {
        //these guistyles cannot be readonly, because GUI.skin.label is only initialized during gui-calls
        static GUIStyle MinLabelStyle => new(GUI.skin.label) { fontSize = 10, alignment = TextAnchor.UpperLeft };
        static GUIStyle MaxLabelStyle => new(GUI.skin.label) { fontSize = 10, alignment = TextAnchor.UpperRight };

        const float cursorLineWidth = 5;
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            label = PropertyValues.ValidateLabel(label, property);

            PropInfo info = cache.GetInfo(property, attribute, fieldInfo);
            if (info.ErrorMessage != null)
            {
                DrawProperties.DrawPropertyWithMessage(position, label, property, info.ErrorMessage, MessageType.Error);
                return;
            }

            //get infos
            (float min, float max) = info.GetMinMax(property);

            float currentValue = Convert.ToSingle(property.GetValue());

            //draw a button below to force update inspector each time entering the ui element
            if (info.IsInteractible)
                GUI.Button(position, GUIContent.none);

            //Draw bar
            float betweenThresholds = (max != min) ? (currentValue - min) / (max - min) : 1; //range (0,1)
            EditorGUI.ProgressBar(position, betweenThresholds, property.name + $" ({betweenThresholds * 100}%)");

            //Draw start and end
            if (min != 0) //if not obvious
                EditorGUI.LabelField(position, min.ToString(), MinLabelStyle);
            EditorGUI.LabelField(position, max.ToString(), MaxLabelStyle);

            //interaction
            if (info.IsInteractible)
            {
                Rect widerRect = new(position.x - 10, position.y, position.width + 20, position.height); //some tolerance to easier set maximum and minimum
                if (widerRect.Contains(Event.current.mousePosition))
                {
                    if (Event.current.type == EventType.Used) //its not drag, because of the button below
                    {
                        betweenThresholds = Mathf.Clamp01((Event.current.mousePosition.x - position.x) / position.width);
                        float newValue = min + (max - min) * betweenThresholds;
                        if (property.propertyType == SerializedPropertyType.Integer)
                            property.intValue = (int)(newValue + .5f);
                        else
                            property.floatValue = newValue;

                        property.serializedObject.ApplyModifiedProperties();
                        //EditorWindow.focusedWindow.Repaint(); //display changes
                    }

                    Rect linePosition = new()
                    {
                        x = position.x + position.width * betweenThresholds - (cursorLineWidth / 2f),
                        y = position.y,
                        width = cursorLineWidth,
                        height = position.height,
                    };
                    EditorGUI.DrawRect(linePosition, new Color(1, 1, 1, .5f));
                }
            }
        }
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            PropInfo info = cache.GetInfo(property, attribute, fieldInfo);
            if (info.ErrorMessage != null)
                return DrawProperties.GetPropertyWithMessageHeight(label, property);
            else
                return info.BarHeight;
        }

        readonly static PropInfoCache<PropInfo> cache = new();

        class PropInfo : ICachedPropInfo
        {
            public string ErrorMessage { get; private set; } = null;
            public float BarHeight { get; private set; }
            public Func<SerializedProperty, (float min, float max)> GetMinMax { get; private set; }
            public bool IsInteractible { get; private set; }

            public PropInfo() { }
            public void Initialize(SerializedProperty property, PropertyAttribute attribute, FieldInfo fieldInfo)
            {
                ProgressBarAttribute attr = (ProgressBarAttribute)attribute;

                if (property.propertyType != SerializedPropertyType.Float && property.propertyType != SerializedPropertyType.Integer)
                {
                    ErrorMessage = $"ProgressBar: type '{property.propertyType}' not supported";
                    return;
                }

                BarHeight = GetSize(attr.size);
                IsInteractible = !attr.isReadOnly && fieldInfo.GetCustomAttribute<ReadOnlyAttribute>() == null;

                //define getters
                SerializedProperty maxProp = attr.maxGetter != null ? property.GetOwnerAsFinder().FindPropertyRelative(attr.maxGetter) : null;
                SerializedProperty minProp = attr.minGetter != null ? property.GetOwnerAsFinder().FindPropertyRelative(attr.minGetter) : null;

                if ((attr.maxGetter != null) == (maxProp != null) //check if has a getter, then property should be found
                    && (attr.minGetter != null) == (minProp != null))
                {
                    Func<SerializedProperty, float> getMin;
                    Func<SerializedProperty, float> getMax;

                    //Max
                    if (attr.maxGetter == null)
                        getMax = (prop) => attr.max;
                    else if (maxProp.propertyType == SerializedPropertyType.Float)
                        getMax = (prop) => prop.GetOwnerAsFinder().FindPropertyRelative(attr.maxGetter).floatValue;
                    else if (maxProp.propertyType == SerializedPropertyType.Integer)
                        getMax = (prop) => prop.GetOwnerAsFinder().FindPropertyRelative(attr.maxGetter).intValue;
                    else
                    {
                        ErrorMessage = $"ProgressBar: set maximum: Property {attr.maxGetter} is not a number";
                        return;
                    }
                    //Min
                    if (attr.minGetter == null)
                        getMin = (prop) => attr.min;
                    else if (minProp.propertyType == SerializedPropertyType.Float)
                        getMin = (prop) => prop.GetOwnerAsFinder().FindPropertyRelative(attr.minGetter).floatValue;
                    else if (minProp.propertyType == SerializedPropertyType.Integer)
                        getMin = (prop) => prop.GetOwnerAsFinder().FindPropertyRelative(attr.minGetter).intValue;
                    else
                    {
                        ErrorMessage = $"ProgressBar: set minimum: Property {attr.minGetter} is not a number";
                        return;
                    }

                    GetMinMax = (prop) => (getMin(prop), getMax(prop));
                }
                else //properties were not found, so they are not serializable
                {
                    //Check if existing
                    //Max
                    if (attr.maxGetter != null)
                    {
                        DirtyValue maxValue;
                        try
                        {
                            maxValue = DirtyValue.GetOwner(property).FindRelative(attr.maxGetter);
                        }
                        catch (Exception e)
                        {
                            ErrorMessage = e.Message;
                            return;
                        }
                        //Check type
                        if (!typeof(float).IsAssignableFrom(maxValue.Type))
                        {
                            ErrorMessage = $"ProgressBar: set minimum: Property {attr.maxGetter} is not a number";
                            return;
                        }
                    }
                    //Min
                    if (attr.minGetter != null)
                    {
                        DirtyValue minValue;
                        try
                        {
                            minValue = DirtyValue.GetOwner(property).FindRelative(attr.minGetter);
                        }
                        catch (Exception e)
                        {
                            ErrorMessage = e.Message;
                            return;
                        }
                        //Check type
                        if (!typeof(float).IsAssignableFrom(minValue.Type))
                        {
                            ErrorMessage = $"ProgressBar: set minimum: Property {attr.minGetter} is not a number";
                            return;
                        }
                    }

                    //set functions
                    GetMinMax = (prop) =>
                    {
                        prop.serializedObject.ApplyModifiedProperties();
                        DirtyValue owner = DirtyValue.GetOwner(property);
                        if (attr.maxGetter == null) //only min
                            return ((float)owner.FindRelative(attr.minGetter).GetValue(), attr.max);
                        else if (attr.minGetter == null) //only max
                            return (attr.min, (float)owner.FindRelative(attr.maxGetter).GetValue());
                        else //both
                            return ((float)owner.FindRelative(attr.minGetter).GetValue(), (float)owner.FindRelative(attr.maxGetter).GetValue());
                    };
                }
            }
            float GetSize(Size size)
            {
                return size switch
                {
                    Size.small => EditorGUIUtility.singleLineHeight,
                    Size.medium => 30,
                    Size.big => 40,
                    Size.max => 50,
                    _ => throw new System.NotImplementedException(size.ToString()),
                };
            }
        }
    }
}
