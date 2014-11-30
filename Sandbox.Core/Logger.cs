using System;
using System.IO;
using System.Security;
using System.Security.Permissions;

namespace Sandbox.Core.API
{
    public class Logger
    {
        private readonly string logPath;
        private readonly FileIOPermission logFilePermission;

        [SecuritySafeCritical]
        public Logger(string fileName)
        {
            if (fileName.IndexOf(Path.PathSeparator) >= 0)
            {
                throw new ArgumentException("Must contains only file name", "fileName");
            }

            logPath = Path.Combine(GetLogDirectory(), fileName);
            logFilePermission = new FileIOPermission(FileIOPermissionAccess.Append, logPath);
        }

        [SecuritySafeCritical]
        public void Write(string message)
        {
            WriteInternal(message);
        }

        [SecuritySafeCritical]
        public void Write(string format, params object[] args)
        {
            WriteInternal(String.Format(format, args));
        }

        [SecurityCritical]
        private void WriteInternal(string message)
        {
            logFilePermission.Assert();
            File.AppendAllText(logPath, message + "\n");
        }

        [SecurityCritical]
        private string GetLogDirectory()
        {
            new EnvironmentPermission(PermissionState.Unrestricted).Assert();
            return Path.GetTempPath();
        }
    }
}