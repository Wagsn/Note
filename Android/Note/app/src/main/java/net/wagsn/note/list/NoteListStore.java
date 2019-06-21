package net.wagsn.note.list;

import net.wagsn.note.storage.db.DBManager;
import net.wagsn.note.storage.db.greendao.NoteItemDao;

import java.util.ArrayList;

/**
 * Store for Note List, for Adapter.
 */
public class NoteListStore extends ArrayList<NoteItem> {

    NoteItemDao dao = DBManager.get().getNoteItemDao();

    @Override
    public boolean add(NoteItem item) {
        long rowId = dao.insert(item);
        if (rowId > 0) {
            return super.add(item);
        }
        return false;
    }
}
