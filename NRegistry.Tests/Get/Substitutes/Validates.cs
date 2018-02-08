using Microsoft.VisualStudio.TestTools.UnitTesting;
using NPanda.NRegistry.Exceptions;

namespace NPanda.NRegistry.Tests.Get.Substitutes {

    [TestClass]
    public class Validates : TestBase {

        private TestClass _object;

        [TestInitialize]
        public void Init () {
            this._object = this.Session.Get <TestClass>();
        }

        [TestMethod]
        public void KeyExistsOnRead () {
            try {
                var test = this._object.MyString;
            }
            catch (AbsentKeyException) {
                return;
            }
            Assert.Fail();
        }

    }

}
