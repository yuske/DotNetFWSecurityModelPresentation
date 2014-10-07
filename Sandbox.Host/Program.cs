namespace Sandbox.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            var appDomainSandbox = AppDomainSandbox.CreateInstance();

            Utils.PrintAppDomainInfo();
            appDomainSandbox.PrintAppDomainInfo();

            Utils.AccessToPrivateFields();
            appDomainSandbox.AccessToPrivateFields();

            //appDomainSandbox.LoadPlugin();

            //Utils.PrintAppDomainInfo();
            //appDomainSandbox.PrintAppDomainInfo();
        }
    }
}
