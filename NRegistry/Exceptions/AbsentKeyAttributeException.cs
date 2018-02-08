using System;
using NPanda.NRegistry.Resources;

namespace NPanda.NRegistry.Exceptions {

    public class AbsentKeyAttributeException : Exception {

        public AbsentKeyAttributeException(Type type) : base(string.Format(ExceptionStrings.AbsentKeyAttribute, type.Name)) { }

        public AbsentKeyAttributeException(string message) : base(message) {}

    }

}