package net.wagsn.note.entity;

import java.io.Serializable;
import java.util.Date;
import java.util.List;

/**
 * 备忘
 * Created by Wagsn on 2019/7/6.
 */
public class Memo implements Serializable {
    /**
     * 标题
     */
    public String title;

    /**
     * 正文
     */
    public String content;

    /**
     * 标签组
     */
    public List<Tag> tags;

//    /**
//     * 备注
//     */
//    public String remark;

    /**
     * 地点
     */
    public Site site;

    /**
     * 开始时间
     */
    public Date startTime;

    /**
     * 结束时间
     */
    public Date endTime;

    /**
     * 通知时间（[-]提前与[+]延后）
     */
    public int[] notices;

    /**
     * 重复（-每天、-每周、-每月、-每季、-每年）
     */
    public int[] repeats;

    /**
     * 已完成
     */
    public boolean completed;

    /**
     * 创建时间
     */
    public Date createTime;

    /**
     * 更新时间
     */
    public Date updateTime;

    /**
     * 已删除
     */
    public boolean deleted;

    /**
     * 删除时间
     */
    public Date deleteTime;
}

