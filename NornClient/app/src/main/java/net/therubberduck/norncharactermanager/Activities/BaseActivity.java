package net.therubberduck.norncharactermanager.Activities;

import android.app.Activity;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.TextView;

public class BaseActivity extends Activity {


    protected EditText findEditText(int id){
        return (EditText) findViewById(id);
    }

    protected ListView findListView(int id){
        return (ListView) findViewById(id);
    }

    protected TextView findTextView(int id){
        return (TextView) findViewById(id);
    }
}
