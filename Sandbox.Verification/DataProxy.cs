using System.Runtime.InteropServices;

namespace Sandbox.Verification
{
    internal class DataProxy
    {
        public string Password;
        public int TestField;

        private DataProxy()
        {
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct Proxy
        {
            [FieldOffset(0)]
            public object Object;

            [FieldOffset(0)]
            public DataProxy DataProxy;
        }

        public static DataProxy Create(Data obj)
        {
            return new Proxy {Object = obj}.DataProxy;
        }
    }
}