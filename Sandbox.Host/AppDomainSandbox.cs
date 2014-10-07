using System;
using System.Net;
using System.Security;
using System.Security.Permissions;
using System.Security.Policy;
using Sandbox.Plugin;

namespace Sandbox.Host
{
    internal class AppDomainSandbox : MarshalByRefObject
    {
        public static AppDomainSandbox CreateInstance()
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
                , typeof(Core.WebClient).Assembly.Evidence.GetHostEvidence<StrongName>()
            );

            return (AppDomainSandbox)(Activator.CreateInstance(
                appDomain, "Sandbox.Host", "Sandbox.Host.AppDomainSandbox").Unwrap());
        }

        public void PrintAppDomainInfo()
        {
            Utils.PrintAppDomainInfo();
        }

        public void AccessToPrivateFields()
        {
            Utils.AccessToPrivateFields();
        }

        public void LoadPlugin()
        {
            try
            {
                var plugin = new Interaction();
                plugin.Run();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
                Console.WriteLine();
            }
        }
    }
}