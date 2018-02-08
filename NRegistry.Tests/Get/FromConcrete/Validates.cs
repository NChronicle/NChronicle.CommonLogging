using NPanda.NRegistry.Attributes;
using NPanda.NRegistry.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NPanda.NRegistry.Tests.Get.FromConcrete {

    [TestClass]
    public class Validates : TestBase {

        [TestMethod]
        public void ForPublic () {
            Assert.ThrowsException <InaccessibleTypeException>(this.Session.Get <PrivateTestClass>);
        }

        [TestMethod]
        public void AgainstSealed () {
            Assert.ThrowsException <SealedClassException>(this.Session.Get <SealedTestClass>);
        }

        [TestMethod]
        public void ForVirtualValueProperties () {
            Assert.ThrowsException <SealedValuePropertyException>(this.Session.Get <SealedValuePropertyTestClass>);
        }

        [TestMethod]
        public void ForKey () {
            Assert.ThrowsException <AbsentKeyAttributeException>(this.Session.Get <AbsentKeyTestClass>);
        }

        [Key ("HKEY_LOCAL_MACHINE\\Software\\NRegistry\\SealedValuePropertyTestClass")]
        public class SealedValuePropertyTestClass {

            [Value]
            public string MyString { get; set; }

        }

        [Key("HKEY_LOCAL_MACHINE\\NRegistry\\PrivateTestClass")]
        protected class PrivateTestClass { }

        [Key("HKEY_LOCAL_MACHINE\\NRegistry\\SealedTestClass")]
        public sealed class SealedTestClass { }

        public class AbsentKeyTestClass { }

    }

}