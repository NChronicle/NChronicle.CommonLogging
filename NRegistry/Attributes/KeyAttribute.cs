using System;

namespace NPanda.NRegistry.Attributes {

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
    public class KeyAttribute : Attribute {

        internal readonly string KeyPath;

        public KeyAttribute(string keyPath) {
            this.KeyPath = keyPath;
        }

    }

}