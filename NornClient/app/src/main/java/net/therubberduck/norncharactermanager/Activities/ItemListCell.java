package net.therubberduck.norncharactermanager.Activities;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import net.therubberduck.norncharactermanager.Model.UserItem;
import net.therubberduck.norncharactermanager.R;

public class ItemListCell {
    public View view;

    TextView textView;
    ImageView imgDeleteButton;

    public ItemListCell(final ItemsListActivity activity, ViewGroup parent, final UserItem value) {
        LayoutInflater inflater = LayoutInflater.from(activity);
        view = inflater.inflate(R.layout.cell_item, parent, false);

        textView = (TextView) view.findViewById(R.id.txtItemName);
        imgDeleteButton = (ImageView) view.findViewById(R.id.imgDeleteButton);

        String displayText = "";
        if(value.isDetailedItem() && !value.Detail.isEmpty()){
            displayText = value.Title + "(" + value.Detail + ")";
        }
        else if(value.isDetailedItem()){
            displayText = value.Title;
        }
        else {
            displayText = value.Detail;
            view.setBackgroundColor(view.getResources().getColor(android.R.color.holo_blue_light));
        }
        if(!value.Number.equals("1")){
            displayText = value.Number + " " + displayText;
        }

        textView.setText(displayText);

        textView.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                activity.itemClicked(value);
            }
        });

        imgDeleteButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                activity.deleteItem(value);
            }
        });
    }
}
