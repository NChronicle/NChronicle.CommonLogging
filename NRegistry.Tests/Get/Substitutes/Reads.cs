using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Win32;

namespace NPanda.NRegistry.Tests.Get.Substitutes {

    [TestClass]
    public class Reads : TestBase {

        private TestClass _object;

        [TestInitialize]
        public void Init () {
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\NRegistry\\TestClass", "MyString", "Hello World");
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\NRegistry\\TestClass", "MyExpandString", "Hello World", RegistryValueKind.ExpandString);
            this._object = this.Session.Get <TestClass>();
        }

        [TestMethod]
        public void RegSz () {
            Assert.AreEqual("Hello World", this._object.MyString);
        }

        [TestMethod]
        public void RegExpandSz () {
            Assert.AreEqual("Hello World", this._object.MyExpandString);
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