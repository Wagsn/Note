package net.wagsn.note.application;

import android.app.Application;
import android.util.Log;

import net.wagsn.note.storage.NoteStore;
import net.wagsn.note.storage.db.DBManager;

public class MainApplication extends Application {
    private static final String TAG = "MainApplication";
    @Override
    public void onCreate() {
        super.onCreate();

        Log.d(TAG, "onCreate: 应用初始化");

        DBManager.get().init(this);
        NoteStore.get().init(DBManager.get().getNoteItemDao());
    }
}
