namespace Sandbox.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            var appDomainSandbox = MySandbox.CreateInstance();

            //appDomainSandbox.LoadPlugin(PluginKind.Interaction);
            appDomainSandbox.LoadPlugin(PluginKind.ExceptionFilterAttackSample);

            Utils.PrintAppDomainInfo(typeof(MySandbox));
            appDomainSandbox.PrintAppDomainInfo();
        }
    }
}
