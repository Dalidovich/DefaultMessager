using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DefaultMessager.DAL.SettingsAWSClient
{
    public class GetRequest
    {
        public async Task<HttpResponseMessage> SendRequest(string feedUri)
        {
            HttpClient client = new HttpClient();
            try
            {
                Uri uri = new Uri(feedUri);
                return await client.GetAsync(feedUri);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                client.Dispose();
            }
            return null;
        }
        public async Task<string> getLink(string feedUri)
        {
            return await (await SendRequest(feedUri)).Content.ReadAsStringAsync();
        }
    }
}
