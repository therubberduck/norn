package net.therubberduck.norncharactermanager.Model;

import org.json.JSONException;
import org.json.JSONObject;

public class UserItem {
    public String Id;
    public String ContentId;
    public String Title;
    public String Detail;

    public static UserItem create(JSONObject itemJson) throws JSONException {
        UserItem item = new UserItem();
        item.Id = itemJson.getString("id");
        item.ContentId = itemJson.getString("contentid");
        item.Title = itemJson.getString("title");
        item.Detail = itemJson.getString("detail");
        return item;
    }

    public boolean isDetailedItem(){
        return !ContentId.equals("7") && !ContentId.equals("8");
    }
}
