using System;
using System.Security;
using System.Security.Permissions;

namespace Sandbox.Verification
{
    internal class MySandbox : MarshalByRefObject
    {
        public static MySandbox CreateInstance()
        {
            var setup = new AppDomainSetup { ApplicationBase = Environment.CurrentDirectory };
            var permissions = new PermissionSet(null);
            permissions.AddPermission(new SecurityPermission(SecurityPermissionFlag.Execution));
            var appDomain = AppDomain.CreateDomain(
                "Sandbox Domain"
                , null
                , setup
                , permissions
            );

            return (MySandbox)(Activator.CreateInstance(
                appDomain, "Sandbox.Verification", "Sandbox.Verification.MySandbox").Unwrap());
        }

        public void AccessToPrivateFields()
        {
            Program.AccessToPrivateFields();
        }

        public void PrintAppDomainInfo()
        {
            Utils.PrintAppDomainInfo(typeof(MySandbox));
        }
    }
}