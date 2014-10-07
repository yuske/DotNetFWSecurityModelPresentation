using System;
using System.Reflection;

namespace Sandbox.Host
{
    internal class Utils
    {
        public static void PrintAppDomainInfo(Type codeLayerType = null)
        {
            Console.WriteLine("===========================================================");
            var currentDomain = AppDomain.CurrentDomain;
            Console.WriteLine("Info about \"{0}\" domain:", currentDomain.FriendlyName);
            Console.WriteLine("\tIs Fully Trusted: {0}", currentDomain.IsFullyTrusted);

            if (codeLayerType == null)
            {
                codeLayerType = typeof(AppDomainSandbox);
            }

            var codeLayer = codeLayerType.IsSecurityTransparent ? "Transparent" :
                codeLayerType.IsSecuritySafeCritical ? "SafeCritical" : "Critical";
            Console.WriteLine("\tCode in \"{0}\" class belong to {1} layer", codeLayerType.Name, codeLayer);

            var assemblies = currentDomain.GetAssemblies();
            if (assemblies.Length == 0)
            {
                Console.WriteLine("\tNo assemblies loaded in this domain.");
            }
            else
            {
                Console.WriteLine("\t{0} assemblies loaded in this domain.", assemblies.Length);
                foreach (var assembly in assemblies)
                {
                    var simpleName = new AssemblyName(assembly.FullName).Name;
                    Console.WriteLine("\t\"{0}\" Is Fully Trusted: {1}", simpleName, assembly.IsFullyTrusted);
                }
            }

            Console.WriteLine("===========================================================");
            Console.WriteLine();
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