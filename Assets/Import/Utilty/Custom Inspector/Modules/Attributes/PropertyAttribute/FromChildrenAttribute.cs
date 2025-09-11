using System;
using System.Diagnostics;

namespace CustomInspector
{
    /// <summary>
    /// Forces filled references to be only from children
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    [Conditional("UNITY_EDITOR")]
    public class FromChildrenAttribute : ComparablePropertyAttribute
    {
        public bool allowNull = false;
        public FromChildrenAttribute()
        {
            order = -10;
        }

        protected override object[] GetParameters() => null;
    }
}
