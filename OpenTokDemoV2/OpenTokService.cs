using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Threading.Tasks;


namespace OpenTokDemoV2
{
    public class OpenTokService
    {
        public Session Session { get; protected set; }
        public OpenTok OpenTok { get; protected set; }

        public OpenTokService()
        {
            int apiKey = 0;
            string apiSecret = null;
            try
            {
                string apiKeyString = "";
                apiSecret = "";
                apiKey = Convert.ToInt32(apiKeyString);
            }

            catch (System.Exception ex)
            {
                if (!(ex is ConfigurationErrorsException || ex is FormatException || ex is OverflowException))
                {
                    throw ex;
                }
            }

            finally
            {
                if (apiKey == 0 || apiSecret == null)
                {
                    Console.WriteLine(
                        "The OpenTok API Key and API Secret were not set in the application configuration. " +
                        "Set the values in App.config and try again. (apiKey = {0}, apiSecret = {1})", apiKey, apiSecret);
                    Console.ReadLine();
                    Environment.Exit(-1);
                }
            }

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            this.OpenTok = new OpenTok(apiKey, apiSecret);

            this.Session = this.OpenTok.CreateSession(mediaMode: MediaMode.ROUTED);
        }
    }
}
