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
        public static List<Content> GetContent()
        {
            var values = new NameValueCollection();
            values["task"] = "getContent";

            return MakeGetCall<Content>(values);
        }

        public static Content AddContent(string title, string content, bool visible)
        {
            var values = new NameValueCollection();
            values["task"] = "addContent";
            values["typeid"] = "1";
            values["title"] = title;
            values["content"] = content;
            values["visible"] = visible.ToString();

            var newContent = MakeGetCall<Content>(values);

            return newContent.First();
        }

        public static void EditContent(string id, string title, string content, bool visible)
        {
            var values = new NameValueCollection();
            values["task"] = "editContent";
            values["id"] = id;
            values["typeid"] = "1";
            values["title"] = title;
            values["content"] = content;
            values["visible"] = visible.ToString();

            MakeCall(values);
        }

        public static void RemoveContent(string id)
        {
            var values = new NameValueCollection();
            values["task"] = "deleteContent";
            values["id"] = id;

            MakeCall(values);
        }

        public static List<User> GetUsers()
        {
            var values = new NameValueCollection();
            values["task"] = "getUser";

            return MakeGetCall<User>(values);
        }

        public static List<ContentOnUser> GetUserContent(string userid)
        {
            var values = new NameValueCollection();
            values["task"] = "getContentOnUser";
            values["userid"] = userid;

            return MakeGetCall<ContentOnUser>(values);
        }

        public static void AddContentToUser(string contentid, string userid, string detail)
        {
            var values = new NameValueCollection();
            values["task"] = "addContentToUser";
            values["contentid"] = contentid;
            values["userid"] = userid;
            values["detail"] = detail;

            MakeCall(values);
        }

        public static void EditContentOnUser(string id, string detail)
        {
            var values = new NameValueCollection();
            values["task"] = "editContentOnUser";
            values["id"] = id;
            values["detail"] = detail;

            MakeCall(values);
        }

        public static void RemoveContentFromUser(string id)
        {
            var values = new NameValueCollection();
            values["task"] = "removeContentFromUser";
            values["id"] = id;

            MakeCall(values);
        }

        private static List<T> MakeGetCall<T>(NameValueCollection values)
        {
            using (var client = new WebClient())
            {
                var response = client.UploadValues("http://therubberduck.net/norn/index.php", values);
                var responseString = Encoding.Default.GetString(response);
                return JsonConvert.DeserializeObject<List<T>>(responseString);
            }
        }

        private static void MakeCall(NameValueCollection values)
        {
            using (var client = new WebClient())
            {
                var response = client.UploadValues("http://therubberduck.net/norn/index.php", values);
            }
        }
    }
}
