using System.Configuration;
using System.Net;
using IInfoProxy;

namespace ReadInformation
{
    public class InfoProxy : IMainInfoProxy
    {
        private static NetworkCredential GetCredential
        {
            get
            {
                return new NetworkCredential(UserName, Password, Domain);
            }
        }

        public WebRequest GetProxy(WebRequest request)
        {
            request.Proxy = WebRequest.DefaultWebProxy;
            request.Credentials = GetCredential;
            request.Proxy.Credentials = GetCredential;
            return request;
        }
        public static string UserName
        {
            get
            {
                return ConfigurationManager.AppSettings["UserName"];
            }
        }
        public static string Password
        {
            get
            {
                return ConfigurationManager.AppSettings["Password"];
            }
        }
        public static string Domain
        {
            get
            {
                return ConfigurationManager.AppSettings["Domain"];
            }
        }

        public static string ProxyServiceConfig
        {
            get
            {
                return ConfigurationManager.AppSettings["ProxyService"];
            }
        }
    }
}
