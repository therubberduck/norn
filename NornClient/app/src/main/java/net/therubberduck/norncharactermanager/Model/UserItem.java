package net.therubberduck.norncharactermanager.Model;

import org.json.JSONException;
import org.json.JSONObject;

public class UserItem implements Comparable<UserItem> {
    public String Id;
    public String ContentId;
    public String Title;
    public String Detail;
    public String Number;

    public static UserItem create(JSONObject itemJson) throws JSONException {
        UserItem item = new UserItem();
        item.Id = itemJson.getString("id");
        item.ContentId = itemJson.getString("contentid");
        item.Title = itemJson.getString("title");
        item.Detail = itemJson.getString("detail");
        item.Number = itemJson.getString("number");
        return item;
    }

    public boolean isDetailedItem(){
        return !ContentId.equals("7") && !ContentId.equals("8");
    }

    @Override
    public int compareTo(UserItem another) {
        String myTitle = Title;
        String yourTitle = another.Title;
        if(ContentId.equals("8") || ContentId.equals("7")){
            myTitle = Detail;
        }
        if(another.ContentId.equals("8") || another.ContentId.equals("7")){
            yourTitle = another.Detail;
        }
        if(Title.equals(another.Title)){
            myTitle = Detail;
            yourTitle = another.Detail;
        }
        return myTitle.compareTo(yourTitle);
    }
}
