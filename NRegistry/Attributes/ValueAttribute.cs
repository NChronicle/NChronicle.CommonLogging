using System;
using System.Reflection;
using NPanda.NRegistry.Enumerations;

namespace NPanda.NRegistry.Attributes {

    [AttributeUsage (AttributeTargets.Property)]
    public class ValueAttribute : Attribute {

        internal ValueKind ValueKind;

        internal string ValueName;

        public ValueAttribute (string valueName = null, ValueKind valueKind = ValueKind.RegSz) {
            this.ValueName = valueName;
            this.ValueKind = valueKind;
        }

        public ValueAttribute (ValueKind valueKind) : this(null, valueKind) {}

        public static ValueAttribute GetFromProperty (PropertyInfo property) {
            var value = property.GetCustomAttribute <ValueAttribute>();
            if (value == null) return null;
            if (value.ValueName == null) value.ValueName = property.Name;
            return value;
        }

    }

}