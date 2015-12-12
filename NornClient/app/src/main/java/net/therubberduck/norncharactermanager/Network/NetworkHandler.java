package net.therubberduck.norncharactermanager.Network;

import android.content.Context;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.error.AuthFailureError;
import com.android.volley.error.VolleyError;
import com.android.volley.request.StringRequest;
import com.android.volley.toolbox.Volley;

import net.therubberduck.norncharactermanager.Model.DetailedItem;
import net.therubberduck.norncharactermanager.Model.UserItem;
import net.therubberduck.norncharactermanager.Model.User;

import org.json.JSONArray;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.Map;

public class NetworkHandler {
    private RequestQueue _queue;

    public NetworkHandler(Context context){
        _queue = Volley.newRequestQueue(context);
    }

    public void getItem(String itemId, final Result<DetailedItem> resultConveyor) {
        Task params = new Task("getContent");
        params.put("id", itemId);

        makeQuery(params, resultConveyor, new NetRequest() {
            @Override
            public void onResponse(String response) throws Exception {
                JSONArray jsonArray = new JSONArray(response);
                if(jsonArray.length() > 0) {
                    JSONObject jsonItem = jsonArray.getJSONObject(0);
                    DetailedItem item = DetailedItem.create(jsonItem);
                    resultConveyor.sendResult(item);
                }
                else {
                    resultConveyor.reportError(new Exception("No item matching itemId returned from web service"));
                }
            }
        });
    }

    public void getItemFromTitle(String title, final Result<DetailedItem> resultConveyor) {
        Task params = new Task("getContent");
        params.put("title", title);

        makeQuery(params, resultConveyor, new NetRequest() {
            @Override
            public void onResponse(String response) throws Exception {
                JSONArray jsonArray = new JSONArray(response);
                if(jsonArray.length() > 0) {
                    JSONObject jsonItem = jsonArray.getJSONObject(0);
                    DetailedItem item = DetailedItem.create(jsonItem);
                    resultConveyor.sendResult(item);
                }
                else {
                    resultConveyor.reportError(new Exception("No item matching title returned from web service"));
                }
            }
        });
    }

    public void getItemsFromUserId(String userId, final Result<ArrayList<UserItem>> resultConveyor) {
        Task params = new Task("getContentOnUser");
        params.put("userid", userId);

        makeQuery(params, resultConveyor, new NetRequest() {
            @Override
            public void onResponse(String response) throws Exception {
                ArrayList<UserItem> items = new ArrayList<UserItem>();

                JSONArray jsonUsers = new JSONArray(response);
                for (int i = 0; i < jsonUsers.length(); i++) {
                    JSONObject jsonItem = jsonUsers.getJSONObject(i);
                    UserItem item = UserItem.create(jsonItem);
                    items.add(item);
                }

                resultConveyor.sendResult(items);
            }
        });
    }

    public void getUsers(final Result<ArrayList<User>> resultConveyor){
        Task params = new Task("getUser");

        makeQuery(params, resultConveyor, new NetRequest() {
            @Override
            public void onResponse(String response) throws Exception {
                ArrayList<User> users = new ArrayList<User>();

                JSONArray jsonUsers = new JSONArray(response);
                for(int i = 0; i < jsonUsers.length(); i++){
                    JSONObject jsonUser = jsonUsers.getJSONObject(i);
                    User user = User.create(jsonUser);
                    users.add(user);
                }

                resultConveyor.sendResult(users);
            }
        });
    }

    private void makeQuery(final Map<String, String> params, final ResultBasic errorConveyor, final NetRequest requestConveyor){
        String url = "http://therubberduck.net/norn/index.php";
        requestConveyor.ErrorConveyor = errorConveyor;
        final StringRequest request = new StringRequest(Request.Method.POST, url,
        new Response.Listener<String>() {
            @Override
            public void onResponse(String response) {
                requestConveyor.runOnResponse(response);
            }
        },
        new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
                errorConveyor.reportError(error);
            }
        }) {
            @Override
            protected Map<String, String> getParams() throws AuthFailureError {
                return params;
            }
        };

        _queue.add(request);
    }
}
