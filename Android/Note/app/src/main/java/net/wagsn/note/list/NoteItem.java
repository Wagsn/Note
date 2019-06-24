package net.wagsn.note.list;

import org.greenrobot.greendao.annotation.*;

import java.io.Serializable;
import java.util.Date;

/**
 * 笔记实体
 * Entity for Note List.
 */
@Entity
public class NoteItem implements Serializable {
    static final long serialVersionUID = 536871008;
    @Id
    public String id;
    @Property
    public String title;
    @Property
    public String content;
    // 笔记类型，1纯文本，2Html，3Markdown
//    public int type;
    @Property
    public Date time;
    @Property
    public Date createTime;
    @Property
    public Date updateTime;
    @Property
    public boolean isDelete;
    @Property
    public Date deleteTime;

    public NoteItem(String id, String title, String content, Date time) {
        this.id = id;
        this.title = title;
        this.content = content;
        this.time = time;
        Date now = new Date();
        this.createTime = now;
        this.updateTime = now;
        this.isDelete = false;
        this.deleteTime = null;
    }

    @Generated(hash = 1249367908)
    public NoteItem(String id, String title, String content, Date time,
            Date createTime, Date updateTime, boolean isDelete, Date deleteTime) {
        this.id = id;
        this.title = title;
        this.content = content;
        this.time = time;
        this.createTime = createTime;
        this.updateTime = updateTime;
        this.isDelete = isDelete;
        this.deleteTime = deleteTime;
    }

    @Generated(hash = 260707407)
    public NoteItem() {
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

    public Date getTime() {
        return this.time;
    }

    public void setTime(Date time) {
        this.time = time;
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

    public boolean getIsDelete() {
        return this.isDelete;
    }

    public void setIsDelete(boolean isDelete) {
        this.isDelete = isDelete;
    }

    public Date getDeleteTime() {
        return this.deleteTime;
    }

    public void setDeleteTime(Date deleteTime) {
        this.deleteTime = deleteTime;
    }
}
