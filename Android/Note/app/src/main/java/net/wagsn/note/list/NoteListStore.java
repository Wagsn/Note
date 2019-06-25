package net.wagsn.note.list;

import net.wagsn.note.entity.NoteItem;
import net.wagsn.note.storage.db.DBManager;
import net.wagsn.note.storage.db.NoteItemDao;

import java.util.ArrayList;
import java.util.Comparator;
import java.util.Date;
import java.util.UUID;

/**
 * Store for Note List, for Adapter.
 */
public class NoteListStore extends ArrayList<NoteItem> {

     NoteItemDao dao = DBManager.get().getNoteItemDao();
    // 排序规则
    public int sortType;

    public NoteListStore(){
        super();
        super.addAll(dao.loadAll());
        sort(new Order());
    }

    private static class SingletonHolder {
        private static NoteListStore instance = new NoteListStore();
    }

    public static NoteListStore get() {
        return SingletonHolder.instance;
    }

    @Override
    public boolean add(NoteItem item) {
        if (item.time == null){
            item.time = new Date();
        }
        if (item.id==null){
            item.id = UUID.randomUUID().toString();

            long rowId = dao.insert(item);
            if (rowId > 0) {
                boolean added = super.add(item);
                super.sort(new Order());
                return added;
            }
        } else {
            dao.save(item);
            return true;
        }
        return false;
    }

    public class Order implements Comparator<NoteItem> {

        @Override
        public int compare(NoteItem noteItem, NoteItem t1) {
            return noteItem.time.after(t1.time)?1:0;
        }
    }
}
