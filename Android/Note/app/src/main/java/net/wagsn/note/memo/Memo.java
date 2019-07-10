package net.wagsn.note.memo;

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

//    /**
//     * 标签组
//     */
//    public List<Tag> tags;
//
//    /**
//     * 执行人
//     */
//    public List<User> executors;

//    /**
//     * 抄送人
//     */
//    public List<User> copiers;

//    /**
//     * 备注
//     */
//    public String remark;

//    /**
//     * 地点
//     */
//    public Site site;

    /**
     * 开始时间
     */
    public Date startTime;

    /**
     * 结束（截止）时间
     */
    public Date endTime;

    /**
     * 提醒（为空表示无提醒）
     */
    public List<Remind> reminds;

    /**
     * 重复
     */
    public List<Repeat> repeats;

    /**
     * 业务状态（1-草稿、2-执行中、3-已取消、4-已完成）
     */
    public int state;

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

