using NPanda.NRegistry.Enumerations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Win32;

namespace NPanda.NRegistry.Tests.Get.Substitutes {

    [TestClass]
    public class Writes : TestBase {

        private TestClass _object;

        [TestInitialize]
        public void Init () {
            this._object = this.Session.Get <TestClass>();
        }

        [TestMethod]
        public void RegSz () {
            this._object.MyString = "Hello World";
            var key = Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("NRegistry").OpenSubKey("TestClass");
            using (key) {
                Assert.AreEqual("Hello World", key.GetValue("MyString"));
                Assert.AreEqual(ValueKind.RegSz, (ValueKind)key.GetValueKind("MyString"));
            }
        }

        [TestMethod]
        public void RegExpandSz () {
            this._object.MyExpandString = "Hello World";
            var key = Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("NRegistry").OpenSubKey("TestClass");
            using (key) {
                Assert.AreEqual("Hello World", key.GetValue("MyExpandString"));
                Assert.AreEqual(ValueKind.RegExpandSz, (ValueKind)key.GetValueKind("MyExpandString"));
            }
        }

        [TestMethod]
        [Ignore]
        public void RegMultiSz () {
            Assert.Fail();
        }

        [TestMethod]
        [Ignore]
        public void RegQword () {
            Assert.Fail();
        }

        [TestMethod]
        [Ignore]
        public void RegDword () {
            Assert.Fail();
        }

        [TestMethod]
        [Ignore]
        public void RegBinary () {
            Assert.Fail();
        }

        [TestMethod]
        [Ignore]
        public void RegNone () {
            Assert.Fail();
        }

        [TestCleanup]
        public void CleanUp() {
            using (var key = Registry.CurrentUser.OpenSubKey("Software", true)) {
                key.DeleteSubKeyTree("NRegistry");
            }
        }

    }

}