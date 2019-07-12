package net.wagsn.note.storage.net;

import java.util.Date;

/**
 * Note DTO
 */
public class NoteDto {
    /**
     * 标识
     */
    public String id;
    /**
     * 标题
     */
    public String title;
    /**
     * 内容
     */
    public String content;
    /**
     * 新增时间
     */
    public Date createTime;
    /**
     * 更新时间
     */
    public Date updateTime;
}
