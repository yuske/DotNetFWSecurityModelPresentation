namespace Sandbox.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            var appDomainSandbox = AppDomainSandbox.CreateInstance();

            Utils.AccessToPrivateFields();
            appDomainSandbox.AccessToPrivateFields();

            //appDomainSandbox.LoadPlugin();

            Utils.PrintAppDomainInfo();
            appDomainSandbox.PrintAppDomainInfo();
        }
    }
}
