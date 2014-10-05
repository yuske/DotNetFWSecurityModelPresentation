using System;

namespace Sandbox.Host
{
    internal class Data
    {
        private readonly string password;
        private int testField;

        public Data()
        {
            password = "qwerty";
            testField = 777;
        }

        public void DumpPassword()
        {
            Console.WriteLine("Data.password = {0}", password);
        }
    }
}