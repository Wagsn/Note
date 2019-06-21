package net.wagsn.note.storage;

import net.wagsn.note.list.NoteItem;
import net.wagsn.util.storage.AbstractStore;

import org.greenrobot.greendao.AbstractDao;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.UUID;

/**
 * The data resource
 */
public class NoteStore extends AbstractStore<NoteItem, String> {

    public final List<NoteItem> ITEMS = new ArrayList<>();
    private AbstractDao<NoteItem, String> mDao;

    private NoteStore(){}

    private static class SingletonHolder {
        private static NoteStore instance = new NoteStore();
    }

    public static NoteStore get() {
        return SingletonHolder.instance;
    }

    public void init(AbstractDao<NoteItem, String> abstractDao){
        mDao = abstractDao;
        ITEMS.addAll(mDao.loadAll());
    }

    @Override
    public String getKey(NoteItem item) {
        if (item != null){
            return item.getId();
        }else {
            return null;
        }
    }

    @Override
    public boolean hasKey(NoteItem item) {
        return item.getId() != null;
    }

    @Override
    public void save(Iterable<NoteItem> noteItems) {
        for (NoteItem item: noteItems) {
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
    public List<NoteItem> loadAll() {
        return mDao.loadAll();
    }

    @Override
    public void delete(Iterable<NoteItem> iterable) {
        mDao.deleteInTx(iterable);
    }
}
