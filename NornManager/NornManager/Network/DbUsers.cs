using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NornManager.Model;

namespace NornManager.Network
{
    public static class DbUsers
    {
        public static void AddContentToUser(string contentid, string userid, string detail)
        {
            var values = new NameValueCollection();
            values["task"] = "addContentToUser";
            values["contentid"] = contentid;
            values["userid"] = userid;
            values["detail"] = detail;

            NetworkHandler.MakeCall(values);
        }

        public static void EditContentOnUser(string id, string detail)
        {
            var values = new NameValueCollection();
            values["task"] = "editContentOnUser";
            values["id"] = id;
            values["detail"] = detail;

            NetworkHandler.MakeCall(values);
        }

        public static List<ContentOnUser> GetUserContent(string userid)
        {
            var values = new NameValueCollection();
            values["task"] = "getContentOnUser";
            values["userid"] = userid;

            return NetworkHandler.MakeGetCall<ContentOnUser>(values);
        }

        public static List<User> GetUsers()
        {
            var values = new NameValueCollection();
            values["task"] = "getUser";

            return NetworkHandler.MakeGetCall<User>(values);
        }

        public static void RemoveContentFromUser(string id)
        {
            var values = new NameValueCollection();
            values["task"] = "removeContentFromUser";
            values["id"] = id;

            NetworkHandler.MakeCall(values);
        }
    }
}
