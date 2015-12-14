package net.therubberduck.norncharactermanager.Activities;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.LinearLayout;
import android.widget.TextView;

import net.therubberduck.norncharactermanager.Model.UserItem;
import net.therubberduck.norncharactermanager.R;

public class ItemListCell {
    public View view;

    LinearLayout _lnrContainer;
    TextView _textView;
    Button _btnDeleteButton;

    public ItemListCell(final ItemsListActivity activity, ViewGroup parent, final UserItem value) {
        LayoutInflater inflater = LayoutInflater.from(activity);
        view = inflater.inflate(R.layout.cell_item, parent, false);

        _lnrContainer = (LinearLayout) view.findViewById(R.id.lnrContainer);
        _textView = (TextView) view.findViewById(R.id.txtItemName);
        _btnDeleteButton = (Button) view.findViewById(R.id.btnDeleteButton);

        String displayText = "";
        if(value.isDetailedItem() && !value.Detail.isEmpty()){
            displayText = value.Title + "(" + value.Detail + ")";
        }
        else if(value.isDetailedItem()){
            displayText = value.Title;
        }
        else {
            displayText = value.Detail;
            _lnrContainer.setBackgroundColor(view.getResources().getColor(R.color.accent_light));
        }
        if(!value.Number.equals("1")){
            displayText = value.Number + " " + displayText;
        }

        _textView.setText(displayText);

        _textView.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                activity.itemClicked(value);
            }
        });

        _btnDeleteButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                activity.deleteItem(value);
            }
        });
    }
}
