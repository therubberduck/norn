using System.Collections.Generic;
using System.Collections.Specialized;
using NornManager.Model;

namespace NornManager.Network
{
    public static class DbTypes
    {
        public static List<ContentType> GetTypes()
        {
            var values = new NameValueCollection();
            values["task"] = "getType";

            return NetworkHandler.MakeGetCall<ContentType>(values);
        }
    }
}
