package net.wagsn.note.storage.db;

import android.content.Context;

import org.greenrobot.greendao.database.Database;

/**
 * 数据库管理器
 * Create bt Wagsn on 2019.6.24.
 */
public class DBManager {

    private static final String DB_NAME = "database";

    private NoteItemDao noteItemDao;

    private DBManager(){
    }

    public static DBManager get() {
        return SingletonHolder.instance;
    }

    private static class SingletonHolder {
        private static DBManager instance = new DBManager();
    }

    public void init(Context context) {
        MigrationOpenHelper helper = new MigrationOpenHelper(context, DB_NAME);
//        DaoMaster.DevOpenHelper helper = new DaoMaster.DevOpenHelper(context, DB_NAME);
        Database db = helper.getWritableDb();
        DaoSession daoSession = new DaoMaster(db).newSession();
        noteItemDao = daoSession.getNoteItemDao();
    }

    public NoteItemDao getNoteItemDao(){
        return noteItemDao;
    }
}
