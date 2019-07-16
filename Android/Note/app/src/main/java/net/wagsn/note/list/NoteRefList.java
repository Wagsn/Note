package net.wagsn.note.list;

import android.support.annotation.NonNull;

import net.wagsn.note.entity.Note;
import net.wagsn.note.storage.db.DBManager;
import net.wagsn.note.storage.db.NoteDao;

import java.util.ArrayList;
import java.util.Arrays;

public class NoteRefList extends ArrayList<NoteRefList.Ref> {

    static NoteDao dao = DBManager.get().getNoteDao();

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
        private Note value;

        public Ref(@NonNull Note item){
            value = item;
        }

        public void set(@NonNull Note item){
            value = item;
            dao.save(item);
        }

        public Note get(){
            return value;
        }
    }
}
