using System.Collections.Generic;

namespace CustomInspector.Documentation
{
    public static class CustomInspectorAttributeDescriptions
    {
        public static Dictionary<NewPropertyD, (string text, bool validOnScriptableObjects)> descriptions = new()
        {
            // ----------------DecoratorDrawer-------------


            { NewPropertyD.HorizontalLineAttribute,
            ("Adds a horizontal line to divide and structure the inspector."
            , true) },


            { NewPropertyD.MessageBoxAttribute,
            ("Displays an informational message in the inspector." +
            "\nUseful for providing context or details about a property." +
            "\nThe message box icon is determined by the MessageType parameter."
            , true) },


            // -------------- PropertyDrawer-------------------

            { NewPropertyD.AnimatorParameterAttribute,
            ("Lets you choose animator parameters from a popup." +
            "\nThe attribute needs a reference to an Animator or an AnimatorController."
            , true) },

            { NewPropertyD.ArrayContainer,
            ("Same behaviour as an array but applies attributes differently:" +
            "\nAll Attributes on it are applied to the whole array INSTEAD of to all elements of the array." +
            "\nThis is the array equivalent to ListContainer and the default List.\n" +
            "\nHint1: Since int[][] is not serializable in the inspector, you can use ArrayContainer<int>[] instead." +
            "\nHint2: ArrayContainer and Array are casting to each other implicitly, so you can still treat ArrayContainer as it would be of type Array."
            , true) },

            { NewPropertyD.AsButtonAttribute,
            ("Displays a bool, int, string or InspectorButtonState as a clickable button in the inspector." +
            "\nUse the 'staysPressed' parameter to specify if the button should remain pressed after being clicked."
            , true) },

            { NewPropertyD.AsRangeAttribute,
            ("Interpret a Vector2 as a range between given minLimit and maxLimit. " +
            "Useful for selecting values within a custom range."
            , true) },


            { NewPropertyD.AssetsOnlyAttribute,
            ("Prevents scene objects from being assigned to the property." +
            "\nOnly assets, such as prefabs or imported meshes, can be assigned to the property."
            , true) },


            { NewPropertyD.ButtonAttribute,
            ("Executes a function when the button is clicked." +
            "\nUseful for editor scripts or frequently-used functions that should be easily accessible."
            , true) },

            { NewPropertyD.ColorPaletteAttribute,
            ("If you use the same colors all over your project, you can choose colors from your custom color swatch." +
            "\nIf you foldout the property, it shows its current value and if the value matches a color on the palette, the given color is outlined." +
            "\nEdit color palettes by clicking on the settings-icon." +
            "\nThe color palette name in code has to match a palette name in the 'additional palettes'-section in the palettes settings." +
            "\n\nNote: Color palettes are saved in the editor preferences and can be shared via right-click -> copy+paste."
            , true) },


            { NewPropertyD.CopyPasteAttribute,
            ("Provides buttons for copying and pasting of variable values between programs using the system clipboard."
            , true) },


            { NewPropertyD.DecimalsAttribute,
            ("Limits the number of decimal places that can be entered for a property value." +
            "\nUseful for ensuring accuracy when using floats or similar data types."
            , true) },

            { NewPropertyD.Delayed2Attribute,
            ("The equivalent to unitys DelayedAttribute, but also works on vectors." +
            "\nDescription:\n" +
            "Fields will not return a new value until the user has pressed enter or focus is moved away from the field."
            , true) },

            { NewPropertyD.DisplayAutoPropertyAttribute,
            ("Obsolete: This attribute is obsolete.\nYou can access fields of autoproperties by adding \"field:\" in front of the attribute: e.g. [field: SerializeField]."
            + "\n\nNote: All further attributes must also be applied to the field with the \"field:\" keyword."
            , true) },

            { NewPropertyD.FixedValuesAttribute,
            ("Limits the input of a property to a specific set of values." +
            "\nUseful for restricting input to valid options."
            , true) },

            { NewPropertyD.FoldoutAttribute,
            ("Adds a foldout option to see more information on other MonoBehaviours or ScriptableObjects." +
            "\n\nNote: Recursive calls (unfolding a class with a reference to itself) are not displayed."
            , true) },

            { NewPropertyD.ForceFillAttribute,
            ("Indicates that a field must be filled out and can be used anywhere." +
            "\nThe forbidden values can be defined using the ToString() format for every type (e.g., Vector3 -> (1, 1, 1))." +
            "\nTo check whether all fields has been filled out, use the CheckForceFilled function: ForceFill.CheckForceFilled(this)." +
            "\nThis function is automatically excluded in the build."
            , true) },

            { NewPropertyD.FromChildrenAttribute,
            ("All references on given field must be from gameobjects from children."
            , false) },

            { NewPropertyD.GetSetAttribute,
            ("A getter and setter to validate input or change the look in the inspector." +
            "\nIf the getter has a parameter and the setter a matching returnType, the 'real' property won't be shown. " +
            "Otherwise the property under the attribute will still be visible." +
            "\n\nNote1: Only serialized fields will be saved by unity. Other changes (like on statics) will be reverted on application restart."
            , true) },


            { NewPropertyD.GUIColorAttribute,
            ("Changes the color of the whole GUI of one field or the entire GUI."
            , true) },


            { NewPropertyD.HideFieldAttribute,
            ("Hides only the fields in the inspector that are serialized by default, unlike the build-in [HideInInspector] also hiding everything attached to the fields too." +
            "\nYou can see in the example below, that HideInInspector hides other attributes too but HideField keeps previous Attributes (like the [Header]-attribute)." +
            "\nHideInInspector will hide a whole list, but HideField affects the elements of a list."
            , true) },

            { NewPropertyD.HookAttribute,
            ("Calls a method, if the value was changed in the inspector. " +
            "Given method can be without parameters or with 2 parameters (oldValue, newValue) that share the same type of the field." +
            "\nHookAttribute can be used as a custom setter: If you set 'useHookOnly', inspector inputs will *only* call the hook-method and will not apply themselves." +
            "\nWarning: If you change values of non-serialized fields/properties (like for example statics) they wont be saved."
            , true) },


            { NewPropertyD.BackgroundColorAttribute,
            ("This attribute can be used to highlight certain fields"
            , true) },


            { NewPropertyD.HorizontalGroupAttribute,
            ("Surely everyone has already thought about placing input fields next to each other in Unity so that they take up less space. " +
            "It is also very useful for structuring or for comparing two classes. " +
            "\nNote:" +
            "\n- You begin a new HorizontalGroup by setting the parameter beginNewGroup=true" +
            "\n- properties using with different tabs ([Tab]-attribute), will automatically be in different horizontal groups" +
            "\n- Does not work on list elements -> use CustomInspector.ListContainer<T> type instead of the System List<T> to apply it to the whole list"
            , true) },


            { NewPropertyD.IndentAttribute,
            ("For indenting or un-indenting your fields."
            , true)},

            { NewPropertyD.InspectorIconAttribute,
            ("Inserts an icon in front of the label or appends it at the end"
            , true) },

            { NewPropertyD.LabelSettingsAttribute,
            ("Attribute to change the label-name" +
            "\nor to hide the label" +
            "\nor to change the label-width."
            , true) },


            { NewPropertyD.LayerAttribute,
            ("If an integer represents a layer, it is very difficult to tell in the inspector which number belongs to which layer. " +
            "This attribute facilitates the assignment - you can select a single layer from an enum dropdown."
            , true) },


            { NewPropertyD.PreviewAttribute,
            ("Filenames can be long and sometimes assets are not easy to identify in the inspector. " +
            "With a preview you can see directly what kind of asset it is"
            , true) },

            { NewPropertyD.ProgressBarAttribute,
            ("Use on floats and ints to show a progressbar that finishes at given max." +
            "\nThe progressbar can be edited by dragging over it if you dont set the 'isReadOnly'."
            , true) },


            { NewPropertyD.ReadOnlyAttribute,
            ("Want to see everything? Knowledge is power, but what if you don't want that variable to be edited in the inspector?" +
            "\nWith this attribute you can easily make fields visible in the inspector without later wondering if you should change this value"
            , true) },


            { NewPropertyD.RequireTypeAttribute,
            ("Anyone who masters C# will eventually get to the point that they are working with inheritance. " +
            "Since c# doesn't support multi-inheritance, there are interfaces. " +
            "Unfortunately, a field with type of interface is not shown in the inspector. " +
            "With this attribute you can easily restrict object references to all types and they will still be displayed." +
            "\nNote: Use SerializableInterface<T> if you use it for interfaces and want the reference to be already casted."
            , true) },

            { NewPropertyD.RichTextAttribute,
            ("Display text using unitys html-style markup-format." +
            "\nYou can edit the raw text if you foldout the textfield."
            , true) },

            { NewPropertyD.SceneAttribute,
            ("Select the scene name or build-index from a dropdown." +
            "\nOnly scenes added to the build-settings are shown." +
            "\nIf you have multiple scenes with the same name, you should use the 'useFullPath' parameter to work with full paths."
            , true) },

            { NewPropertyD.SelfFillAttribute,
            ("If you have components where you know they are on your own object and don't want to write GetComponent every time, you can now write [SelfFill] in front of it. " +
            "With this attribute, the fields are already filled and saved if you open the associated inspector. " +
            "\nThe fields will hide if they are filled if you set the parameter hideIfFilled=true (they will still show an error if they didnt find themselves a suitable component). " +
            "\nModes (mode=OwnerMode...):\n\tSelf (default): on current gameObject\n\tChildren: on all children\n\tParent: on transforms parent\n\tRoot: on transforms root" +
            "\n\tDirectChildren: on children of transform, but not on children of children\n\tParents: Transform's parent, parent of parent, ..., up to transforms root" +
            "\nHint1: You can even use SelfFill.CheckSelfFilled to test whether all components have been found" +
            "\nHint2: Very useful for inner classes and list elements to get informations of the local Monobehaviour you are inside, like the current transform or gameObject."
            , false) },

            { NewPropertyD.ShowAssetReferenceAttribute,
            ("Provides a way to quickly locate files of C# classes" +
            "\nIf the file-name does not match the type of your generic class, you can insert a custom fileName to locate the file"
            , true) },


            { NewPropertyD.ShowIfAttribute,
            ("Opposite of the [ShowIfNot]-attribute.\n" +
            "Some variables are simply not needed in certain constellations. " +
            "Instead of making your inspector unnecessarily confusing, you can simply hide them. " +
            "\nYou can use nameof() to reference booleans/methods. " +
            "\nYou can use certain special conditions with the" + nameof(StaticConditions) + "-enum (like "+ nameof(StaticConditions.IsPlaying) +" or " + nameof(StaticConditions.IsActiveAndEnabled) + ")" +
            "\nThe opposite of ShowIfNotAttribute." +
            "\nIndents field automatically, but you can revert with Indent(-1)"
            , true) },


            { NewPropertyD.ShowIfIsAttribute,
            ("Opposite of the [ShowIfIsNot]-attribute.\n" +
            "Similar to the ShowIfAttribute, but instead of passing references you pass one reference and one actual value. " +
            "It is then tested whether they have the same value. " +
            "Mostly you want to use ShowIfAttribute instead, because you cannot use functions, " +
            "you are restricted to only comparing two and you can only pass constants as 2nd attribute parameter:" +
            "\nbools, numbers, strings, Types, enums, and arrays of those types"
            , true) },

            { NewPropertyD.ShowIfIsNotAttribute,
            ("Opposite of the [ShowIfIs]-attribute.\n" +
            "-> Read the description of the [ShowIfIs]-attribute to get a deeper explanation."
            , true) },


            { NewPropertyD.ShowIfNotAttribute,
            ("Opposite of the [ShowIf]-attribute.\n" +
            "-> Read the description of the [ShowIf]-attribute to get a deeper explanation."
            , true) },

            { NewPropertyD.ShowMethodAttribute,
            ("This attribute can be used to display return values from methods. " +
            "Field is updated on each OnGUI call (e.g. when you hover over menu buttons on the left)" +
            "\nThe name shown in the inspector can be given custom or is the name of the get-function without (if found) the word \"get\""
            , true) },

            { NewPropertyD.ShowPropertyAttribute,
            ("Displays a property additionally at current position." +
            "\nThe [HideField] and [HideInInspector] attributes will be removed for this property."
            , true) },

            { NewPropertyD.Space2Attribute,
            ("A Variation to unitys buildin SpaceAttribute that is more compatible with other attributes." +
            "\nThe parameter is the distance in pixels."
            , true) },

            { NewPropertyD.TabAttribute,
            ("An easy way to divide properties in groups. Fields with same (attribute parameter) groupName share the same group." +
            "\nNote: Does not work on list elements -> use CustomInspector.ListContainer<T> type instead of the System List<T> to apply it to the whole list"
            , true) },


            { NewPropertyD.TagAttribute,
            ("Makes you select tags from an enum dropdown."
            , true) },

            { NewPropertyD.TitleAttribute,
            ("An alternative to the [Header]-attribute that does not always draws first,\ngiving you a more flexible draw order." +
            "\nIt also allows for defining a tooltip and other options"
            , true) },


            { NewPropertyD.ToolbarAttribute,
            ("A normal toggle or enum dropdown is very small and unobtrusive. " +
            "This display is much more noticeable"
            , true) },

            { NewPropertyD.TooltipBoxAttribute,
            ("Especially if you rarely use tooltips, this way you can make it more clear that there is an explanation." +
            "\nFirst TooltipBox (in code) will be the outermost."
            , true) },

            { NewPropertyD.UnfoldAttribute,
            ("Always ticks the foldout on generics, so they are always open." +
            "\nUse the [Unwrap] to hide the foldout completely"
            , true) },


            { NewPropertyD.UnitAttribute,
            ("Make the current unit clear so that you can better assess the values"
            , true) },

            { NewPropertyD.UnwrapAttribute,
            ("Shows the serialized fields of the class instead of it wrapped with a foldout"
            , true) },


            { NewPropertyD.URLAttribute,
            ("Displays a clickable url in the inspector"
            , true) },


            { NewPropertyD.ValidateAttribute,
            ("If you only want to allow certain values, " +
            "this attribute is perfect to make it clear what is allowed or not directly when entering it in the inspector"
            , true) },


            { NewPropertyD.MaskAttribute,
            ("Everyone has seen the constraints on the rigidbody as 3 toggles next to each other " +
            "and maybe thought of some kind of horizontal alignment, but it's a mask. " +
            "A LayerMask is also a Mask. " +
            "A mask is a number where each bit of the number is interpreted as yes/no. " +
            "Then you can pack a lot of booleans into one number. To access the 3rd bit later, you can use bitshift for example. " +
            "Now you can easily show Masks in the inspector as what they are. Note: On integers you should specify how many bits are displayed (default=3)"
            , true) },


            { NewPropertyD.MaxAttribute,
            ("The counterpart to unitys buildin MinAttribute: Cap the values of numbers or components of vectors to a given maximum"
            , true) },


            { NewPropertyD.MultipleOfAttribute,
            ("It allows only multiples of a given number. The number can be passed by value or by name/path of field"
            , true) },

            { NewPropertyD.Min2Attribute,
            ("Extension to unitys buildin MinAttribute: You can also pass other members names to have a dynamic min value"
            , true) },

            // --------------------- Types ----------------

            { NewPropertyD.Array2D,
            ("To display a two-dimensional array as a table in the inspector."
            , true) },

            { NewPropertyD.DynamicSlider,
            ("The built-in range slider is very nice and handy; " +
            "But what if you don't want unchangable fixed min-max limits. " +
            "In this way, the designer remains flexible to change the values if necessary, but has a defined default range." +
            "\nNote: Since type drawers are not compatible to attributes by default, you have to add [DynamicSlider] attribute if you add other attributes"
            , true) },

            { NewPropertyD.FilePath,
            ("In a project I once ran DeleteAssets on a path defined by a string. " +
            "Clumsily, the string was initialized to \"Assets\". " +
            "The whole project had been deleted. That'll never happen again with this type. " +
            "If the path does not end on a specified type (which is never a Folder!), GetPath() throws a NullReferenceException" +
            "\nNote: Since type drawers are not compatible to attributes by default, you have to add [AssetPath] attribute if you add other attributes"
            , true) },


            { NewPropertyD.FolderPath,
            ("Since FilePath cannot hold Folders, this is a type that only holds paths leading to folders. " +
            "Invalid paths return NullReferenceExceptions.\n(Also look at FilePath)" +
            "\nNote: Since type drawers are not compatible to attributes by default, you have to add [AssetPath] attribute if you add other attributes"
            , true) },

            { NewPropertyD.LineGraph,
            ("Used to make a graph out of linear connecting points." +
            "\nThis is an easy method often used for balancing damage-drop-off in shooter games." +
            "\nThe black lines are the x-axis and the y-axis."
            , true) },

            { NewPropertyD.ListContainer,
            ("Same behaviour as System.Collections.Generic.List<> but with 2 differences:" +
            "\n\t1. All Attributes on it are applied to the whole list INSTEAD of to all elements of the list." +
            "\n\t2. It is serializable by JsonUtility." +
            "\nHint1: Since List<List<int>> is not serializable in the inspector, you can use List<ListContainer<int>> instead." +
            "\nHint2: ListContainer and List are casting to each other implicitly, so you can still treat ListContainer as it would be of type List." +
            "\nHint3: If you want to use attributes both on the list-class and on the elements, you have to create your own class, that consists a list inside. " +
            "Then you can provide attributes on the inner list and on the outer class. " +
            "You can add the [Unwrap]-attribute additionally on your class so you only see the list in the inspector."
            , true) },

            { NewPropertyD.MessageDrawer,
            ("If you want to write something in the inspector at runtime instead of in the console. For non-runtime messages use the MessageBoxAttribute"
            , true) },

            { NewPropertyD.SerializableNullable,
            ("A serializable equivalent to the nullable types." +
            "\n\nC# Documentation:" +
            "\nA nullable value type T? represents all values of its underlying value type T and an additional null value." +
            "\nFor example, you can assign any of the following three values to a bool? variable: true, false, or null."
            , true) },


            { NewPropertyD.ReorderableDictionary,
            ("A serializable dictionary that is shown and reordable in the inspector." +
            "\nDuplicate keys are marked in the inspector and won't be added to the dictionary." +
            "\nThe reorder-ability is just cosmetic and has no effect in code/game." +
            "\nReorderableDictionary is derived from the System.Dictionary." +
            "\nTime complexity: access = O(log(n)), add/remove = O(n)"
            , true) },


            { NewPropertyD.SerializableInterface,
            ("A reference that has already given interface and is saved already casted."
            , true) },


            { NewPropertyD.SerializableDateTime,
            ("For displaying time in the unity-inspector." +
            "\nYou can edit the inspector appealing in the [SerializableDateTime]-attribute."
            , true) },

            { NewPropertyD.SerializableDictionary,
            ("A serializable dictionary that can be shown in the inspector" +
            "\nIf you are using generic keys, you should override the equals-method " +
            "because the default implementation is based on a reference value that changes during serialization." +
            "\nTips: -The foldout's text for generics is based on the ToString-Method." +
            "\n -Change the key-value-ratio with the parameter 'keySize' on the [Dictionary]-attribute" +
            "\nTime complexity: add/remove/access = O(n)" +
            "\nUse SerializableSortedDictionary for better complexity/performance"
            , true) },


            { NewPropertyD.SerializableSortedDictionary,
            ("A serializable implementation of System.SortedDictionary that can be shown in the inspector." +
            "\nKey has to implement the interface System.IComparable." +
            "\nTime complexity: access = O(log(n)) , add/remove = O(n)"
            , true) },


            { NewPropertyD.SerializableSet,
            ("A list, with no duplicates possible. Adding a duplicate will lead to an ArgumentException" +
            "\nIf you are it with generic types, you should override the equals-method " +
            "because the default implementation is based on a reference value that changes during serialization." +
            "\nPro Tip: The foldout's text for generics is based on the ToString-Method." +
            "\nTime complexity: add/remove/access = O(n)"
            , true) },

            { NewPropertyD.SerializableSortedSet,
            ("The equivalent to the System.SortedSet but can be serialized and shown in the unity-inspector" +
            "\nTime complexity: access = O(log(n)), add/remove = O(n)"
            , true) },


            { NewPropertyD.SerializableTuple,
            ("A serializable version of a Tuple"
            , true) },

            { NewPropertyD.StaticsDrawer,
            ("Static variables are all well and good, but unity doesn't show them in the inspector. " +
            "Place the serialized StaticsDrawer anywhere in your class and the inspector will show all static variables of your class. " +
            "Since unity does not save statics, values can only be changed runtime in the inspector (you can test it by entering playmode)"
            , true) },


            // ------UNITYS--------

            { NewPropertyD.ColorUsageAttribute,
            ("Unity Documentation:\n" +
            "Attribute used to configure the usage of the ColorField and Color Picker for a color.\n" +
            "\nUse this attribute on a Color to configure the Color Field and Color Picker to show/hide the alpha value and whether to treat the color as a HDR color or as a normal LDR color."
            , true) },

            { NewPropertyD.DelayedAttribute,
            ("Unity Documentation:\n" +
            "\"When this attribute is used, the float, int, or text field will not return a new value " +
            "until the user has pressed enter or focus is moved away from the field.\""
            , true) },

            { NewPropertyD.FormerlySerializedAsAttribute,
            ("Applies a serialized value of another member B (searched by string) on the current member A.\n" +
            "The applying happens only when the current member A is firstly being registered " +
            "and member B did exist on previous recompile.\n" +
            "\nUnity Documentation:\n" +
            "\"Use this attribute to rename a field without losing its serialized value. [...]\""
            , true) },

            { NewPropertyD.HeaderAttribute,
            ("Unity Documentation:\n" +
            "\"Use this PropertyAttribute to add a header above some fields in the Inspector.\""
            , true) },

            { NewPropertyD.HideInInspectorAttribute,
            ("Not only hides a property from the inspector, but also hides everything that belongs to it." +
            "\n->To hide full list instead of only the elements of the list." +
            "\nUse the [HideField]-Attribute if you only want to hide the field only."
            , true) },

            { NewPropertyD.MinAttribute,
            ("Obsolete: use [Min2]-attribute instead\n" +
            "\nThe counterpart to the MaxAttribute." +
            "\nCap the values of numbers or components of vectors to a given minimum\n" +
            "Warning: it will only cap new inputs in the inspector: not set values by script"
            , true) },

            { NewPropertyD.MultilineAttribute,
            ("Overrides the input-box's height. Measured in lines.\n" +
            "Note: Text won't wrap to the input-box-width and will overflow.\n" +
            "\nUnity Documentation:\n" +
            "\"Attribute to make a string be edited with a multi-line textfield.\""
            , true) },

            { NewPropertyD.NonReorderableAttribute,
            ("Unity Documentation:\n" +
            "\"Disables reordering of an array or list in the Inspector window.\""
            , true) },

            { NewPropertyD.NonSerializedAttribute,
            ("Prevents the unityEditor to serialize this property so it doesnt save any values for it." +
            "\nIf you just hide the property it will still have a saved value in the background."
            , true) },

            { NewPropertyD.RangeAttribute,
            ("Draws a slider in the inspector where you can choose values from\n" +
            "\nUnity Documentation:\n" +
            "Attribute used to make a float or int variable in a script be restricted to a specific range."
            , true) },

            { NewPropertyD.SpaceAttribute,
            ("Unity Documentation:\n" +
            "\"Use this PropertyAttribute to add some spacing in the Inspector.\"" +
            "\n\n" +
            "Use the [Space2]-attribute instead, if you encounter sorting problems. [Space2] has better compatibility with other attributes."
            , true) },

            { NewPropertyD.TooltipAttribute,
            ("Adds a tooltip that you appears by hovering over the given field in the inspector AND in your visual studio editor."
            , true) },

            { NewPropertyD.TextAreaAttribute,
            ("Expands the input-box's height to it's content's height. The height is constrained to min and max lines." +
            "Text will wrap to the input-box-width and won't overflow.\n" +
            "If content has more lines than max lines a scrollbar is added.\n" +
            "\nUnity Documentation:\n" +
            "\"Attribute to make a string be edited with a height-flexible and scrollable text area.\n" +
            "You can specify the minimum and maximum lines for the TextArea, and the field will expand according to the size of the text. " +
            "A scrollbar will appear if the text is bigger than the area available.\""
            , true) },
        };
    }
}