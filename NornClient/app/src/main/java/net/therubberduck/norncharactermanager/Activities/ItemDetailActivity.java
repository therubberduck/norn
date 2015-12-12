package net.therubberduck.norncharactermanager.Activities;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.text.Spannable;
import android.text.method.LinkMovementMethod;
import android.text.style.ClickableSpan;
import android.util.Log;
import android.view.View;
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

        final Activity context = this;
        NetworkHandler handler = NetworkHandler.get(this);
        handler.getItem(itemId, new Result<DetailedItem>(this) {
            @Override
            protected void resultReceived(DetailedItem result) {
                txtItemName.setText(result.Title);

                txtContent.setText(result.getLinkedContentText(context));
                txtContent.setMovementMethod(LinkMovementMethod.getInstance());
            }

            @Override
            public void errorOccured(Exception e) {
                Log.e("norn", "Error Caught: ", e);
            }
        });
    }
}
