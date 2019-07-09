package net.wagsn.note.entity;

import java.util.Date;

/**
 * 用户
 */
public class User {
    /**
     * 主键标识
     */
    public String id;
    /**
     * 用户名
     */
    public String username;
    /**
     * 昵称
     */
    public String nickname;
    /**
     * 官方名称
     */
    public String officialName;
    /**
     * 真名
     */
    public String realName;
    /**
     * 电话
     */
    public String phone;
    /**
     * 邮箱（可作为登陆账号）
     */
    public String email;
    /**
     * 密码
     */
    public String password;
    /**
     * 生日（诞辰）
     */
    public Date birthday;
    /**
     * 性别（0-未知、1-男、3-女、4-第三性别、5-无性、6-双性）
     */
    public int gender;
}
