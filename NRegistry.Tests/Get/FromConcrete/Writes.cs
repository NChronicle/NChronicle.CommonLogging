using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NPanda.NRegistry.Tests.Get.FromConcrete {

    [TestClass]
    public class Writes : TestBase {

        private TestClass _object;

        [TestInitialize]
        public void Init () {
            this._object = this.Session.Get <TestClass>();
        }

        [TestMethod]
        public void String () {
            this._object.MyString = "Hello World";
        }

        [TestMethod]
        public void IntPointer () {
            this._object.MyIntPointer = new IntPtr(69);
        }

        [TestMethod]
        public void Integer () {
            this._object.MyInt = 69;
        }

        [TestMethod]
        public void Bool () {
            this._object.MyBool = true;
        }

        [TestMethod]
        public void Byte () {
            this._object.MyByte = 69;
        }

        [TestMethod]
        public void Char () {
            this._object.MyChar = 'A';
        }

        [TestMethod]
        public void Long () {
            this._object.MyLong = 69;
        }

        [TestMethod]
        public void Short () {
            this._object.MyShort = 69;
        }

        [TestMethod]
        public void Decimal () {
            this._object.MyDecimal = 69.69m;
        }

        [TestMethod]
        public void Double () {
            this._object.MyDouble = 69.69d;
        }

        [TestMethod]
        public void Float () {
            this._object.MyFloat = 69.69f;
        }

        [TestMethod]
        public void DateTime () {
            this._object.MyDateTime = System.DateTime.MaxValue;
        }

        [TestMethod]
        public void Guid () {
            this._object.MyGuid = System.Guid.NewGuid();
        }

        [TestMethod]
        public void Object () {
            this._object.MyObject = new { key = "value" };
        }

        [TestMethod]
        public void UnsignedShort () {
            this._object.MyUnsignedShort = 69;
        }

        [TestMethod]
        public void UnsignedLong () {
            this._object.MyUnsignedLong = 69;
        }

        [TestMethod]
        public void UnsignedInt () {
            this._object.MyUnsignedInt = 69;
        }

        [TestMethod]
        public void Enum () {
            this._object.MyCustomEnum = TestEnum.EnumValue2;
        }

        [TestMethod]
        public void CustomObject () {
            this._object.MyCustomObject = new TestObject();
        }

        [TestMethod]
        public void CustomStruct () {
            this._object.MyCustomStruct = new TestStruct();
        }

        [TestMethod]
        public void CustomDelegate () {
            this._object.MyCustomDelegate = () => { };
        }

    }

}