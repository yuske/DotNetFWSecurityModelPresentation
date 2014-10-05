using System;
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
            //permissions.AddPermission(new FileIOPermission(PermissionState.Unrestricted));
            var appDomain = AppDomain.CreateDomain(
                "Sandbox Domain",
                null,
                setup
                , permissions
//                , typeof (AppDomainSandbox).Assembly.Evidence.GetHostEvidence<StrongName>()
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

        public void Test1()
        {
/*
            var i = new Interaction();
            var response = i.Run1();
            Console.WriteLine("Responce: {0}", response);
*/
        }
    }
}