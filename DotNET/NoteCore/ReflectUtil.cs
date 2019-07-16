using NoteCore.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace NoteCore
{
    public class Info
    {
        public string Name { get; set; }
    }

    /// <summary>
    /// 反射工具
    /// </summary>
    public class ReflectUtil
    {
        /// <summary>
        /// 获取选择的字段名称<br/>
        /// 使用格式：<br/>
        /// <code> 
        /// var name = GetPropertyName<![CDATA[<]]>Info>(a => a.Name); 
        /// </code>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static string GetPropertyName<T>(Expression<Func<T, object>> selector)
        {
            return selector.Body.ToString().Split('.')[1];
            // Info a
            //return string.Join(",", selector.Method.GetParameters().Select(a => a.ToString()));  //GetGenericArguments()[0].GetFields().ToString();
        }

        public static void Test()
        {
            var name = GetPropertyName<Info>(a => a.Name);
            Console.WriteLine(name);

            var name2 = GetPropertyName<Info>(a => new
            {
                NickName = a.Name
            });
            Console.WriteLine(name2);
        }
    }
}
