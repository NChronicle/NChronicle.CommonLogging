using NPanda.NRegistry.Attributes;
using NPanda.NRegistry.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NPanda.NRegistry.Tests.Get.FromInterface {

    [TestClass]
    public class Validates : TestBase {

        [TestMethod]
        public void ForPublic () {
            Assert.ThrowsException <InaccessibleTypeException>(this.Session.Get <IPrivateTestInterface>);
        }

        [TestMethod]
        public void ForKey () {
            Assert.ThrowsException <AbsentKeyAttributeException>(this.Session.Get <IAbsentKeyTestInterface>);
        }


        [Key("HKEY_LOCAL_MACHINE\\NRegistry\\IPrivateTestInterface")]
        protected interface IPrivateTestInterface { }

        public interface IAbsentKeyTestInterface { }

    }

}