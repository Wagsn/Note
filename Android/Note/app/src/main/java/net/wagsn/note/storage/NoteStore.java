package net.wagsn.note.storage;

import net.wagsn.note.entity.Note;
import net.wagsn.util.storage.AbstractStore;

import org.greenrobot.greendao.AbstractDao;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.UUID;

/**
 * Note 统一数据源
 */
public class NoteStore extends AbstractStore<Note, String> {

    public final List<Note> ITEMS = new ArrayList<>();
    private AbstractDao<Note, String> mDao;

    private NoteStore(){}

    private static class SingletonHolder {
        private static NoteStore instance = new NoteStore();
    }

    public static NoteStore get() {
        return SingletonHolder.instance;
    }

    public void init(AbstractDao<Note, String> abstractDao){
        mDao = abstractDao;
        ITEMS.addAll(mDao.loadAll());
    }

    @Override
    public String getKey(Note item) {
        return item != null ? item.getId() : null;
    }

    @Override
    public boolean hasKey(Note item) {
        return item.getId() != null;
    }

    @Override
    public void save(Iterable<Note> noteItems) {
        for (Note item: noteItems) {
            item.time = new Date();
            item.updateTime = new Date();
            if (!hasKey(item)){
                item.setId(UUID.randomUUID().toString());
                mDao.insert(item);
            } else {
                mDao.update(item);
            }
        }
    }

    @Override
    public List<Note> loadAll() {
        return mDao.loadAll();
    }

    @Override
    public void delete(Iterable<Note> iterable) {
        mDao.deleteInTx(iterable);
    }
}
