﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NornManager.Model;

namespace NornManager.Network
{
    public static class DbContent
    {
        public static Content AddContent(string title, string content, bool visible)
        {
            var values = new NameValueCollection();
            values["task"] = "addContent";
            values["typeid"] = "1";
            values["title"] = title;
            values["content"] = content;
            values["visible"] = visible.ToString();

            var newContent = NetworkHandler.MakeGetCall<Content>(values);

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

            NetworkHandler.MakeCall(values);
        }

        public static List<Content> GetContent()
        {
            var values = new NameValueCollection();
            values["task"] = "getContent";

            return NetworkHandler.MakeGetCall<Content>(values);
        }

        public static void RemoveContent(string id)
        {
            var values = new NameValueCollection();
            values["task"] = "deleteContent";
            values["id"] = id;

            NetworkHandler.MakeCall(values);
        }
    }
}
