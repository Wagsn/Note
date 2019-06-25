package net.wagsn.note.storage.db;

import android.database.Cursor;
import android.database.sqlite.SQLiteStatement;

import org.greenrobot.greendao.AbstractDao;
import org.greenrobot.greendao.Property;
import org.greenrobot.greendao.internal.DaoConfig;
import org.greenrobot.greendao.database.Database;
import org.greenrobot.greendao.database.DatabaseStatement;

import net.wagsn.note.entity.NoteItem;

// THIS CODE IS GENERATED BY greenDAO, DO NOT EDIT.
/** 
 * DAO for table "NOTE_ITEM".
*/
public class NoteItemDao extends AbstractDao<NoteItem, String> {

    public static final String TABLENAME = "NOTE_ITEM";

    /**
     * Properties of entity NoteItem.<br/>
     * Can be used for QueryBuilder and for referencing column names.
     */
    public static class Properties {
        public final static Property Id = new Property(0, String.class, "id", true, "ID");
        public final static Property Title = new Property(1, String.class, "title", false, "TITLE");
        public final static Property Content = new Property(2, String.class, "content", false, "CONTENT");
        public final static Property Time = new Property(3, java.util.Date.class, "time", false, "TIME");
        public final static Property CreateTime = new Property(4, java.util.Date.class, "createTime", false, "CREATE_TIME");
        public final static Property UpdateTime = new Property(5, java.util.Date.class, "updateTime", false, "UPDATE_TIME");
        public final static Property IsDelete = new Property(6, boolean.class, "isDelete", false, "IS_DELETE");
        public final static Property DeleteTime = new Property(7, java.util.Date.class, "deleteTime", false, "DELETE_TIME");
    }


    public NoteItemDao(DaoConfig config) {
        super(config);
    }
    
    public NoteItemDao(DaoConfig config, DaoSession daoSession) {
        super(config, daoSession);
    }

    /** Creates the underlying database table. */
    public static void createTable(Database db, boolean ifNotExists) {
        String constraint = ifNotExists? "IF NOT EXISTS ": "";
        db.execSQL("CREATE TABLE " + constraint + "\"NOTE_ITEM\" (" + //
                "\"ID\" TEXT PRIMARY KEY NOT NULL ," + // 0: id
                "\"TITLE\" TEXT," + // 1: title
                "\"CONTENT\" TEXT," + // 2: content
                "\"TIME\" INTEGER," + // 3: time
                "\"CREATE_TIME\" INTEGER," + // 4: createTime
                "\"UPDATE_TIME\" INTEGER," + // 5: updateTime
                "\"IS_DELETE\" INTEGER NOT NULL ," + // 6: isDelete
                "\"DELETE_TIME\" INTEGER);"); // 7: deleteTime
    }

    /** Drops the underlying database table. */
    public static void dropTable(Database db, boolean ifExists) {
        String sql = "DROP TABLE " + (ifExists ? "IF EXISTS " : "") + "\"NOTE_ITEM\"";
        db.execSQL(sql);
    }

    @Override
    protected final void bindValues(DatabaseStatement stmt, NoteItem entity) {
        stmt.clearBindings();
 
        String id = entity.getId();
        if (id != null) {
            stmt.bindString(1, id);
        }
 
        String title = entity.getTitle();
        if (title != null) {
            stmt.bindString(2, title);
        }
 
        String content = entity.getContent();
        if (content != null) {
            stmt.bindString(3, content);
        }
 
        java.util.Date time = entity.getTime();
        if (time != null) {
            stmt.bindLong(4, time.getTime());
        }
 
        java.util.Date createTime = entity.getCreateTime();
        if (createTime != null) {
            stmt.bindLong(5, createTime.getTime());
        }
 
        java.util.Date updateTime = entity.getUpdateTime();
        if (updateTime != null) {
            stmt.bindLong(6, updateTime.getTime());
        }
        stmt.bindLong(7, entity.getIsDelete() ? 1L: 0L);
 
        java.util.Date deleteTime = entity.getDeleteTime();
        if (deleteTime != null) {
            stmt.bindLong(8, deleteTime.getTime());
        }
    }

    @Override
    protected final void bindValues(SQLiteStatement stmt, NoteItem entity) {
        stmt.clearBindings();
 
        String id = entity.getId();
        if (id != null) {
            stmt.bindString(1, id);
        }
 
        String title = entity.getTitle();
        if (title != null) {
            stmt.bindString(2, title);
        }
 
        String content = entity.getContent();
        if (content != null) {
            stmt.bindString(3, content);
        }
 
        java.util.Date time = entity.getTime();
        if (time != null) {
            stmt.bindLong(4, time.getTime());
        }
 
        java.util.Date createTime = entity.getCreateTime();
        if (createTime != null) {
            stmt.bindLong(5, createTime.getTime());
        }
 
        java.util.Date updateTime = entity.getUpdateTime();
        if (updateTime != null) {
            stmt.bindLong(6, updateTime.getTime());
        }
        stmt.bindLong(7, entity.getIsDelete() ? 1L: 0L);
 
        java.util.Date deleteTime = entity.getDeleteTime();
        if (deleteTime != null) {
            stmt.bindLong(8, deleteTime.getTime());
        }
    }

    @Override
    public String readKey(Cursor cursor, int offset) {
        return cursor.isNull(offset + 0) ? null : cursor.getString(offset + 0);
    }    

    @Override
    public NoteItem readEntity(Cursor cursor, int offset) {
        NoteItem entity = new NoteItem( //
            cursor.isNull(offset + 0) ? null : cursor.getString(offset + 0), // id
            cursor.isNull(offset + 1) ? null : cursor.getString(offset + 1), // title
            cursor.isNull(offset + 2) ? null : cursor.getString(offset + 2), // content
            cursor.isNull(offset + 3) ? null : new java.util.Date(cursor.getLong(offset + 3)), // time
            cursor.isNull(offset + 4) ? null : new java.util.Date(cursor.getLong(offset + 4)), // createTime
            cursor.isNull(offset + 5) ? null : new java.util.Date(cursor.getLong(offset + 5)), // updateTime
            cursor.getShort(offset + 6) != 0, // isDelete
            cursor.isNull(offset + 7) ? null : new java.util.Date(cursor.getLong(offset + 7)) // deleteTime
        );
        return entity;
    }
     
    @Override
    public void readEntity(Cursor cursor, NoteItem entity, int offset) {
        entity.setId(cursor.isNull(offset + 0) ? null : cursor.getString(offset + 0));
        entity.setTitle(cursor.isNull(offset + 1) ? null : cursor.getString(offset + 1));
        entity.setContent(cursor.isNull(offset + 2) ? null : cursor.getString(offset + 2));
        entity.setTime(cursor.isNull(offset + 3) ? null : new java.util.Date(cursor.getLong(offset + 3)));
        entity.setCreateTime(cursor.isNull(offset + 4) ? null : new java.util.Date(cursor.getLong(offset + 4)));
        entity.setUpdateTime(cursor.isNull(offset + 5) ? null : new java.util.Date(cursor.getLong(offset + 5)));
        entity.setIsDelete(cursor.getShort(offset + 6) != 0);
        entity.setDeleteTime(cursor.isNull(offset + 7) ? null : new java.util.Date(cursor.getLong(offset + 7)));
     }
    
    @Override
    protected final String updateKeyAfterInsert(NoteItem entity, long rowId) {
        return entity.getId();
    }
    
    @Override
    public String getKey(NoteItem entity) {
        if(entity != null) {
            return entity.getId();
        } else {
            return null;
        }
    }

    @Override
    public boolean hasKey(NoteItem entity) {
        return entity.getId() != null;
    }

    @Override
    protected final boolean isEntityUpdateable() {
        return true;
    }
    
}
