package net.wagsn.note.about;

import android.annotation.SuppressLint;
import android.content.pm.PackageInfo;
import android.content.pm.PackageManager;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.webkit.JavascriptInterface;
import android.webkit.WebView;

import net.wagsn.note.R;

public class AboutActivity extends AppCompatActivity {

    WebView webView;

    @SuppressLint("JavascriptInterface")
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.about_activity);

        setSupportActionBar(findViewById(R.id.toolbar));

        // TODO 关于页改为XML布局，其它信息采用HTML
        webView = findViewById(R.id.web_view);
        webView.loadUrl("file:///android_asset/about.html");
        webView.getSettings().setJavaScriptEnabled(true);
        webView.addJavascriptInterface(AboutActivity.this,"note");
    }

    @JavascriptInterface
    public String version(){
        PackageManager packageManager=this.getPackageManager();
        PackageInfo packageInfo;
        String versionName="";
        try {
            packageInfo=packageManager.getPackageInfo(this.getPackageName(),0);
            versionName=packageInfo.versionName;
        } catch (PackageManager.NameNotFoundException e) {
            e.printStackTrace();
        }
        return versionName;
    }
}
