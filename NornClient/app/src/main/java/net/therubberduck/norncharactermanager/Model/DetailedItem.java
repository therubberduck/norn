package net.therubberduck.norncharactermanager.Model;

import android.app.Activity;
import android.content.Intent;
import android.text.Spannable;
import android.text.style.ClickableSpan;
import android.util.Log;
import android.view.View;

import net.therubberduck.norncharactermanager.Activities.ItemDetailActivity;
import net.therubberduck.norncharactermanager.Network.NetworkHandler;
import net.therubberduck.norncharactermanager.Network.Result;

import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;

public class DetailedItem {
    public String Id;
    public String TypeId;
    public String Title;
    public String Content;
    public boolean Visible;

    public static DetailedItem create(JSONObject itemJson) throws JSONException {
        DetailedItem item = new DetailedItem();
        item.Id = itemJson.getString("id");
        item.TypeId = itemJson.getString("typeid");
        item.Title = itemJson.getString("title");
        item.Content = itemJson.getString("content");
        item.Visible = itemJson.getString("visible").equals("1");
        return item;
    }

    public Spannable getLinkedContentText(final Activity context) {
        ArrayList<LinkInfo> links = new ArrayList<>();

        String spanText = Content;
        while(true){
            int startOfLink = spanText.indexOf("<");
            int divider = spanText.indexOf(":");
            int endOfLink = spanText.indexOf(">");
            if(startOfLink == -1 || divider == -1 || endOfLink == -1){
                break;
            }
            String itemTitle = spanText.substring(startOfLink + 1, divider);
            String linkText = spanText.substring(divider + 1, endOfLink);
            String fullText = spanText.substring(startOfLink, endOfLink + 1);
            spanText = spanText.replaceFirst(fullText, linkText);

            links.add(new LinkInfo(startOfLink, startOfLink + linkText.length(), itemTitle));
        }
        Spannable span = Spannable.Factory.getInstance().newSpannable(spanText);

        for(final LinkInfo linkInfo : links){
            span.setSpan(new ClickableSpan() {
                @Override
                public void onClick(View widget) {
                    NetworkHandler networkHandler = NetworkHandler.get(context);
                    networkHandler.getItemFromTitle(linkInfo.LinkContent, new Result<DetailedItem>(context) {
                        @Override
                        protected void resultReceived(DetailedItem result) {
                            Intent intent = new Intent(context, ItemDetailActivity.class);
                            intent.putExtra("itemId", result.Id);
                            context.startActivity(intent);
                        }

                        @Override
                        protected void errorOccured(Exception e) {
                            Log.e("norn", "Error caught: ", e);
                        }
                    });
                }
            }, linkInfo.StartPosition, linkInfo.EndPosition, Spannable.SPAN_EXCLUSIVE_EXCLUSIVE);
        }
        return span;
    }

    private class LinkInfo{
        public int StartPosition;
        public int EndPosition;
        public String LinkContent;

        public LinkInfo(int startPosition, int endPosition, String linkContent){
            StartPosition = startPosition;
            EndPosition = endPosition;
            LinkContent = linkContent;
        }
    }
}
