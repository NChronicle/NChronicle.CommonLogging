using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NPanda.NRegistry.Tests.Get.FromConcrete {

    [TestClass]
    public class Reads : TestBase {

        private TestClass _object;

        [TestInitialize]
        public void Init () {
            this._object = this.Session.Get <TestClass>();
        }

        [TestMethod]
        public void DefaultString () {
            Assert.AreEqual(default(string), this._object.MyString);
        }

        [TestMethod]
        public void DefaultIntPointer () {
            Assert.AreEqual(default(IntPtr), this._object.MyIntPointer);
        }

        [TestMethod]
        public void DefaultInteger () {
            Assert.AreEqual(default(int), this._object.MyInt);
        }

        [TestMethod]
        public void DefaultBool () {
            Assert.AreEqual(default(bool), this._object.MyBool);
        }

        [TestMethod]
        public void DefaultByte () {
            Assert.AreEqual(default(byte), this._object.MyByte);
        }

        [TestMethod]
        public void DefaultChar () {
            Assert.AreEqual(default(char), this._object.MyChar);
        }

        [TestMethod]
        public void DefaultLong () {
            Assert.AreEqual(default(long), this._object.MyLong);
        }

        [TestMethod]
        public void DefaultShort () {
            Assert.AreEqual(default(short), this._object.MyShort);
        }

        [TestMethod]
        public void DefaultDecimal () {
            Assert.AreEqual(default(decimal), this._object.MyDecimal);
        }

        [TestMethod]
        public void DefaultDouble () {
            Assert.AreEqual(default(double), this._object.MyDouble);
        }

        [TestMethod]
        public void DefaultFloat () {
            Assert.AreEqual(default(float), this._object.MyFloat);
        }

        [TestMethod]
        public void DefaultDateTime () {
            Assert.AreEqual(default(DateTime), this._object.MyDateTime);
        }

        [TestMethod]
        public void DefaultGuid () {
            Assert.AreEqual(default(Guid), this._object.MyGuid);
        }

        [TestMethod]
        public void DefaultObject () {
            Assert.AreEqual(default(object), this._object.MyObject);
        }

        [TestMethod]
        public void DefaultUnsignedShort () {
            Assert.AreEqual(default(ushort), this._object.MyUnsignedShort);
        }

        [TestMethod]
        public void DefaultUnsignedLong () {
            Assert.AreEqual(default(ulong), this._object.MyUnsignedLong);
        }

        [TestMethod]
        public void DefaultUnsignedInt () {
            Assert.AreEqual(default(uint), this._object.MyUnsignedInt);
        }

        [TestMethod]
        public void DefaultCustomObject () {
            Assert.AreEqual(default(TestObject), this._object.MyCustomObject);
        }

        [TestMethod]
        public void DefaultCustomStruct () {
            Assert.AreEqual(default(string), this._object.MyCustomStruct.CustomField);
            Assert.AreEqual(default(int), this._object.MyCustomStruct.CustomField2);
        }

        [TestMethod]
        public void DefaultCustomDelegate() {
            Assert.AreEqual(default(TestDelegate), this._object.MyCustomDelegate);
        }

        [TestMethod]
        public void DefaultEnum () {
            Assert.AreEqual(default(TestEnum), this._object.MyCustomEnum);
        }

        [TestMethod]
        public void DefaultFromMethod() {
            Assert.AreEqual("Hello World", this._object.MyCustomMethod());
        }

        [TestMethod]
        public void DefaultFromMethodWithParams() {
            Assert.AreEqual("Hello World", this._object.MyCustomMethodWithParams("World", 69));
        }

        [TestMethod]
        public void DefaultFromGenericMethod() {
            Assert.AreEqual("Hello World", this._object.MyCustomGenericMethod(new TestStruct()));
        }

        [TestMethod]
        public void DefaultReferenceFromGenericReturnMethod() {
            var testParam = new TestObject();
            Assert.AreSame(testParam, this._object.MyCustomGenericReturnMethod(testParam));
        }

        [TestMethod]
        public void DefaultValueFromGenericReturnMethod() {
            Assert.AreEqual(69, this._object.MyCustomGenericReturnMethod(69));
        }

    }

}