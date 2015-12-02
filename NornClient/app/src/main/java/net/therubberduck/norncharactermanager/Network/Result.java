package net.therubberduck.norncharactermanager.Network;

import android.app.Activity;

public abstract class Result<T> extends ResultBasic {

    public Result(Activity activity){
        super(activity);
    }

    public void sendResult(final T result){
        Context.runOnUiThread(new Runnable() {
            @Override
            public void run() {
                resultReceived(result);
            }
        });
    }

    protected abstract void resultReceived(T result);
}
