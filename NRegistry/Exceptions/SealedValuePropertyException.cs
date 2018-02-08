using System;
using NPanda.NRegistry.Resources;

namespace NPanda.NRegistry.Exceptions {

    public class SealedValuePropertyException : Exception {

        public SealedValuePropertyException(Type type, string memberName) : base(string.Format(ExceptionStrings.SealedClass, type.Name, memberName)) {}

        public SealedValuePropertyException(string message) : base(message) {}

    }

}