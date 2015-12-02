package net.therubberduck.norncharactermanager.Activities;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.widget.ListView;

import net.therubberduck.norncharactermanager.Model.UserItem;
import net.therubberduck.norncharactermanager.Network.NetworkHandler;
import net.therubberduck.norncharactermanager.Network.Result;
import net.therubberduck.norncharactermanager.R;

import java.util.ArrayList;

public class ItemsListActivity extends BaseActivity {

    ListView _lstItems;
    ItemsListAdapter _listAdapter;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_itemslist);

        _lstItems = findListView(R.id.lstItems);

        Intent intent = getIntent();
        String userId = intent.getStringExtra("userId");

        NetworkHandler handler = new NetworkHandler(this);
        final ItemsListActivity activity = this;
        handler.getItemsFromUserId(userId, new Result<ArrayList<UserItem>>(this) {
            @Override
            protected void resultReceived(ArrayList<UserItem> result) {
                _listAdapter = new ItemsListAdapter(activity, result);
                _lstItems.setAdapter(_listAdapter);
            }

            @Override
            public void errorOccured(Exception e) {
                Log.e("norn", "Error Caught: ", e);
            }
        });
    }

    public void itemClicked(int position) {
        UserItem item = _listAdapter.getItem(position);
        if(!item.ContentId.equals("8") && !item.ContentId.equals("7")){
            Intent intent = new Intent(this, ItemDetailActivity.class);
            intent.putExtra("itemId", item.ContentId);
            startActivity(intent);
        }
    }
}
