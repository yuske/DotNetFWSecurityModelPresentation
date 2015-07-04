using System;
using System.Diagnostics;

namespace Sandbox.Core.API
{
    public class ExecutionHelper
    {
        private readonly string path;

        public ExecutionHelper(string path)
        {
            this.path = path;
        }

        public bool Execute()
        {
            try
            {
                Process.Start(path);
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }

        public Func<bool> GetExecuteFunc()
        {
            return () => { return Execute(); };
        }
    }
}