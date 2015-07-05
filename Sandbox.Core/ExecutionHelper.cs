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
            Process.Start(path);
            return true;
        }

        public Func<bool> GetExecuteFunc()
        {
            return () => { return Execute(); };
        }
    }
}