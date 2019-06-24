package net.wagsn.note.storage.db;

import android.content.Context;
import android.database.sqlite.SQLiteDatabase;
import android.util.Log;

import org.greenrobot.greendao.database.Database;

/**
 * 数据库迁移打开助手
 * Create on 2019.6.24.
 */
public class MigrationOpenHelper extends DaoMaster.OpenHelper{

    public MigrationOpenHelper(Context context, String name) {
        super(context, name);
    }

    public MigrationOpenHelper(Context context, String name, SQLiteDatabase.CursorFactory factory) {
        super(context, name, factory);
    }

    @Override
    public void onUpgrade(Database db, int oldVersion, int newVersion) {
        // 操作数据库的更新
        MigrationHelper.get().migrate(db, NoteItemDao.class);
        Log.i("greenDao:", "数据库从("+oldVersion+")更新到("+newVersion+")");
    }
}