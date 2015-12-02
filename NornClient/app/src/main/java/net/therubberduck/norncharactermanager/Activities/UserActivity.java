package net.therubberduck.norncharactermanager.Activities;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.widget.ListView;

import net.therubberduck.norncharactermanager.Model.User;
import net.therubberduck.norncharactermanager.Network.NetworkHandler;
import net.therubberduck.norncharactermanager.Network.Result;
import net.therubberduck.norncharactermanager.R;

import java.util.ArrayList;

public class UserActivity extends BaseActivity {

    ListView _lstUsers;
    UserListAdapter _listAdapter;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_user);

        _lstUsers = findListView(R.id.lstUsers);

        final UserActivity activity = this;

        NetworkHandler handler = new NetworkHandler(this);
        handler.getUsers(new Result<ArrayList<User>>(this) {
            @Override
            protected void resultReceived(ArrayList<User> result) {
                _listAdapter = new UserListAdapter(activity, result);
                _lstUsers.setAdapter(_listAdapter);
            }

            @Override
            public void errorOccured(Exception e) {
                Log.e("norn", "Error Caught: ", e);
            }
        });
    }

    public void itemClicked(int position) {
        User user = _listAdapter.getItem(position);
        Intent intent = new Intent(this, ItemsListActivity.class);
        intent.putExtra("userId", user.Id);
        startActivity(intent);
    }
}
