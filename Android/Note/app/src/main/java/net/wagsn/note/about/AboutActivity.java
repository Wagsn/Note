package net.wagsn.note.about;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.webkit.WebView;

import net.wagsn.note.R;

public class AboutActivity extends AppCompatActivity {

    WebView webView;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.about_activity);

        setSupportActionBar(findViewById(R.id.toolbar));

        // TODO 关于页改为XML布局，其它信息采用HTML
        webView = findViewById(R.id.web_view);
        webView.loadUrl("file:///android_asset/about.html");
    }
}
