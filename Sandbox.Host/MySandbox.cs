using System;
using System.Net;
using System.Security;
using System.Security.Permissions;
using System.Security.Policy;

namespace Sandbox.Host
{
    internal class MySandbox : MarshalByRefObject
    {
        public static MySandbox CreateInstance()
        {
            var setup = new AppDomainSetup { ApplicationBase = Environment.CurrentDirectory };
            var permissions = new PermissionSet(null);
            permissions.AddPermission(new SecurityPermission(SecurityPermissionFlag.Execution));
            permissions.AddPermission(new WebPermission(NetworkAccess.Connect, "http://www.ptsecurity.com"));
            var appDomain = AppDomain.CreateDomain(
                "Sandbox Domain"
                , null
                , setup
                , permissions
                , typeof(Core.API.WebClient).Assembly.Evidence.GetHostEvidence<StrongName>()
                , typeof(VBLibrary.ExceptionHandler).Assembly.Evidence.GetHostEvidence<StrongName>()
            );

            return (MySandbox)(Activator.CreateInstance(
                appDomain, "Sandbox.Host", "Sandbox.Host.MySandbox").Unwrap());
        }

        public void LoadPlugin(PluginKind pluginKind)
        {
            try
            {
                var plugin = PluginFactory.Create(pluginKind);
                plugin.Run();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
                Console.WriteLine();
            }
        }

        public void PrintAppDomainInfo()
        {
            Utils.PrintAppDomainInfo(typeof(MySandbox));
        }
    }
}