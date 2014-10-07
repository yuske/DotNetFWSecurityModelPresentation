using System;
using Sandbox.Core;

namespace Sandbox.Plugin
{
    public class Interaction
    {
        private readonly WebClient webClient = new WebClient();

        public void Run()
        {
            Get("http://www.ptsecurity.com");
            Get("https://www.google.ru");
        }

        private void Get(string url)
        {
            Console.WriteLine("==========================================================="); 
            try
            {
                var body = webClient.Get(url);
                Console.WriteLine("Success request url \"{0}\"", url);
                Console.WriteLine(body);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error requst url \"{0}\":", url);
                Console.WriteLine(exception.Message);
            }

            Console.WriteLine("===========================================================");
            Console.WriteLine();
        }
    }
}
