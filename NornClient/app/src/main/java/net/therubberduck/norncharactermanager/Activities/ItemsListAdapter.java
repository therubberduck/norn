package net.therubberduck.norncharactermanager.Activities;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import net.therubberduck.norncharactermanager.Model.UserItem;
import net.therubberduck.norncharactermanager.R;

import java.util.ArrayList;

public class ItemsListAdapter extends ArrayAdapter<UserItem> {

    ItemsListActivity _itemActivity;

    public ItemsListAdapter(ItemsListActivity itemActivity, ArrayList<UserItem> objects) {
        super(itemActivity, -1, objects);
        _itemActivity = itemActivity;
    }

    @Override
    public int getCount() {
        int count = super.getCount();
        return count;
    }

    @Override
    public View getView(final int position, View convertView, ViewGroup parent) {
        View cell = convertView;
        if(cell == null) {
            LayoutInflater inflater = LayoutInflater.from(getContext());
            cell = inflater.inflate(R.layout.cell_item, parent, false);
        }

        UserItem value = getItem(position);
        TextView textView = (TextView) cell.findViewById(R.id.txtItemName);
        if(value.isDetailedItem() && !value.Detail.isEmpty()){
            textView.setText(value.Title + "(" + value.Detail + ")");
        }
        else if(value.isDetailedItem()){
            textView.setText(value.Title);
        }
        else {
            textView.setText(value.Detail);
            cell.setBackgroundColor(cell.getResources().getColor(android.R.color.holo_blue_light));
        }

        cell.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                _itemActivity.itemClicked(position);
            }
        });

        return cell;
    }
}
