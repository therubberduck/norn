package net.therubberduck.norncharactermanager.Network;

public abstract class NetRequest {
    public ResultBasic ErrorConveyor;

    public void runOnResponse(String response){
        try {
            onResponse(response);
        }
        catch (Exception e){
            ErrorConveyor.reportError(e);
        }
    }

    public abstract void onResponse(String response) throws Exception;



}
