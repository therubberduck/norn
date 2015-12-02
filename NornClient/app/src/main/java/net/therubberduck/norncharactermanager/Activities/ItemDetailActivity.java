package net.therubberduck.norncharactermanager.Activities;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.widget.TextView;

import net.therubberduck.norncharactermanager.Model.DetailedItem;
import net.therubberduck.norncharactermanager.Network.NetworkHandler;
import net.therubberduck.norncharactermanager.Network.Result;
import net.therubberduck.norncharactermanager.R;

public class ItemDetailActivity extends BaseActivity {

    TextView txtItemName;
    TextView txtContent;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_itemdetail);

        txtItemName = findTextView(R.id.txtItemName);
        txtContent = findTextView(R.id.txtItemContent);

        Intent intent = getIntent();
        String itemId = intent.getStringExtra("itemId");

        NetworkHandler handler = new NetworkHandler(this);
        handler.getItem(itemId, new Result<DetailedItem>(this) {
            @Override
            protected void resultReceived(DetailedItem result) {
                txtItemName.setText(result.Title);
                txtContent.setText(result.Content);
            }

            @Override
            public void errorOccured(Exception e) {
                Log.e("norn", "Error Caught: ", e);
            }
        });
    }
}
