using System;
using NPanda.NRegistry.Resources;

namespace NPanda.NRegistry.Exceptions {

    public class SealedValueMethodException : Exception {

        public SealedValueMethodException(Type type, string memberName) : base(string.Format(ExceptionStrings.SealedClass, type.Name, memberName)) {}

        public SealedValueMethodException(string message) : base(message) {}

    }

}