package net.wagsn.note.list;

import android.support.annotation.NonNull;

import net.wagsn.note.entity.NoteItem;
import net.wagsn.note.storage.db.DBManager;
import net.wagsn.note.storage.db.NoteItemDao;

import java.util.ArrayList;
import java.util.Arrays;

public class NoteRefList extends ArrayList<NoteRefList.Ref> {

    static NoteItemDao dao = DBManager.get().getNoteItemDao();

    NoteRefList() {
        super(Arrays.asList((Ref[]) dao.loadAll().stream().map(Ref::new).toArray()));
    }

    private static class SingletonHolder {
        private static NoteRefList instance = new NoteRefList();
    }

    public static NoteRefList get() {
        return SingletonHolder.instance;
    }

    @Override
    public boolean add(@NonNull Ref ref) {
        boolean added = super.add(ref);
        dao.insert(ref.get());
        return added;
    }

    public static class Ref {
        private NoteItem value;

        public Ref(@NonNull NoteItem item){
            value = item;
        }

        public void set(@NonNull NoteItem item){
            value = item;
            dao.save(item);
        }

        public NoteItem get(){
            return value;
        }
    }
}
