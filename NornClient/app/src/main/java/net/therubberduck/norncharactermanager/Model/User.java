package net.therubberduck.norncharactermanager.Model;

import org.json.JSONException;
import org.json.JSONObject;

public class User implements Comparable<User> {
    public String Id;
    public String Name;

    public static User create(JSONObject userJson) throws JSONException {
        User user = new User();
        user.Id = userJson.getString("id");
        user.Name = userJson.getString("username");
        return user;
    }

    @Override
    public int compareTo(User another) {
        return Name.compareTo(another.Name);
    }
}
