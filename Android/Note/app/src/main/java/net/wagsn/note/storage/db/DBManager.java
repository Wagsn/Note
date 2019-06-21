package net.wagsn.note.storage.db;

import android.content.Context;

import net.wagsn.note.storage.db.greendao.DaoMaster;
import net.wagsn.note.storage.db.greendao.DaoSession;
import net.wagsn.note.storage.db.greendao.NoteItemDao;

import org.greenrobot.greendao.database.Database;

public class DBManager {

    private static final String DB_NAME = "database";

    private NoteItemDao noteItemDao;

    public static DBManager get() {
        return SingletonHolder.instance;
    }

    private static class SingletonHolder {
        private static DBManager instance = new DBManager();
    }

    public void init(Context context) {
        DaoMaster.DevOpenHelper helper = new DaoMaster.DevOpenHelper(context, DB_NAME);
        Database db = helper.getWritableDb();
        DaoSession daoSession = new DaoMaster(db).newSession();
        noteItemDao = daoSession.getNoteItemDao();
    }

    public NoteItemDao getNoteItemDao(){
        return noteItemDao;
    }
}
