package net.therubberduck.norncharactermanager.Util;

import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.util.Log;

public class ErrorHandler {

    public static void showErrorDialog(Context context, Exception e){
        AlertDialog.Builder alertBuilder = new AlertDialog.Builder(context);
        alertBuilder.setTitle("Error");
        alertBuilder.setMessage(e.getMessage());
        alertBuilder.setNegativeButton("Ok", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                dialog.dismiss();
            }
        });
        alertBuilder.create().show();
        Log.e("norn", "Exception: ", e);
    }
}
