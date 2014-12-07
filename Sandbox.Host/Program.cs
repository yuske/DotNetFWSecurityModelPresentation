namespace Sandbox.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            var appDomainSandbox = MySandbox.CreateInstance();

            appDomainSandbox.LoadPlugin();

            Utils.PrintAppDomainInfo(typeof(MySandbox));
            appDomainSandbox.PrintAppDomainInfo();
        }
    }
}
