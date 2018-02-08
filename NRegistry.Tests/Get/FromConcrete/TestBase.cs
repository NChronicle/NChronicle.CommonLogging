using System;
using NPanda.NRegistry.Attributes;

namespace NPanda.NRegistry.Tests.Get.FromConcrete {

    public class TestBase : Tests.TestBase {

        public delegate void TestDelegate ();

        public enum TestEnum {

            EnumValue1,
            EnumValue2

        }

        public class TestObject {

            public string CustomField;
            public int CustomField2;

        }

        public struct TestStruct {

            public string CustomField;
            public int CustomField2;

        }

        [Key("HKEY_LOCAL_MACHINE\\NRegistry\\TestClass")]
        public class TestClass {

            public virtual string MyString { get; set; }
            public virtual IntPtr MyIntPointer { get; set; }
            public virtual int MyInt { get; set; }
            public virtual bool MyBool { get; set; }
            public virtual byte MyByte { get; set; }
            public virtual char MyChar { get; set; }
            public virtual long MyLong { get; set; }
            public virtual short MyShort { get; set; }
            public virtual decimal MyDecimal { get; set; }
            public virtual double MyDouble { get; set; }
            public virtual float MyFloat { get; set; }
            public virtual Guid MyGuid { get; set; }
            public virtual DateTime MyDateTime { get; set; }
            public virtual object MyObject { get; set; }
            public virtual ushort MyUnsignedShort { get; set; }
            public virtual ulong MyUnsignedLong { get; set; }
            public virtual uint MyUnsignedInt { get; set; }
            public virtual TestObject MyCustomObject { get; set; }
            public virtual TestStruct MyCustomStruct { get; set; }
            public virtual TestEnum MyCustomEnum { get; set; }
            public virtual TestDelegate MyCustomDelegate { get; set; }

            public virtual string MyCustomMethod () {
                return "Hello World";
            }

            public virtual string MyCustomMethodWithParams (string param1, int param2) {
                return "Hello " + param1;
            }

            public virtual string MyCustomGenericMethod <T> (T param1) {
                return "Hello World";
            }

            public virtual T MyCustomGenericReturnMethod <T> (T param1) {
                return param1;
            }

        }

    }

}