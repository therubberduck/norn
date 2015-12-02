package net.therubberduck.norncharactermanager.Network;

import android.app.Activity;

public abstract class ResultBasic {

    protected Activity Context;

    public ResultBasic (Activity activity){

        Context = activity;
    }

    public void reportError(final Exception e){
        Context.runOnUiThread(new Runnable() {
            @Override
            public void run() {
                errorOccured(e);
            }
        });
    }

    protected abstract void errorOccured(Exception e);
}
