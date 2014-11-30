using System;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace Sandbox.Core.API
{
    public class WebClient
    {
        private readonly Logger logger = new Logger("_log.txt");

        public WebClient()
        {
            logger.Write("WebClient.ctor()");
        }

        public string Get(string url)
        {
            logger.Write("Get \"{0}\" url...", url);

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
    }
}