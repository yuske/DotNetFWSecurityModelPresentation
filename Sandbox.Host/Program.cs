namespace Sandbox.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            Utils.PrintAppDomainInfo();
            var appDomainSandbox = AppDomainSandbox.CreateInstance();
            appDomainSandbox.PrintAppDomainInfo();

            Utils.AccessToPrivateFields();
            appDomainSandbox.AccessToPrivateFields();
        }
    }
}
