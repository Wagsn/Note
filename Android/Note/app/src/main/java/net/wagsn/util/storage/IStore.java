package net.wagsn.util.storage;

import java.util.List;

public interface IStore<TEntity, TKey>{
    TKey getKey(TEntity entity);
    boolean hasKey(TEntity entity);
    void save(TEntity ... entities);
    void save(Iterable<TEntity> entities);
    TEntity load(TKey key);
//    List<TEntity> loadWhere(Predicate<TEntity> predicate);
    List<TEntity> loadAll();
    void delete(TEntity... entities);
    void delete(Iterable<TEntity> iterable);
    void deleteByKey(TKey key);
//    void delete(Predicate<TEntity> predicate);
}
