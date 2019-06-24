package net.wagsn.note.edit;

import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;

import net.wagsn.note.R;

import org.greenrobot.eventbus.EventBus;

public class NoteEditActivity extends AppCompatActivity {
    private static final String TAG = "NoteEditActivity";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.edit_activity);
        Log.d(TAG, "onCreate: ");
        String id = getIntent().getStringExtra("NOTE_ITEM");

        setSupportActionBar(findViewById(R.id.toolbar));

        EventBus.getDefault().post(new NoteShowEvent(id));
        findViewById(R.id.fab).setOnClickListener(view -> {
            EventBus.getDefault().post(new NoteSaveEvent());
        });
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.menu_editor_frag, menu);
        return super.onCreateOptionsMenu(menu);
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        int itemId = item.getItemId();
        if(itemId ==R.id.action_undo){
//            mPerformEdit.undo();
            return true;
        }else if(itemId == R.id.action_redo){
//            mPerformEdit.redo();
            return true;
        }
        return super.onOptionsItemSelected(item);
    }

    public static class NoteSaveEvent {
    }

    public static class NoteShowEvent {
        public String id;

        public NoteShowEvent(String id) {
            this.id = id;
        }
    }
}
