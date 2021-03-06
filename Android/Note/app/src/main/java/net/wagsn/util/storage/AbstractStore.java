package net.wagsn.util.storage;

import java.util.Arrays;
import java.util.List;

/**
 * 抽象存储
 * @param <TEntity> 存储实体
 * @param <TKey> 实体主键
 */
public abstract class AbstractStore<TEntity, TKey> implements IStore<TEntity, TKey> {

    @Override
    public void save(TEntity... entities) {
        save(Arrays.asList(entities));
    }

//    @RequiresApi(api = Build.VERSION_CODES.N)
//    @Override
//    public List<TEntity> loadWhere(Predicate<TEntity> predicate) {
//        List<TEntity> entities = loadAll();
//        entities.removeIf(t -> !predicate.test(t));
//        return entities;
//    }

    @Override
    public TEntity load(TKey key) {
        List<TEntity> entities = loadAll();
        for (TEntity entity:
             entities) {
            if (getKey(entity).equals(key))
                return entity;
        }
        return null;
    }

    @Override
    public void delete(TEntity... entities) {
        delete(Arrays.asList(entities));
    }

//    @RequiresApi(api = Build.VERSION_CODES.N)
//    @Override
//    public void delete(Predicate<TEntity> predicate) {
//        delete(loadWhere(predicate));
//    }

    @Override
    public void deleteByKey(TKey key) {
        TEntity entity = load(key);
        if(entity != null) delete(entity);
    }
}
