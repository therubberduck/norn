package net.therubberduck.norncharactermanager;

public class Application extends android.app.Application{
    private static Application _instance;

    public static Application getInstance(){
        if(_instance == null){
            _instance = new Application();
        }
        return _instance;
    }
}
