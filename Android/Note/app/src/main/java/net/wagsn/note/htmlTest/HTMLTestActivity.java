package net.wagsn.note.htmlTest;

import android.annotation.SuppressLint;
import android.app.AlertDialog;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.webkit.JavascriptInterface;
import android.webkit.WebView;
import android.widget.Toast;

import net.wagsn.note.R;

public class HTMLTestActivity extends AppCompatActivity {

    private WebView webView;

    @SuppressLint("SetJavaScriptEnabled")
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.html_test_activity);

        webView = findViewById(R.id.webview);   // 启用javascript
        webView.getSettings().setJavaScriptEnabled(true);
        // 从assets目录下面的加载html
        webView.loadUrl("file:///android_asset/test2.html");
        webView.addJavascriptInterface(HTMLTestActivity.this,"android");

        //无参调用Js点击
        findViewById(R.id.button).setOnClickListener(v -> {
            // 无参数调用
            webView.loadUrl("javascript:javaCallJs()");
        });
        //有参调用Js点击
        findViewById(R.id.button2).setOnClickListener(v -> {
            // 传递参数调用
            webView.loadUrl("javascript:javaCallJsWith(" + "'Java调用js的有参方法'" + ")");
        });
    }

    //由于安全原因 需要加 @JavascriptInterface
    @JavascriptInterface
    public void startFunction(){
        runOnUiThread(() -> Toast.makeText(HTMLTestActivity.this,"Toast",Toast.LENGTH_SHORT).show());
    }

    @JavascriptInterface
    public void startFunction(final String text){
        runOnUiThread(() -> new AlertDialog.Builder(HTMLTestActivity.this).setMessage(text).show());
    }
}
