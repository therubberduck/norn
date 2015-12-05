using Newtonsoft.Json;
using NornManager.Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NornManager.Network
{
    public static class NetworkHandler
    {
        public static List<T> MakeGetCall<T>(NameValueCollection values)
        {
            using (var client = new WebClient())
            {
                var response = client.UploadValues("http://therubberduck.net/norn/index.php", values);
                var responseString = Encoding.Default.GetString(response);
                return JsonConvert.DeserializeObject<List<T>>(responseString);
            }
        }

        public static void MakeCall(NameValueCollection values)
        {
            using (var client = new WebClient())
            {
                var response = client.UploadValues("http://therubberduck.net/norn/index.php", values);
            }
        }
    }
}
