using System;
using NPanda.NRegistry.Attributes;

namespace NPanda.NRegistry.Tests.Get.FromInterface {

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

        [Key("HKEY_LOCAL_MACHINE\\NRegistry\\ITestInterface")]
        public interface ITestInterface {

            string MyString { get; set; }
            IntPtr MyIntPointer { get; set; }
            int MyInt { get; set; }
            bool MyBool { get; set; }
            byte MyByte { get; set; }
            char MyChar { get; set; }
            long MyLong { get; set; }
            short MyShort { get; set; }
            decimal MyDecimal { get; set; }
            double MyDouble { get; set; }
            float MyFloat { get; set; }
            Guid MyGuid { get; set; }
            DateTime MyDateTime { get; set; }
            object MyObject { get; set; }
            ushort MyUnsignedShort { get; set; }
            ulong MyUnsignedLong { get; set; }
            uint MyUnsignedInt { get; set; }
            TestObject MyCustomObject { get; set; }
            TestStruct MyCustomStruct { get; set; }
            TestEnum MyCustomEnum { get; set; }
            TestDelegate MyCustomDelegate { get; set; }

            string MyCustomMethod ();

            string MyCustomMethodWithParams (string param1, int param2);

            string MyCustomGenericMethod <T> (T param1);

            T MyCustomGenericReturnMethod <T> (T param1);

        }

    }

}