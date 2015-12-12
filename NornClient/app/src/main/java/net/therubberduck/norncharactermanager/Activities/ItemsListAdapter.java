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
    ItemListCell[] _cells;

    public ItemsListAdapter(ItemsListActivity itemActivity, ArrayList<UserItem> objects) {
        super(itemActivity, -1, objects);
        _itemActivity = itemActivity;
        _cells = new ItemListCell[objects.size()];
    }

    @Override
    public void remove(UserItem object) {
        super.remove(object);
        _cells = new ItemListCell[super.getCount()];
    }

    @Override
    public int getCount() {
        int count = super.getCount();
        return count;
    }

    @Override
    public View getView(final int position, View convertView, ViewGroup parent) {
        ItemListCell cell = _cells[position];
        if(cell == null){
            UserItem value = getItem(position);
            _cells[position] = new ItemListCell(_itemActivity, parent, value);
            cell = _cells[position];
        }

        return cell.view;
    }
}
