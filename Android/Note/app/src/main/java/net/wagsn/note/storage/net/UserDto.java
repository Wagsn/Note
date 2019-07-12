package net.wagsn.note.storage.net;

import java.util.Date;

/**
 * User DTO
 */
public class UserDto {
    /**
     * 标识
     */
    public String id;
    /**
     * 昵称
     */
    public String nickName;
    /**
     * 电子邮箱
     */
    public String email;
    /**
     * 密码
     */
    public String password;

    /**
     * 新增时间
     */
    public Date createTime;
    /**
     * 更新时间
     */
    public Date updateTime;
}
