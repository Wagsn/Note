package net.wagsn.note.entity;

import org.greenrobot.greendao.annotation.*;

import java.io.Serializable;
import java.util.Date;

/**
 * 笔记实体
 * Entity for Note List.
 */
@Entity
public class Note implements Serializable {
    static final long serialVersionUID = 536871008;
    @Id
    public String id;
    @Property
    public String title;
    @Property
    public String content;
    // 笔记类型，1TXT，2HTML，3MarkDown
//    public int type;
    @Property
    public Date time;
    @Property
    public Date createTime;
    @Property
    public Date updateTime;
    /**
     * 同步（可配置默认值，-true：则保存时发送到服务器，-false：保存时不同步到服务器）
     */
    @Property
    public boolean sync;

//    public Note(String id, String title, String content, Date time) {
//        this.id = id;
//        this.title = title;
//        this.content = content;
//        this.time = time;
//        Date now = new Date();
//        this.createTime = now;
//        this.updateTime = now;
//    }

@Generated(hash = 545657903)
    public Note(String id, String title, String content, Date time, Date createTime,
            Date updateTime, boolean sync) {
        this.id = id;
        this.title = title;
        this.content = content;
        this.time = time;
        this.createTime = createTime;
        this.updateTime = updateTime;
        this.sync = sync;
    }

    @Generated(hash = 1272611929)
    public Note() {
    }

    @Override
    public String toString() {
        return id+" "+title;
    }

    public String getId() {
        return this.id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getTitle() {
        return this.title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public String getContent() {
        return this.content;
    }

    public void setContent(String content) {
        this.content = content;
    }

    public Date getCreateTime() {
        return this.createTime;
    }

    public void setCreateTime(Date createTime) {
        this.createTime = createTime;
    }

    public Date getUpdateTime() {
        return this.updateTime;
    }

    public void setUpdateTime(Date updateTime) {
        this.updateTime = updateTime;
    }

    public Date getTime() {
        return this.time;
    }

    public void setTime(Date time) {
        this.time = time;
    }

    public boolean getSync() {
        return this.sync;
    }

    public void setSync(boolean sync) {
        this.sync = sync;
    }
}
