package net.wagsn.util.storage;

import java.util.List;

/**
 * 抽象存储 可以用来操作本地数据库或网络存储，作为业务层的数据源
 * @param <TEntity> 实体
 * @param <TKey> 主键必须是对象类型
 */
public interface IStore<TEntity, TKey> {

    /**
     * 获取主键
     * @param entity 实体
     * @return
     */
    TKey getKey(TEntity entity);
    /**
     * 主键有值
     * @param entity
     * @return
     */
    boolean hasKey(TEntity entity);

    /**
     * 保存实体
     * @param entities
     */
    void save(TEntity ... entities);

    /**
     * 保存实体
     * @param entities
     */
    void save(Iterable<TEntity> entities);

    /**
     * 加载实体
     * @param key
     * @return
     */
    TEntity load(TKey key);
//    List<TEntity> loadWhere(Predicate<TEntity> predicate);

    /**
     * 加载所有实体
     * @return
     */
    List<TEntity> loadAll();

    /**
     * 删除实体
     * @param entities
     */
    void delete(TEntity... entities);

    /**
     * 删除实体
     * @param iterable
     */
    void delete(Iterable<TEntity> iterable);
    void deleteByKey(TKey key);
//    void delete(Predicate<TEntity> predicate);
}
