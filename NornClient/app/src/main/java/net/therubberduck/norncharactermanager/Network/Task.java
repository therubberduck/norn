package net.therubberduck.norncharactermanager.Network;

import java.util.HashMap;

public class Task extends HashMap<String, String> {
    public Task(String task){
        put("task", task);
    }
}
