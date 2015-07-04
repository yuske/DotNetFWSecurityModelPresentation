using System;
using Sandbox.Core.API;
using Sandbox.Plugin;

namespace Sandbox.Host
{
    public enum PluginKind
    {
        Interaction,
        ExceptionFilterAttackSample
    }

    public class PluginFactory
    {
        public static IPlugin Create(PluginKind plugin)
        {
            switch (plugin)
            {
                case PluginKind.Interaction:
                    return new Interaction();
                case PluginKind.ExceptionFilterAttackSample:
                    return new ExceptionFilterAttackSample();
                default:
                    throw new ArgumentOutOfRangeException("plugin", plugin, null);
            }
        }
    }
}