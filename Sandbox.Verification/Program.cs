using System;

namespace Sandbox.Verification
{
    class Program
    {
        static void Main(string[] args)
        {
            var appDomainSandbox = MySandbox.CreateInstance();

            AccessToPrivateFields();
            appDomainSandbox.AccessToPrivateFields();

            Utils.PrintAppDomainInfo(typeof(MySandbox));
            appDomainSandbox.PrintAppDomainInfo();
        }

        public static void AccessToPrivateFields()
        {
            Console.WriteLine("===========================================================");
            try
            {
                Console.WriteLine("Try get access to private fields in \"{0}\" domain.",
                    AppDomain.CurrentDomain.FriendlyName);
                var data = new Data();
                data.DumpPassword();
                var proxy = DataProxy.Create(data);
                proxy.Password = "my-password";
                data.DumpPassword();
                Console.WriteLine("DataProxy.TestField = {0}", proxy.TestField);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            Console.WriteLine("===========================================================");
            Console.WriteLine();
        }
    }
}
