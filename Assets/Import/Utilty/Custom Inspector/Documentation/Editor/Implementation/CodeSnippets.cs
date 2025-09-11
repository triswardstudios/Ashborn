using System;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;
using RangeAttribute = UnityEngine.RangeAttribute;

namespace CustomInspector.Documentation
{
    [System.Serializable]
    public class CodeSnippets
    {
#pragma warning disable IDE0090 // Use 'new(...)'
#pragma warning disable CS0414
#pragma warning disable IDE0052 // Remove unread private members
#pragma warning disable IDE0044 // Add readonly modifier
#pragma warning disable IDE0051 // Remove unused private members
#pragma warning disable IDE0059 // Unnecessary assignment of a value
        /*
            * 
            * Fields:
            * Naming convention: [SerializeField] ClassNameExamples classNameExamples = new();
            * name is same than classname, but first letter is lowercase
            * 
            * Classes:
            * set [System.Serializable]
            * it displays the attribute with the same name as the attribute plus the "Examples" word
            * 
            */


        [SerializeField] AnimatorParameterAttributeExamples animatorParameterAttributeExamples = new AnimatorParameterAttributeExamples();

        [System.Serializable]
        class AnimatorParameterAttributeExamples
        {
            [ForceFill]
            public UnityEditor.Animations.AnimatorController animatorController;
            public Animator animator;

            [HorizontalLine]

            [AnimatorParameter(nameof(animatorController))]
            public string paramName2;

            [AnimatorParameter(nameof(animator))]
            public string paramName;
        }

        [SerializeField] ArrayContainerExamples arrayContainerExamples = new ArrayContainerExamples();

        [System.Serializable]
        class ArrayContainerExamples
        {
            [MessageBox("New label and ShowIf and is applied to the whole array." +
                        "\nArray is shown if 'visible' is ticked.", MessageBoxType.Info)]

            public bool visible = true;

            [LabelSettings("New Label"),
            ShowIf(nameof(visible))]
            [ArrayContainer]
            public ArrayContainer<int> myArray;

            [HorizontalLine]
            [MessageBox("New labels and MinAttribute are applied to all elements." +
                        "\nAll elements of the array are positive.", MessageBoxType.Info)]
            [SerializeField, HideField] bool _;

            [LabelSettings("New Label"),
            Min(0)]
            public List<int> myPositiveNumbers
                = new() { 1, 2, 3 };

            private void Start()
            {
                // Types can be easily converted:
                ArrayContainer<int> numbers = Array.CreateInstance(typeof(int), 5);
                int[] ints = numbers;
            }
        }

        [SerializeField] AsButtonAttributeExamples asButtonAttributeExamples = new AsButtonAttributeExamples();

        [System.Serializable]
        class AsButtonAttributeExamples
        {
            [AsButton]
            public bool selectableBoolean;

            [Space2(10)]

            [ShowMethod(nameof(GetSelectableBoolean))]

            [Space2(20)]

            [AsButton(staysPressed: false)]
            public bool holdDownBoolean;

            [Space2(10)]

            [ShowMethod(nameof(GetHoldDownBoolean))]

            [Space2(20)]

            [AsButton]
            public int myInteger;

            [Space2(10)]

            [ShowMethod(nameof(GetInteger))]

            [Space2(20)]

            [AsButton]
            public InspectorButtonState buttonState;

            [Space2(10)]

            [ShowMethod(nameof(GetButtonState))]

            [Space2(20)]

            [AsButton(selectedColor = FixedColor.CherryRed,
                      size = Size.small,
                      label = "My String Button",
                      tooltip = "Some Tooltip")]
            public string myString;

            [Space2(10)]

            [ShowMethod(nameof(GetString))]

            [HideField] public bool _;
            bool GetSelectableBoolean() => selectableBoolean;
            bool GetHoldDownBoolean() => holdDownBoolean;
            int GetInteger() => myInteger;
            InspectorButtonState GetButtonState() => buttonState;
            string GetString() => myString;
        }

        [SerializeField] AsRangeAttributeExamples asRangeAttributeExamples = new AsRangeAttributeExamples();

        [System.Serializable]
        class AsRangeAttributeExamples
        {
            [Header("Ranges")]
            [AsRange(0, 10)]
            public Vector2 positiveRange
                = Vector2.up * 3.1415927f;

            [AsRange(10, 0)]
            public Vector2 negativeRange
                = new(1, 5);
        }

        [SerializeField] AssetsOnlyAttributeExamples assetsOnlyAttributeExamples = new AssetsOnlyAttributeExamples();

        [System.Serializable]
        class AssetsOnlyAttributeExamples
        {
            [Header("Assets")]
            [AssetsOnly] public GameObject gob1;
            [AssetsOnly] public GameObject gob2;

            [AssetsOnly] public Transform chest;
            [AssetsOnly] public Transform leg;

            [AssetsOnly] public Camera cam;
        }

        [SerializeField] BackgroundColorAttributeExamples backgroundColorAttributeExamples = new BackgroundColorAttributeExamples();

        [System.Serializable]
        class BackgroundColorAttributeExamples
        {
            [BackgroundColor(FixedColor.Gray), ReadOnly(DisableStyle.OnlyText, LabelStyle.NoLabel)]
            public string info1 = "Really Important";

            [Space(20)]

            [BackgroundColor]
            public int myNumber;

            [Space2(20)]
            [BackgroundColor(FixedColor.CherryRed)]
            [Title("Important", upperSpacing = 2,
                                alignment = TextAlignment.Center,
                                fontSize = 15)]
            public int yourNumber;

            [Title("My GameObject")]
            [BackgroundColor(FixedColor.DustyBlue)]
            public GameObject gob;
        }

        [SerializeField] ButtonAttributeExamples buttonAttributeExamples = new ButtonAttributeExamples();

        [System.Serializable]
        class ButtonAttributeExamples
        {
            [HorizontalLine("Default Method")]

            [Button(nameof(LogHelloWorld),
                tooltip = "This will log 'Hello World' in the console")]

            [Button(nameof(LogHelloWorld),
                label = "Hello World",
                size = Size.small)]

            [HideField]
            public bool _bool;

            void LogHelloWorld()
            {
                Debug.Log("Hello World");
            }

            [HorizontalLine("Method with parameter")]

            [MessageBox("Please change the following number.", MessageBoxType.Info)]
            [Button(nameof(LogNumber), true)]
            public int _number;

            void LogNumber(int n)
            {
                Debug.Log(n.ToString());
            }
        }

        [SerializeField] ColorPaletteAttributeExamples colorPaletteAttributeExamples = new ColorPaletteAttributeExamples();

        [System.Serializable]
        class ColorPaletteAttributeExamples
        {
            [MessageBox("Click on the colors", MessageBoxType.Info)]

            [ColorPalette]
            public Color myImageColor1;

            [ColorPalette(hideFoldout = true)]
            public Color myImageColor2;

            [HorizontalLine("")]

            [ColorPalette("Alternative Scheme")]
            public Color alternativeColor1;

            [LabelSettings(LabelStyle.NoLabel),
                ColorPalette("Alternative Scheme")]
            public Color alternativeColor2;
        }


        [SerializeField] CopyPasteAttributeExamples copyPasteAttributeExamples = new CopyPasteAttributeExamples();

        [System.Serializable]
        class CopyPasteAttributeExamples
        {
            [CopyPaste]
            public Vector3 v1
                = Vector3.forward;
            [CopyPaste]
            public Vector3 v2
                = Vector3.one;

            [CopyPaste]
            public Color c1
                = Color.white;
            [CopyPaste]
            public Color c2
                = new(.5f, .4f, .2f, 1);

            [CopyPaste] public string _string = "Hello World!";

            [ShowMethod(nameof(GetCurrentClipboard))]
            [SerializeField, HideField] bool b;

            string GetCurrentClipboard()
                => GUIUtility.systemCopyBuffer;
        }


        [SerializeField] DecimalsAttributeExamples decimalsAttributeExamples = new DecimalsAttributeExamples();

        [System.Serializable]
        class DecimalsAttributeExamples
        {
            [Decimals(1)]
            public float oneDecimal = 0.1f;
            [Decimals(2)]
            public float twoDecimal = 0.02f;

            [HorizontalLine]

            [Decimals(-1)]
            public float onlyTens = 20;
            [Decimals(-2)]
            public int onlyHundreds = 300;
        }

        [SerializeField] Delayed2AttributeExamples delayed2AttributeExamples = new Delayed2AttributeExamples();

        [System.Serializable]
        class Delayed2AttributeExamples
        {
            [Delayed2]
            public string delayed = "Edit Here";

            public string instant = "Edit Here";


            [ShowMethod(nameof(GetDelayedOne))]
            [ShowMethod(nameof(GetInstantOne))]

            [HideField]
            public bool b2;

            string GetDelayedOne()
                => delayed;
            string GetInstantOne()
                => instant;
        }


        [SerializeField] DisplayAutoPropertyAttributeExamples displayAutoPropertyAttributeExamples = new DisplayAutoPropertyAttributeExamples();

        [System.Serializable]
        class DisplayAutoPropertyAttributeExamples
        {
            [field: Title("Field")]
            [field: SerializeField, Min2(0)]
            public int Foo
            { get; private set; } = 45;

            [ShowProperty("<Foo>k__BackingField")]

            [HideField]
            public bool _;

#pragma warning disable CS0618 // Type or member is obsolete
            public int Bar
            { private get; set; } = 45;

            [MessageBox("Enter play-mode to change unserialized auto-property", MessageBoxType.Info)]
            [DisplayAutoProperty(nameof(Bar))]

            [HideField]
            public bool __;
#pragma warning restore CS0618 // Type or member is obsolete
        }

        [SerializeField] FixedValuesAttributeExamples fixedValuesAttributeExamples = new FixedValuesAttributeExamples();

        [System.Serializable]
        class FixedValuesAttributeExamples
        {
            [FixedValues(1, 7, 15)]
            public int integer;

            [FixedValues("Bob", "John", "Martin")]
            public string name;
        }

        [SerializeField] FoldoutAttributeExamples foldoutAttributeExamples = new FoldoutAttributeExamples();

        [System.Serializable]
        class FoldoutAttributeExamples
        {
            [HorizontalLine("ScriptableObject")]

            [MessageBox("Please fill the 'scriptable1'-value and then click the foldout to edit its values.", MessageBoxType.Info)]
            [Foldout]
            public ScriptableObject scriptable1;

            [MessageBox("This is the default display.", MessageBoxType.Info)]
            public ScriptableObject scriptable2;

            [HorizontalLine("Other References")]

            [Foldout]
            public MonoBehaviour anyMonoBehaviour;
        }

        [SerializeField] ForceFillAttributeExamples forceFillAttributeExamples = new ForceFillAttributeExamples();

        [System.Serializable]
        class ForceFillAttributeExamples
        {
            [ForceFill]
            public GameObject gob1;

            [ForceFill(errorMessage = "No Animation without GameObject possible!!")]
            public GameObject gob2;

            [ForceFill, SerializeField]
            string s2 = "Make this String Empty.";

            [ForceFill("<undefined>",
                       "empty", "Empty",
                       "undefined")]
            public string s3 = "<undefined>";

            [HorizontalLine("others")]

            [ForceFill("(0, 0, 0)"), SerializeField]
            Vector3 c = new Vector3(0, 0, 0);

            [ForceFill(null)] public GameObject gob3;

            [ForceFill("-1"), SerializeField]
            float f = -1;

            [HorizontalLine("only check if playing")] //test it by starting your game and then look back on this editorwindow
                                                      //or only check if playing (because it would get filled)
            [ForceFill(onlyTestInPlayMode = true)] public GameObject gob = null;

            void Start()
            {
                // this.CheckForceFilled();
                // gob1 = GameObject.FindObjectOfType<GameObject>();
            }
        }

        [SerializeField] FromChildrenAttributeExamples fromChildrenAttributeExamples = new FromChildrenAttributeExamples();

        [System.Serializable]
        class FromChildrenAttributeExamples
        {
            [MessageBox("Only references to my children", MessageBoxType.Info)]
            [Space2(20)]

            [SerializeField, FromChildren]
            MyMonoBehaviour _childs;

            [Space2(20)]

            [SerializeField, FromChildren(allowNull = true)]
            MyMonoBehaviour _childs2;

            public class MyMonoBehaviour : MonoBehaviour
            {

            }
        }

        [SerializeField] GetSetAttributeExamples getSetAttributeExamples = new GetSetAttributeExamples();

        [System.Serializable]
        class GetSetAttributeExamples
        {
            [MessageBox("Replace your property with a getter and a setter" +
                        "\n(this Vector2 was a Vector3 before)", MessageBoxType.Info)]

            [GetSet(nameof(FlattenVector), nameof(ExtendVector))]
            public Vector3 v1;

            Vector2 FlattenVector(Vector3 v) => new Vector2(v.x, v.y);
            Vector3 ExtendVector(Vector2 v) => new Vector3(v.x, v.y, 1);

            [HorizontalLine]

            [MessageBox("Add a field through a getter and a setter", MessageBoxType.Info)]

            [GetSet(nameof(GetTuple), nameof(SetTuple))]
            public string myString = "Hello World!";
            [ReadOnly] public float a;
            [ReadOnly] public float b;

            Vector2 GetTuple()
            {
                return new Vector2(a, b);
            }
            void SetTuple(Vector2 v)
            {
                a = v.x;
                b = v.y;
            }
        }

        [SerializeField] GUIColorAttributeExamples gUIColorAttributeExamples = new GUIColorAttributeExamples();

        [System.Serializable]
        class GUIColorAttributeExamples
        {
            [Title("Integers")]
            public int a;
            public int b;

            [GUIColor(FixedColor.Cyan)]
            [Title("My colors")]
            [GUIColor]
            public string s1 = "Hello World!";
            [GUIColor(FixedColor.Red, colorWholeUI: false)]
            public string s2 = "Hello World!";
            [GUIColor(FixedColor.Orange)]
            public string s3 = "Hello World!";
            [GUIColor(FixedColor.Yellow)]
            public string s4 = "Hello World!";
            [GUIColor(FixedColor.Green)]
            public string s5 = "Hello World!";
            [GUIColor(FixedColor.BabyBlue)]
            public string s6 = "Hello World!";
            [GUIColor(FixedColor.Magenta)]
            public string s7 = "Hello World!";

            public int c, d;
        }

        [SerializeField] HideFieldAttributeExamples hideFieldAttributeExamples = new HideFieldAttributeExamples();

        [System.Serializable]
        class HideFieldAttributeExamples
        {
            [MessageBox("[HideField] still shows all other attributes", MessageBoxType.Info)]
            [HideField] public bool _;

            // attributes are visible
            [Title("This title is still shown")]
            [HideField]
            public bool a1;
            public bool a2;

            [MessageBox("[HideInInspector] hides everything", MessageBoxType.Info)]
            [HideField] public bool __;

            // attributes are hidden
            [Title("This title is hidden")]
            [HideInInspector]
            public bool b1;
            public bool b2;
        }

        [SerializeField] HookAttributeExamples hookAttributeExamples = new HookAttributeExamples();

        [System.Serializable]
        class HookAttributeExamples
        {
            [HorizontalLine("With parameters")]

            [Title("Logs previous and new value in console")]
            [MessageBox("Change this value and look into the console", MessageBoxType.Info)]
            [Hook(nameof(LogInput))]
            public float value = 0;

            void LogInput(float oldValue, float newValue)
            {
                Debug.Log($"Changed from {oldValue} to {newValue}");
            }

            [HorizontalLine("Without parameters")]

            [MessageBox("Change this value and look into the console", MessageBoxType.Info)]
            [Hook(nameof(LogHelloWorld))]
            public float value2 = 0;

            void LogHelloWorld()
            {
                Debug.Log($"Hello World!");
            }
        }

        [SerializeField] HorizontalGroupAttributeExamples horizontalGroupAttributeExamples = new HorizontalGroupAttributeExamples();

        [System.Serializable]
        class HorizontalGroupAttributeExamples
        {
            [SerializeField, HorizontalGroup(true)]
            SceneInfos offlineScene;
            [SerializeField, HorizontalGroup]
            SceneInfos onlineScene;


            [HorizontalLine(2.5f, FixedColor.Gray, 30)]


            [MessageBox("Combine with other attributes", MessageBoxType.Info)]

            [HorizontalGroup(true, size = 4)]
            public string test = "Combine with a button";

            [HorizontalGroup(size = 1),
            Button(nameof(Func), size = Size.small),
            HideField]
            public int b;
            void Func() { Debug.Log("Button pressed!"); }



            [HorizontalLine(2.5f, FixedColor.Gray, 30)]



            [HorizontalGroup(true),
            LabelSettings(LabelStyle.NoLabel)]
            public string hisName = "James";

            [HorizontalGroup,
            LabelSettings(LabelStyle.NoLabel)]
            public string hisName2 = "Robert";

            [HorizontalGroup,
            LabelSettings(LabelStyle.NoLabel)]
            public string hisName3 = "Smith";

            [HorizontalGroup(true),
            LabelSettings(LabelStyle.NoLabel)]
            public string herName = "Jennifer";

            [HorizontalGroup,
            LabelSettings(LabelStyle.NoLabel)]
            public string herName2 = "Susan";

            [HorizontalGroup,
            LabelSettings(LabelStyle.NoLabel)]
            public string herName3 = "Miller";


            [System.Serializable]
            class SceneInfos
            {
                [ForceFill] public string name = "Start Scene";
                [Title("Some Info")]
                [Min(0)] public int loadingTime = 5;
                public GameObject prefab = null;

                [HorizontalGroup(true), LabelSettings(LabelStyle.NoLabel)]
                public string foo = "Hello";
                [HorizontalGroup, LabelSettings(LabelStyle.NoLabel)]
                public string bar = "World";
            }
        }

        [SerializeField] HorizontalLineAttributeExamples horizontalLineAttributeExamples = new HorizontalLineAttributeExamples();

        [System.Serializable]
        class HorizontalLineAttributeExamples
        {
            [HorizontalLine("Booleans", 2)]
            public bool myBool1 = true;
            public bool myBool2 = true;
            public bool myBool3 = true;
            public bool myBool4 = true;

            [HorizontalLine("Numbers")]

            public int myInt = -1;
            public float myFloat = -1;

            [HorizontalLine]

            public string myString = "<empty>";
            public string myString2 = "<empty>";

            [Space2(20)]
            [HorizontalLine(1, FixedColor.Yellow, 0)]
            [HorizontalLine(1, FixedColor.Green, 2)]

            public string myString3 = "Two Lines";

            [HorizontalLine("My Important Property",
                                2, FixedColor.Red)]

            public GameObject myGameObject = null;
        }


        [SerializeField] IndentAttributeExamples indentAttributeExamples = new IndentAttributeExamples();

        [System.Serializable]
        class IndentAttributeExamples
        {
            public int i1;
            [Indent(1)] public int i2;
            [Indent(2)] public int i3;
            public int i4;

            [HorizontalLine]

            public MyClass _class;

            public int i7;

            [System.Serializable]
            public class MyClass
            {
                public int i5;
                [Indent(-1)] public int i6;
            }
        }

        [SerializeField] InspectorIconAttributeExamples inspectorIconAttributeExamples = new InspectorIconAttributeExamples();

        [System.Serializable]
        class InspectorIconAttributeExamples
        {
            [InspectorIcon(InspectorIcon.Camera)]
            public string camName = "Bobs cam";

            [InspectorIcon(InspectorIcon.Favorite, true)]
            public string favorite = "Look right! (the star) ->";

            [InspectorIcon(InspectorIcon.Light), InspectorIcon(InspectorIcon.Eye)]
            public string lightName = "LED";
        }

        [SerializeField] LabelSettingsAttributeExamples labelSettingsAttributeExamples = new LabelSettingsAttributeExamples();

        [System.Serializable]
        class LabelSettingsAttributeExamples
        {
            [LabelSettings("My < new - Label :)")]
            public int a;

            [Title("Short names?")]
            [LabelSettings(LabelStyle.NoSpacing)]
            public string _short = "Tired of too big label space??";

            [Title("You want an empty label?")]
            public string message = "John";

            [LabelSettings(LabelStyle.EmptyLabel)]
            public string message2 = "Smith";

            [Title("You want no label?")]
            [LabelSettings(LabelStyle.NoLabel)]
            public string longString = "My very long string";
        }

        [SerializeField] LayerAttributeExamples layerAttributeExamples = new LayerAttributeExamples();

        [System.Serializable]
        class LayerAttributeExamples
        {
            [Title("Any Layer:")]

            [Layer] public int layer;

            [Title("Specific Layers:")]

            [Layer("Default")]
            public int layer1;

            [Layer("TransparentFX")]
            public int layer2;
        }

        [SerializeField] MaskAttributeExamples maskAttributeExamples = new MaskAttributeExamples();

        [System.Serializable]
        class MaskAttributeExamples
        {
            [MessageBox("Here are the first 5 bits of the integer (represented as booleans)", MessageBoxType.Info)]
            [Mask(5)] public int myInt = 5;

            [Space2(10)]

            [MessageBox("Select multiple enum values at once.", MessageBoxType.Info)]
            [Mask] public RigidbodyConstraints rc;

            [Space2(10)]

            [Mask]
            public Ability ability
                   = Ability.Look | Ability.Hear;
            public enum Ability
            {
                Look = 1 << 0,
                Hear = 1 << 1,
                Walk = 1 << 2,
                HearAndWalk = Hear | Walk,
            }

            void Start()
            {
                bool thirdBool
                    = (myInt & (1 << 3)) != 0;
            }

            [Space2(10)]
            //--- a deeper example showing how to work with the values

            //The value
            [Mask(" x ", " y ", " z ")] public int FreezePosition = 0;
            //enum definition
            public enum PositionConstraints
            {
                None = 0,
                FreezeX = 1 << 0,
                FreezeY = 1 << 1,
                FreezeZ = 1 << 2,
                FreezeAll = FreezeX | FreezeY | FreezeZ
            }
            //You can read/write the value the enum
            public PositionConstraints positionConstraints
            {
                get => (PositionConstraints)FreezePosition;
                set => FreezePosition = (int)value;
            }
        }

        [SerializeField] MaxAttributeExamples maxAttributeExamples = new MaxAttributeExamples();

        [System.Serializable]
        class MaxAttributeExamples
        {
            [Max(10)]
            public int _int;

            [Max(0)]
            public Vector3 vector3;

            [MessageBox("Minimum is always <= Maximum", MessageBoxType.Info)]
            [Max(nameof(maximum))] public float minimum = 0;
            public float maximum = 1;

            //or combine it with a min
            [HorizontalLine("values: 0 - 10")]
            [Min(0), Max(10)]
            public float _float;

            //range looks different
            [HorizontalLine("[Range]")]
            [Range(0, 10)]
            public float rangeComparison;
        }

        [SerializeField] MessageBoxAttributeExamples messageBoxAttributeExamples = new MessageBoxAttributeExamples();

        [System.Serializable]
        class MessageBoxAttributeExamples
        {
            [Title("Here are some message-boxes:")]
            [MessageBox("Booleans",
                    MessageBoxType.Info)]
            public bool myBool1 = true;

            [MessageBox("These values are obsolete.",
                    MessageBoxType.Warning)]
            public int amount1 = 55;

            [MessageBox("Some error", MessageBoxType.Error)]

            [SerializeField, HideField]
            bool abc;
        }

        [SerializeField] Min2AttributeExamples min2AttributeExamples = new Min2AttributeExamples();

        [System.Serializable]
        class Min2AttributeExamples
        {
            [Min2(10)]
            public int _int;

            [HorizontalLine]

            [MessageBox("Minimum is always <= Maximum", MessageBoxType.Info)]

            public float minimum = 0;
            [Min2(nameof(minimum))] public float maximum = 1;

            [HorizontalLine]

            //you could even reference strings if they are in correct format
            [Min2(nameof(stringMin))]
            public int myCappedValue = 2;
            public string stringMin = "5";

            [HorizontalLine]
            [MessageBox("on vectors the min works componentwise:\nminVector.x <= myVector.x, ...", MessageBoxType.Info)]

            public Vector3Int minVector;
            [Min2(nameof(minVector))]
            public Vector3Int myVector;
        }

        [SerializeField] MultipleOfAttributeExamples multipleOfAttributeExamples = new MultipleOfAttributeExamples();

        [System.Serializable]
        class MultipleOfAttributeExamples
        {
            [MultipleOf(3)]
            public int _int = 6;

            [MultipleOf(0.3f)]
            public float _float = 1.2f;

            [HorizontalLine]

            public double step = .5f;
            [MultipleOf("step")]
            public float multipleOfStep;
        }

        [SerializeField] PreviewAttributeExamples previewAttributeExamples = new PreviewAttributeExamples();

        [System.Serializable]
        class PreviewAttributeExamples
        {
            [MessageBox("Please drag/select values to see previews", MessageBoxType.Info)]

            [SerializeField, Preview(Size.small)] GameObject gob;
            [SerializeField, Preview] Sprite sprite;

            [ForceFill(errorMessage = "Select an icon/Sprite from the drop-down")]
            [SerializeField, Preview(Size.big)] Sprite icon;
        }

        [SerializeField] ProgressBarAttributeExamples progressBarAttributeExamples = new ProgressBarAttributeExamples();

        [System.Serializable]
        class ProgressBarAttributeExamples
        {
            [Title("Progress Bars:")]
            [Space2(20)]

            //You can set a maximum value
            [SerializeField, ProgressBar(1)] // 1 is the maximum
            [ReadOnly]
            float value1 = 0.6f;

            [HorizontalLine]

            //You can also set a minimum value and the size
            [MessageBox("Drag to edit this bar.", MessageBoxType.Info)]
            [SerializeField, ProgressBar(0, 100, size = Size.big)]
            int value2 = 20;

            [HorizontalLine]

            [MessageBox("This bar is read-only.", MessageBoxType.Info)]
            [SerializeField,
             ProgressBar(nameof(min), nameof(max),
                size = Size.big,
                isReadOnly = true)]
            float value3 = 2;

            [SerializeField] float min = 1;
            [SerializeField] float max = 3;
        }

        [SerializeField] ReadOnlyAttributeExamples readOnlyAttributeExamples = new ReadOnlyAttributeExamples();

        [System.Serializable]
        class ReadOnlyAttributeExamples
        {
            [HorizontalLine("Disabled")]

            [SerializeField, ReadOnly] int n;
            [SerializeField, ReadOnly] GameObject gob;
            [SerializeField, ReadOnly] Sprite spr;

            [HorizontalLine("Only Text")]

            [SerializeField, ReadOnly(DisableStyle.OnlyText)]
            string info = "Some Info";

            [HorizontalLine]

            public bool show = true;

            [SerializeField, ShowIf(nameof(show)),
            ReadOnly(DisableStyle.OnlyText, LabelStyle.NoLabel)]
            string
            i1 = "This is a very deep explanation..",
            i2 = "Oho, what do i see there",
            i3 = "Hello World!";
        }

        [SerializeField] RequireTypeAttributeExamples requireTypeAttributeExamples = new RequireTypeAttributeExamples();

        [System.Serializable]
        class RequireTypeAttributeExamples
        {
            [MessageBox("Allow only Components that contain specific interfaces.", MessageBoxType.Info)]

            [RequireType(typeof(IAge))]
            public Component agingScript;

            [RequireType(typeof(IHuman))]
            public MonoBehaviour myHuman;

            interface IAge
            {
                public abstract int GetAge();
            }
            interface IHuman : IAge
            {
                public abstract int GetHeight();
                public abstract int GetHairColor();
            }
        }

        [SerializeField] RichTextAttributeExamples richTextAttributeExamples = new RichTextAttributeExamples();

        [System.Serializable]
        class RichTextAttributeExamples
        {
            [RichText, Multiline(2)] public string myRichText = "Hello,\nWe are <color=green><b>not</b></color> sad.";

            [HorizontalLine]

            //setting the 'allowMultipleLines'-parameter
            [RichText, TextArea(1, 5)]
            [LabelSettings(LabelStyle.NoLabel)]
            public string myRichtText = "We are <color=green>green</color> with envy.\n\nHello <i>World</i>";

            [HorizontalLine]

            public string noRichText = "We are <color=green><b>not</b></color> sad.";
        }

        [SerializeField] SceneAttributeExamples sceneAttributeExamples = new SceneAttributeExamples();

        [System.Serializable]
        class SceneAttributeExamples
        {
            [Scene] public int gameScene;

            [Scene(useFullPath: true)] public string startScene;

            [HorizontalLine("Their values:")]

            [ShowMethod(nameof(GetGameScene))]
            [ShowMethod(nameof(GetStartScene))]

            [SerializeField, HideField] bool _;

            int GetGameScene()
                => gameScene;
            string GetStartScene()
                => startScene;

        }

        [SerializeField] SelfFillAttributeExamples selfFillAttributeExamples = new SelfFillAttributeExamples();

        [System.Serializable] //i hide this class on purpose, because SelfFill does not work on scriptable objects
        class SelfFillAttributeExamples
        {
            // default mode (OwnerMode.Self): search on current gameObject
            [SelfFill] public Camera cam;

            // mode: search for AudioSource in children
            [SelfFill(mode = OwnerMode.Children)]
            public AudioSource audio;

            // mode: search in children, but not in children of children
            [SelfFill(true, mode = OwnerMode.DirectChildren)]

            public Light light;

            // example for checking if filled:
            // 
            // void Start()
            // {
            //     this.CheckSelfFilled();
            // }
        }

        [SerializeField] ShowAssetReferenceAttributeExamples showAssetReferenceAttributeExamples = new ShowAssetReferenceAttributeExamples();

        [System.Serializable]
        class ShowAssetReferenceAttributeExamples
        {
            [ShowAssetReference("CodeSnippets")] // in this case you could also use 'nameof(CodeSnippets)'
            public A a;

            [HorizontalLine]

            [ShowAssetReference]
            public TestClass testClass;


            [System.Serializable]
            public class A
            {
                public string name = "Some Custom Class";
                [Min(0)] public int amount = 10;
            }
        }

        [SerializeField] ShowIfAttributeExamples showIfAttributeExamples = new ShowIfAttributeExamples();

        [System.Serializable]
        class ShowIfAttributeExamples
        {
            [HorizontalLine("with Booleans")]

            [MessageBox("Toggle this bool value to expose the custom colors", MessageBoxType.Info)]
            public bool customColors = false;
            [ShowIf(nameof(customColors))]
            public Color headColor = Color.white;
            [ShowIf(nameof(customColors))]
            public Color bodyColor = Color.black;

            [HorizontalLine]

            [MessageBox("Tick both conditions", MessageBoxType.Info)]
            public bool condition1 = true;
            public bool condition2 = false;

            [ShowIf(nameof(condition1), style = DisabledStyle.GreyedOut)]
            public GameObject cond1True = null;

            [ShowIf(BoolOperator.And,
                    nameof(condition1),
                    nameof(condition2),
                    style = DisabledStyle.Invisible,
                    indent = 0)]
            public string someText = "Both conditions are true";

            [HorizontalLine("With Comparisons")]

            [MessageBox("Please fill material to expose the tiling.", MessageBoxType.Info)]
            public Material material;
            [ShowIf(ComparisonOp.NotNull, nameof(material))]
            public Vector2 tiling;

            [HorizontalLine]

            [MessageBox("Make a and b same value to expose an info.", MessageBoxType.Info)]
            public int a;
            public int b = 1;
            [ShowIf(ComparisonOp.Equals, nameof(a), nameof(b))]
            [ReadOnly(DisableStyle.OnlyText)] public string info = "Both are the same.";

            [HorizontalLine("Custom Functions")]

            [MessageBox("Expose by clicking the toggle.", MessageBoxType.Info)]

            public bool toggle1;

            [ShowIf(nameof(MyMethod))]
            public float float1, float2;
            public bool MyMethod()
                => toggle1 == true;


            [HorizontalLine("With " + nameof(StaticConditions))]
            [MessageBox("Hit play-mode for testing", MessageBoxType.Info)]

            [ShowIf(StaticConditions.IsNotPlaying, style = DisabledStyle.GreyedOut)]
            [Indent(-1)]
            public string playername = "Bob";

            [ShowIf(StaticConditions.IsPlaying)]
            [Button(nameof(Jump))][SerializeField, HideField] bool _;
            void Jump() { }
        }

        [SerializeField] ShowIfIsAttributeExamples showIfIsAttributeExamples = new ShowIfIsAttributeExamples();

        [System.Serializable]
        class ShowIfIsAttributeExamples
        {
            public enum Labeling { NoLabel, CustomLabel }

            public Labeling labeling;

            [ShowIfIs(nameof(labeling), Labeling.CustomLabel)]
            public string labelText = "My Label";
        }

        [SerializeField] ShowIfIsNotAttributeExamples showIfIsNotAttributeExamples = new ShowIfIsNotAttributeExamples();

        [System.Serializable]
        class ShowIfIsNotAttributeExamples
        {
            public enum Labeling { NoLabel, CustomLabel }

            public Labeling labeling;

            [ShowIfIsNot(nameof(labeling), Labeling.NoLabel)]
            public string labelText = "My Label";
        }

        [SerializeField] ShowIfNotAttributeExamples showIfNotAttributeExamples = new ShowIfNotAttributeExamples();

        [System.Serializable]
        class ShowIfNotAttributeExamples
        {
            public Material customMaterial = null;
            //The ComparisonOp defines what to check on the given property
            //ComparisonOp.Null checks, if it is null
            [ShowIfNot(ComparisonOp.Null, nameof(customMaterial))]
            public Vector2 tiling = Vector2.one;


            [MessageBox("Tick all conditions.", MessageBoxType.Info)]

            public bool condition1 = true;
            public bool condition2 = true;
            public bool condition3 = false;

            [ShowIfNot(BoolOperator.And,
                        nameof(condition1),
                        nameof(condition2),
                        nameof(condition3))]
            public string notAllTrue = "Not all conditions are true.";


            [HorizontalLine("Functions")]

            [MessageBox("A field is visible if even number is set to an odd value.", MessageBoxType.Info)]
            public int evenNumber = 1;
            [ShowIfNot(nameof(IsEven))]
            public float value = -1;

            public bool IsEven()
            {
                return evenNumber % 2 == 0;
            }
        }

        [SerializeField] ShowMethodAttributeExamples showMethodAttributeExamples = new ShowMethodAttributeExamples();

        [System.Serializable]
        class ShowMethodAttributeExamples
        {
            [MessageBox("Move your cursor over the fields to update their values.", MessageBoxType.Info)]

            [ShowMethod(nameof(GetTime))]

            [ShowMethod(nameof(GetTime),
                label = "Current time",
                tooltip = "Updated on each gui-update")]

            [SerializeField, HideField]
            bool someBool = false;

            string GetTime()
            {
                return DateTime.Now.ToString();
            }
        }

        [SerializeField] ShowPropertyAttributeExamples showPropertyAttributeExamples = new ShowPropertyAttributeExamples();

        [System.Serializable]
        class ShowPropertyAttributeExamples
        {
            [ShowProperty("myClass.enabled", label = "Use Class")]

            [SerializeField, ShowIf("myClass.enabled"), Indent(-1)]
            MyClass myClass;

            [System.Serializable]
            class MyClass
            {
                [HideField] public bool enabled;

                public int a;
                public int b;
            }
        }

        [SerializeField] Space2AttributeExamples space2AttributeExamples = new Space2AttributeExamples();

        [System.Serializable]
        class Space2AttributeExamples
        {
            [Button(nameof(MyMethod))]

            [Space2(30)]

            [Button(nameof(MyMethod))]
            [Button(nameof(MyMethod))]

            public bool myBool;

            void MyMethod() { }
        }



        [SerializeField] TabAttributeExamples tabAttributeExamples = new TabAttributeExamples();

        [System.Serializable]
        class TabAttributeExamples
        {
            [Tab("Inventory")] public GameObject item;
            [Tab("Inventory"), BackgroundColor(FixedColor.Blue)]
            public float weight;
            [Tab("Inventory"), Min(0)]
            public float amount;

            [Tab("Stats"), Unwrap]
            public Stats stats;

            [Tab(InspectorIcon.Settings)]
            [ListContainer]
            public ListContainer<float> sizes //used instead of System.Collections.Generic.List because we dont want to apply the attribute to the elements
                = new() { 1, 2, 3 };

            [System.Serializable]
            public class Stats
            {
                [ProgressBar(100)]
                public int health = 79;
                [ProgressBar(1)]
                public float stamina = 1;
                [Min(.01f)]
                public float speed = 1.3f;
            }
        }

        [SerializeField] TagAttributeExamples tagAttributeExamples = new TagAttributeExamples();

        [System.Serializable]
        class TagAttributeExamples
        {
            [Tag] public string tag1 = "Player";
            [Tag] public string tag2;
        }

        [SerializeField] TitleAttributeExamples titleAttributeExamples = new TitleAttributeExamples();

        [System.Serializable]
        class TitleAttributeExamples
        {
            [Title("My Class", underlined: true,
                fontSize = 15,
                alignment = TextAlignment.Center)]

            [HorizontalLine("")]

            [MessageBox("The [Title]-attribute allows other attributes to draw before", MessageBoxType.Info)]
            [Button(nameof(MyFunc), label = "Button1")]
            [Title("My Boolean")]
            [Button(nameof(MyFunc), label = "Button2")]
            public bool b1;

            [HorizontalLine("")]

            [MessageBox("The [Header]-attribute draws first", MessageBoxType.Info)]
            [SerializeField, HideField] bool _;

            [Button(nameof(MyFunc), label = "Button3")]
            [Header("My Boolean")]
            [Button(nameof(MyFunc), label = "Button4")]
            public bool b2;

            void MyFunc()
            { }
        }

        [SerializeField] ToolbarAttributeExamples toolbarAttributeExamples = new ToolbarAttributeExamples();

        [System.Serializable]
        class ToolbarAttributeExamples
        {
            [HorizontalLine("Booleans")]

            [Toolbar] public bool edit;
            //edit the height and the spacing
            [Toolbar(20, 0)] public bool create;

            [HorizontalLine("Enums", 1, 2)]

            [Toolbar]
            public Animal animal;
            public enum Animal { Dog, Cat, Bird }

            [Toolbar]
            public EditType type;
            public enum EditType { create, edit, delete, update }
        }

        [SerializeField] TooltipBoxAttributeExamples tooltipBoxAttributeExamples = new TooltipBoxAttributeExamples();

        [System.Serializable]
        class TooltipBoxAttributeExamples
        {
            [TooltipBox("Explanation (1)")]
            public GameObject myGameObject;

            [HorizontalLine]

            [TooltipBox("m = meter")]
            [Unit("m")]
            [TooltipBox("Explanation (2)")]
            public float myFloat;
        }

        [SerializeField] UnfoldAttributeExamples unfoldAttributeExamples = new UnfoldAttributeExamples();

        [System.Serializable]
        class UnfoldAttributeExamples
        {
            [Unfold] public MyClass unfolded;

            [System.Serializable]
            public class MyClass
            {
                public int number1;
                public int number2;
            }
        }

        [SerializeField] UnitAttributeExamples unitAttributeExamples = new UnitAttributeExamples();

        [System.Serializable]
        class UnitAttributeExamples
        {
            [Unit("per second")] public int amount = 5;
            [Unit("cm")] public int jumpHeight = 80;
            [Unit("feet")] public int distance = 100;
        }

        [SerializeField] UnwrapAttributeExamples unwrapAttributeExamples = new UnwrapAttributeExamples();

        [System.Serializable]
        class UnwrapAttributeExamples
        {
            [HorizontalLine("Unwrapped")]
            [Unwrap] public MyClass unwrapped;

            [HorizontalLine]

            [MessageBox("Adds the class name as prefix.", MessageBoxType.Info)]
            [Unwrap(applyName = true)] public MyClass class1;

            [HorizontalLine("Default Display")]
            public MyClass wrapped;


            [System.Serializable]
            public class MyClass
            {
                public int number1;
                public int number2;
            }
        }

        [SerializeField] URLAttributeExamples uRLAttributeExamples = new URLAttributeExamples();

        [System.Serializable]
        class URLAttributeExamples
        {
            public int a;
            public int b;

            [URL("http://mbservices.de/")]
            // you can also add a label and tooltip
            [URL("www.google.com/", label = "google:",
                                    tooltip = "This is a tooltip")]

            public int c;
            public int d;
        }

        [SerializeField] ValidateAttributeExamples validateAttributeExamples = new ValidateAttributeExamples();

        [System.Serializable]
        class ValidateAttributeExamples
        {
            [HorizontalLine("Change Values:", 0)]

            [Validate(nameof(IsEven))]
            public int evenNumber = 2;

            [HorizontalLine]

            [Validate(nameof(IsOdd), "Value has to be odd!")]
            public int oddNumber = 1;

            bool IsEven(int i)
                => i % 2 == 0;
            bool IsOdd(int i)
                => Math.Abs(i % 2) == 1;
        }

        //----------------------------------------------------Types------------------------------------------------
        [HorizontalLine("Types", 3)]


        [SerializeField] Array2DExamples array2DExamples = new Array2DExamples();

        [System.Serializable]
        class Array2DExamples
        {
            [SerializeField, Array2D]
            Array2D<Sprite> images
                 = new Array2D<Sprite>(2, 2);

            [HorizontalLine]

            [Array2D] public Array2D<int> numbers;
        }

        [SerializeField] DynamicSliderExamples dynamicSliderExamples = new DynamicSliderExamples();

        [System.Serializable]
        class DynamicSliderExamples
        {
            [Title("A changable range")]
            [DynamicSlider]
            public DynamicSlider sliderValue
                = new DynamicSlider(5, 1, 10);

            [Title("Only one custom side")]
            [DynamicSlider]
            public DynamicSlider value2
                = new DynamicSlider(5, 1, 10, FixedSide.FixedMin);

            [DynamicSlider]
            public DynamicSlider value3
                = new DynamicSlider(5, 1, 10, FixedSide.FixedMax);

            [HorizontalLine]

            public bool useSlider = false;
            [DynamicSlider, ShowIf(nameof(useSlider), style = DisabledStyle.GreyedOut)]
            public DynamicSlider slider
                = new DynamicSlider(1, 0, 2);


            void Increment()
            {
                //implicit conversion to float 
                float a = sliderValue;
                a++;
                sliderValue.value = a;
            }
        }

        [SerializeField] FilePathExamples filePathExamples = new FilePathExamples();

        [System.Serializable]
        class FilePathExamples
        {
            [HorizontalLine("Some Files:")]
            public FilePath filePath
                        = new FilePath("Assets");

            public FilePath meshPath
                        = new FilePath(typeof(Mesh));

            [HorizontalLine]

            [ReadOnly, AssetPath]
            public FilePath path = new FilePath();

            void SomeFunc()
            {
                if (filePath.HasPath())
                {
                    string path = filePath.GetPath();
                }
            }
        }

        [SerializeField] FolderPathExamples folderPathExamples = new FolderPathExamples();

        [System.Serializable]
        class FolderPathExamples
        {
            [HorizontalLine("Some FolderPaths")]
            public FolderPath folderPath
                        = new FolderPath("Assets");

            public FolderPath path2
                        = new FolderPath();

            public FolderPath path3
                        = new FolderPath("Assets/Materials");

            [HorizontalLine]

            [ReadOnly, AssetPath]
            public FolderPath path = new("Assets/");

            void SomeFunc()
            {
                try
                {
                    Mesh mesh = path2.LoadAsset<Mesh>("MyMesh.mesh");
                    path3.CreateAsset(null, "Abc.mesh");
                }
                catch (NullReferenceException e)
                {
                    Debug.LogException(e);
                }
            }
        }

        [SerializeField] LineGraphExamples lineGraphExamples = new LineGraphExamples();

        [System.Serializable]
        class LineGraphExamples
        {
            [Unfold, LineGraph]
            public LineGraph ak47_damage
                = new LineGraph(new Vector2[]{ new Vector2(10, 50),
                                       new Vector2(20, 20),
                                       new Vector2(50, 10),
                                       new Vector2(50, 0)});


            private void Start()
            {
                float distance = 15;
                float damage = ak47_damage.GetYValue(distance);
                // damage -> 35
            }
        }

        [SerializeField] ListContainerExamples listContainerExamples = new ListContainerExamples();

        [System.Serializable]
        class ListContainerExamples
        {
            [MessageBox("New label and ShowIf and is applied to the whole list." +
                        "\nList is shown if 'visible' is ticked.", MessageBoxType.Info)]

            public bool visible = true;

            [LabelSettings("New Label"),
            ShowIf(nameof(visible))]
            [ListContainer]
            public ListContainer<int> myList;

            [HorizontalLine]
            [MessageBox("New labels and MinAttribute are applied to all elements." +
                        "\nAll elements of the list are positive.", MessageBoxType.Info)]
            [SerializeField, HideField] bool _;

            [LabelSettings("New Label"),
            Min(0)]
            public List<int> myPositiveNumbers
                = new() { 1, 2, 3 };

            private void Start()
            {
                // Types can be easily converted:
                List<int> numbers = new ListContainer<int>() { 1, 2, 3 };
                ListContainer<int> ints = numbers;

                // Is serializable by JsonUtility
                string json = JsonUtility.ToJson(myList);
                ListContainer<int> deserialized
                    = JsonUtility.FromJson<ListContainer<int>>(json);
            }
        }

        [SerializeField] MessageDrawerExamples messageDrawerExamples = new MessageDrawerExamples();

        [System.Serializable]
        class MessageDrawerExamples
        {
            [Button(nameof(LogTime), label = "Add Current Time")]
            [Button(nameof(LogWarning))]
            [Button(nameof(LogError))]

            [MessageDrawer] public MessageDrawer md = new MessageDrawer();

            void LogTime()
            {
                md.DrawMessage(DateTime.Now.ToString());
            }
            void LogWarning()
            {
                md.DrawWarning("You added a Warning");
            }
            void LogError()
            {
                md.DrawError("You added an Error Message");
            }
        }

        [SerializeField] SerializableNullableExamples serializableNullableExamples = new SerializableNullableExamples();

        [System.Serializable]
        class SerializableNullableExamples
        {
            //Non Serialized
            public int? notShown1;
            public System.Nullable<int> notShown2;

            //Serialized
            public SerializableNullable<int> shown1 = 1;
            public SerializableNullable<int> shown2 = null;


            void MyMethod()
            {
                shown1 = 10;
                Debug.Assert(shown1.HasValue);
                Debug.Assert(shown1.Value == 10);

                shown1 = null;
                Debug.Assert(shown1 == null);
            }
            void Cast()
            {
                notShown1 = (int?)shown1;
                shown2 = (SerializableNullable<int>)notShown2;
            }
        }

        [SerializeField] ReorderableDictionaryExamples reorderableDictionaryExamples = new ReorderableDictionaryExamples();

        [System.Serializable]
        class ReorderableDictionaryExamples
        {
            [SerializeField]
            [Dictionary]
            ReorderableDictionary<int, string> dict1
                = new() { { 1, "Hello" }, { 2, "World" } };

            [SerializeField, Dictionary(keySize: .2f)]
            ReorderableDictionary<string, MyClass> dict2
                = new();

            [System.Serializable]
            class MyClass
            {
                public int a;
                public int b;
                public int c;
            }
        }

        [SerializeField] SerializableDateTimeExamples serializableDateTimeExamples = new SerializableDateTimeExamples();

        [System.Serializable]
        class SerializableDateTimeExamples
        {
            //leave out the attribute to display the class normally
            public SerializableDateTime time1
                = DateTime.Today;

            [HorizontalLine]

            [SerializableDateTime(SerializableDateTime.InspectorFormat.DateEnums)]
            public SerializableDateTime time2;

            [HorizontalLine]

            [SerializableDateTime(SerializableDateTime.InspectorFormat.AddTextInput)]
            public SerializableDateTime time3;
        }

        [SerializeField] SerializableDictionaryExamples serializableDictionaryExamples = new SerializableDictionaryExamples();

        [System.Serializable]
        class SerializableDictionaryExamples
        {
            [Dictionary] //dont forget the attribute!
            public SerializableDictionary<int, string> dict1
                = new SerializableDictionary<int, string>();

            [HorizontalLine]

            [Button(nameof(AddRandomValue))]
            [SerializeField, HideField] bool _;

            void AddRandomValue()
            {
                dict1.TryAdd(UnityEngine.Random.Range(-2000, 2000), "Some Random Value");
                //Access: myDictionary[key] = value
            }

            [HorizontalLine("More Examples")]

            [Dictionary]
            public SerializableDictionary<int, MyClass> dict2 = new SerializableDictionary<int, MyClass>();
            [Dictionary]
            public SerializableDictionary<int, GameObject> dict3 = new SerializableDictionary<int, GameObject>();

            [System.Serializable]
            public class MyClass
            {
                public string name = "Empty";
                public int id = -1;

                public MyClass(string name, int id)
                {
                    this.name = name;
                    this.id = id;
                }
                public override bool Equals(object obj)
                {
                    if (obj is MyClass c)
                    {
                        return name == c.name && id == c.id;
                    }
                    return false;
                }
                public override int GetHashCode()
                {
                    return id;
                }
            }
        }

        [SerializeField] SerializableInterfaceExamples serializableInterfaceExamples = new SerializableInterfaceExamples();

        [System.Serializable]
        class SerializableInterfaceExamples
        {
            [MessageBox("A reference that is stored casted to the given interface", MessageBoxType.Info)]

            [Interface]
            public SerializableInterface<IAbc> withMyInterface1;

            [HorizontalLine]

            [Interface] public SerializableInterface<IAbc> withMyInterface2;

            [HorizontalLine]

            [MessageBox("The alternative is to store it as a monoBehaviour with a [RequireType] constraint, but it won't be casted then", MessageBoxType.Info)]
            [RequireType(typeof(IAbc))]
            public MonoBehaviour monoBehaviour;


            public void Start()
            {
                withMyInterface1.Value?.Increment();

                IAbc value2 = withMyInterface2.Value;
                value2?.Increment();
            }
            public interface IAbc
            {
                public void Increment();
            }
        }

        [SerializeField] SerializableSortedDictionaryExamples serializableSortedDictionaryExamples = new SerializableSortedDictionaryExamples();

        [System.Serializable]
        class SerializableSortedDictionaryExamples
        {
            [HorizontalLine("Integer")]

            [Dictionary] //dont forget the attribute!
            public SerializableSortedDictionary<int, string> dict1
                = new SerializableSortedDictionary<int, string>();

            [HorizontalLine]

            [Button(nameof(AddRandomValue))]
            [SerializeField, HideField] bool a;

            void AddRandomValue()
            {
                dict1.TryAdd(UnityEngine.Random.Range(-2000, 2000), "Some Random Value");
                //Access: myDictionary[key] = value
            }

            [HorizontalLine("Custom Class")]

            [Dictionary]
            public SerializableSortedDictionary<MyClass, string> myBehaviours = new();

            public class MyClass : MonoBehaviour, IComparable
            {
                // this compare method only works, if all objects have different names
                int IComparable.CompareTo(object obj)
                {
                    return this.name.CompareTo((obj as UnityEngine.Object).name);
                }
            }
        }

        [SerializeField] SerializableSetExamples serializableSetExamples = new SerializableSetExamples();

        [System.Serializable]
        class SerializableSetExamples
        {
            [Set] //dont forget the attribute!
            public SerializableSet<int> set1
                = new SerializableSet<int>();

            [HorizontalLine]

            [Button(nameof(AddRandomValue))]
            [SerializeField, HideField] bool a;

            void AddRandomValue()
            {
                set1.TryAdd(UnityEngine.Random.Range(-2000, 2000));
            }

            [HorizontalLine("Custom Class Example")]

            [Set]
            public SerializableSet<MyClass> set2
                = new SerializableSet<MyClass>();

            [System.Serializable]
            public class MyClass
            {
                public string name = "Empty";
                public int id = -1;

                public MyClass(string name, int id)
                {
                    this.name = name;
                    this.id = id;
                }
                public override bool Equals(object obj)
                {
                    if (obj is MyClass c)
                    {
                        return name == c.name && id == c.id;
                    }
                    return false;
                }
                public override int GetHashCode()
                {
                    return id;
                }
            }
        }

        [SerializeField] SerializableSortedSetExamples serializableSortedSetExamples = new SerializableSortedSetExamples();

        [System.Serializable]
        class SerializableSortedSetExamples
        {
            [Set] //dont forget the attribute!
            public SerializableSortedSet<int> set1
                = new SerializableSortedSet<int>() { 1, 3, -75, 2 };

            [HorizontalLine]

            [Button(nameof(AddRandomValue))]
            [SerializeField, HideField] bool a;

            void AddRandomValue()
            {
                set1.TryAdd(UnityEngine.Random.Range(-2000, 2000));
            }
        }


        [SerializeField] StaticsDrawerExamples staticsDrawerExamples = new StaticsDrawerExamples();

        [System.Serializable]
        class StaticsDrawerExamples
        {
            [HorizontalLine("Default")]

            [Title("My Values")]
            public string hello = "Hello!";


            static int a = 6;
            static float b = 9.5f;
            protected GameObject c = null;
            private static Color d = Color.white;
            public static Vector2 e = new Vector2(0.5f, 8);

            [SerializeField, StaticsDrawer]
            StaticsDrawer instanceDrawer = new();

            [HorizontalLine("Including base class")]

            [SerializeField] B myClass;

            [Serializable]
            class B : A
            {
                private static bool a0 = false;

                [StaticsDrawer(StaticMembersSearchType.AlsoInBases)]
                public StaticsDrawer fullDrawer = new();

                [HorizontalLine("Including inherited members")]

                [StaticsDrawer(StaticMembersSearchType.FlattenHierarchy)]
                public StaticsDrawer inheritedDrawer = new();
            }
            class A
            {
                private static int a1 = 4;
                protected static bool a2 = true;
            }
        }

        [SerializeField] SerializableTupleExamples serializableTupleExamples = new SerializableTupleExamples();

        [System.Serializable]
        class SerializableTupleExamples
        {
            //Non Serialized
            public (int, int) notShown1;
            public Tuple<int, int> notShown2;

            //Serialized
            [Tuple] public SerializableTuple<int, string> tuple1 = new(1, "a");
            [Tuple] public SerializableTuple<int, float, GameObject> tuple2 = new(1, 1.5f, null);
        }

        //----------------------------------------------------Unitys------------------------------------------------
        [HorizontalLine("Unitys", 3)]

        [SerializeField] ColorUsageAttributeExamples colorUsageAttributeExamples = new ColorUsageAttributeExamples();

        [System.Serializable]
        class ColorUsageAttributeExamples
        {
            [Title("Alpha")]
            [ColorUsage(showAlpha: true)]
            public Color c1 = Color.white;
            [ColorUsage(showAlpha: false)]
            public Color c2 = Color.red;

            [Title("HDR")]
            [ColorUsage(true, hdr: true)]
            public Color c3 = Color.magenta;
            [ColorUsage(true, hdr: false)]
            public Color c4 = Color.cyan;
        }

        [SerializeField] FormerlySerializedAsAttributeExamples formerlySerializedAsAttributeExamples = new FormerlySerializedAsAttributeExamples();

        [System.Serializable]
        class FormerlySerializedAsAttributeExamples
        {
            // public int hitpoints;

            [UnityEngine.Serialization.FormerlySerializedAs("hitpoints")]
            public int health;
        }

        [SerializeField] DelayedAttributeExamples delayedAttributeExamples = new DelayedAttributeExamples();

        [System.Serializable]
        class DelayedAttributeExamples
        {
            [Delayed]
            public string delayed = "Edit Here";

            public string instant = "Edit Here";


            [ShowMethod(nameof(GetDelayedOne))]
            [ShowMethod(nameof(GetInstantOne))]

            [HideField]
            public bool b2;

            string GetDelayedOne()
                => delayed;
            string GetInstantOne()
                => instant;
        }


        [SerializeField] HeaderAttributeExamples headerAttributeExamples = new HeaderAttributeExamples();

        [System.Serializable]
        class HeaderAttributeExamples
        {
            [Header("First")]
            public string a;
            public string b;
            public string c;

            [Header("Second")]
            public string a2;
            public string b2;
            public string c2;
        }

        [SerializeField] HideInInspectorAttributeExamples hideInInspectorAttributeExamples = new HideInInspectorAttributeExamples();

        [System.Serializable]
        class HideInInspectorAttributeExamples
        {
            [MessageBox("Button is hidden too", MessageBoxType.Info)]
            public string a;

            [Button(nameof(MyMethod))]
            [HideInInspector]
            public string b;

            [HorizontalLine]

            [MessageBox("Button is visible too", MessageBoxType.Info)]

            [Button(nameof(MyMethod))]
            [HideField]
            public string c;

            void MyMethod() { }
        }

        [SerializeField] MinAttributeExamples minAttributeExamples = new MinAttributeExamples();

        [System.Serializable]
        class MinAttributeExamples
        {
            [Min(0)]
            public int i = 5;

            [Min(10)]
            public float f = 5;

            [Min(0)]
            public Vector3 v = Vector3.up;
        }

        [SerializeField] MultilineAttributeExamples multilineAttributeExamples = new MultilineAttributeExamples();

        [System.Serializable]
        class MultilineAttributeExamples
        {
            [Multiline(lines: 4)]
            public string info = "Hello World!";
        }

        [SerializeField] NonReorderableAttributeExamples nonReorderableAttributeExamples = new NonReorderableAttributeExamples();

        [System.Serializable]
        class NonReorderableAttributeExamples
        {
            [Header("Non Reorderable List")]
            [NonReorderable]
            public string[] list1 = new string[] { "Abc", "Def", "Ghi", "Jkl" };
        }

        [SerializeField] NonSerializedAttributeExamples nonSerializedAttributeExamples = new NonSerializedAttributeExamples();

        [System.Serializable]
        class NonSerializedAttributeExamples
        {
            [HorizontalLine("Not found, because of [NonSerialized]")]

            [ShowProperty(nameof(myNonSerializedInt))]
            [HideField] public bool __;

            [NonSerialized]
            public int myNonSerializedInt;

            [HorizontalLine("Found, because it is still serialized")]

            [ShowProperty(nameof(mySerializedInt))]
            [HideField] public bool ___;

            [HideInInspector]
            public int mySerializedInt;
        }

        [SerializeField] RangeAttributeExamples rangeAttributeExamples = new RangeAttributeExamples();

        [System.Serializable]
        class RangeAttributeExamples
        {
            [Range(0, 10)] public int _int;
            [Range(0, 10)] public float _float;
        }

        [SerializeField] SpaceAttributeExamples spaceAttributeExamples = new SpaceAttributeExamples();

        [System.Serializable]
        class SpaceAttributeExamples
        {
            public int int1;
            public int int2;
            [Space2(20)]
            public float float1;
            public float float2;
        }

        [SerializeField] TooltipAttributeExamples tooltipAttributeExamples = new TooltipAttributeExamples();

        [System.Serializable]
        class TooltipAttributeExamples
        {
            [MessageBox("Hover over these fields:", MessageBoxType.Info)]

            [Tooltip("Some Tooltip")]
            public int _int;

            [Tooltip("Some Other Tooltip")]
            [SerializeField] Abc someClass;

            [System.Serializable]
            class Abc
            {
                [Tooltip("A Third Tooltip")]
                public int i;
            }
        }

        [SerializeField] TextAreaAttributeExamples textAreaAttributeExamples = new TextAreaAttributeExamples();

        [System.Serializable]
        class TextAreaAttributeExamples
        {
            [TextArea(1, 20)]
            public string someString;

            [TextArea(minLines: 1, maxLines: 20)]
            public string otherString = "a\nb\nc\nd\ne\nf\ng";
        }


#pragma warning restore CS0414
#pragma warning restore IDE0052 // Remove unread private members
#pragma warning restore IDE0051 // Remove unused private members
#pragma warning restore IDE0044 // Add readonly modifier
#pragma warning restore IDE0059 // Unnecessary assignment of a value
#pragma warning restore IDE0090 // Use 'new(...)'
    }
}