using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Security;
using System.Security.Permissions;

namespace Sandbox.Core
{
    public class WebClient
    {
        private const string LogFileName = "log.txt";

        public WebClient()
        {
            WriteToLog("WebClient.ctor()");
        }

        public string Get(string url)
        {
            WriteToLog(String.Format("Get \"{0}\" url...", url));

            var request = WebRequest.Create(url);
            var response = request.GetResponse();
            var streamResponse = response.GetResponseStream();
            Debug.Assert(streamResponse != null);
            var streamReader = new StreamReader(streamResponse);
            var readBuff = new char[256];
            int count = streamReader.Read(readBuff, 0, 256);
            var body = count > 0 ? new String(readBuff, 0, count) : String.Empty;
            streamResponse.Close();
            streamReader.Close();
            response.Close(); 
            return body;
        }

        [SecuritySafeCritical]
        private void WriteToLog(string message)
        {
            new FileIOPermission(PermissionState.Unrestricted).Assert();
            File.AppendAllText(LogFileName, message);
        }
    }
}