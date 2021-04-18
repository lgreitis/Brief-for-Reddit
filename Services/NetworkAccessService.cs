using System;
using System.Net.Http;
using System.Threading.Tasks;

using Tizen.Network.Connection;

namespace Brief_for_Reddit.Services
{
    class NetworkAccessService
    {
        public async Task<string> RedditWebRequest(string after)
        {
            ConnectionItem connection = ConnectionManager.CurrentConnection;

            if (connection.Type == ConnectionType.Disconnected)
            {
                // TODO: There is no available connectivity as now
                return "lmao you made poopoo";
            }

            HttpClientHandler handler = null;
            HttpClient client = null;

            try
            {
                handler = new HttpClientHandler();
                if (connection.Type == ConnectionType.Ethernet)
                {
                    var proxy = ConnectionManager.GetProxy(AddressFamily.IPv4);
                    //handler.Proxy = new WebProxy(proxy, true);
                }

                client = new HttpClient(handler);
                string response = null;

                if (after == null)
                {
                    response = await client.GetStringAsync("https://www.reddit.com/.json");
                }
                else
                {
                    response = await client.GetStringAsync($"https://www.reddit.com/.json?after={after}");
                }

                return response;
            }
            finally
            {
                client?.Dispose();
                handler?.Dispose();
            }
        }
    }
    public static class NetworkHandler
    {
        public static HttpClientHandler GetHandler()
        {
            ConnectionItem connection = ConnectionManager.CurrentConnection;

            HttpClientHandler handler = new HttpClientHandler();
            if (connection.Type == ConnectionType.Ethernet)
            {
                var proxy = ConnectionManager.GetProxy(AddressFamily.IPv4);
                //handler.Proxy = new WebProxy(proxy, true);
            }

            return handler;
        }
    }
}
