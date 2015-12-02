package net.therubberduck.norncharactermanager.Model;

import org.json.JSONException;
import org.json.JSONObject;

public class DetailedItem {
    public String Id;
    public String TypeId;
    public String Title;
    public String Content;
    public boolean Visible;

    public static DetailedItem create(JSONObject itemJson) throws JSONException {
        DetailedItem item = new DetailedItem();
        item.Id = itemJson.getString("id");
        item.TypeId = itemJson.getString("typeid");
        item.Title = itemJson.getString("title");
        item.Content = itemJson.getString("content");
        item.Visible = itemJson.getString("visible").equals("1");
        return item;
    }
}
