package net.therubberduck.norncharactermanager.Activities;

import android.net.wifi.p2p.WifiP2pManager;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import net.therubberduck.norncharactermanager.Model.User;
import net.therubberduck.norncharactermanager.R;

import java.util.ArrayList;

public class UserListAdapter extends ArrayAdapter<User> {

    UserActivity _userActivity;

    public UserListAdapter(UserActivity userActivity, ArrayList<User> objects) {
        super(userActivity, -1, objects);
        _userActivity = userActivity;
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
            cell = inflater.inflate(R.layout.cell_user, parent, false);
        }

        User value = getItem(position);
        TextView textView = (TextView) cell.findViewById(R.id.txtUserName);
        textView.setText(value.Name);
        TextView detailView = (TextView) cell.findViewById(R.id.txtDetail);
        detailView.setText(value.Detail);

        cell.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                _userActivity.itemClicked(position);
            }
        });

        return cell;
    }

}
