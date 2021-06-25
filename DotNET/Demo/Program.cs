using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            // 将字符串中的数字抽取出来组成一个数组 12a45 -> 12 45
            string line2 = Console.ReadLine();
            int count = 0;
            int index = -1;
            for(int i= 0; i<line2.Length; i++)
            {
                if(Regex.IsMatch(line2.Substring(i, 1), @"\d"))
                {
                    if(index >= 0)
                    {
                        count++;
                    }
                    else
                    {
                        index = i;
                        count = 1;
                    }
                }
                else
                {
                    if (index >= 0)
                    {
                        Console.WriteLine(line2.Substring(index, count));
                    }
                    index = -1;
                    count = 0;
                }
            }
            if(index >= 0)
            {
                Console.WriteLine(line2.Substring(index, count));
            }

            //var ou2 = Regex.Replace(line2, @"[^\d]", "");
            //var num = int.Parse(ou2);
            //Console.WriteLine(num);


            // 将一串数字 排序 去重
            //string line = Console.ReadLine();
            //double[] arr = line.Split(' ').Select(a => double.Parse(a)).ToArray();

            //var ou = arr.OrderBy(aa => aa).Distinct();
            //Console.WriteLine(string.Join(" ", ou));
        }



        static string Handle(string str)
        {
            // 一个字符串 连续3次出现的小写字母 整个 替换为字母表中的下一个小写字母（aaa->b, bbb->c, zzz->a）
            // ATRcccert893#45ae  ATRdert893#45ae
            // 初始化 字符 字符索引 字符数量 
            //var str = "ATRcccddt893#45ae";
            char start = str[0];
            int count = 0;
            int index = -1;
            var arr = new List<Index>();
            for (int i = 0; i < str.Length; i++)
            {
                // 是否小写字母
                if (Regex.IsMatch(str.Substring(i, 1), "[a-z]"))
                {
                    // 是  
                    // 是否已经保存有小写字母
                    if (index > 0)
                    {
                        // 是 与上一个小写字母是否相等
                        if (str[i] == start)
                        {
                            count++;
                            if (count == 3)
                            {
                                // 重置
                                arr.Add(new Index { ind = index, curr = str[i] });
                                index = -1;
                                count = 0;
                            }
                        }
                        else
                        {
                            start = str[i];
                            index = i;
                            count = 1;
                        }
                    }
                    else
                    {
                        // 否 将该小写字母标记为第一个出现的小写字母
                        start = str[i];
                        index = i;
                        count = 1;
                    }
                }
                else
                {
                    index = -1;
                    count = 0;
                }
            }
            // 从后到前处理字符串
            arr.Reverse();
            foreach (var item in arr)
            {
                var ch = item.curr;
                // 这个字母的下一个字母
                if (item.curr == 'z')
                {
                    ch = 'a';
                }
                else
                {
                    ch = (char)(++item.curr);
                }
                var lef = str.Substring(0, item.ind);
                var mid = $"{ch}";
                var rig = str.Substring(item.ind + 3, str.Length - (item.ind + 3));
                str = lef + mid + rig;
            }
            return str;
        }

        public class Index
        {
            public int ind;
            public char curr;
        }

        static void Call()
        {
            // 一个整型数组 数量不超过100
            // 输出最大值及个数 最小值及个数

            // 直接输入一行数字以空格分割
            string line = Console.ReadLine();
            int[] arr = line.Split(' ').Select(a => int.Parse(a)).ToArray();
            int max = int.MinValue;
            int maxNum = 0;
            int min = int.MaxValue;
            int minNum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int num = arr[i];
                // 和最大值比较 1 如果大于最大值则  maxNum 设置为1 max重置
                // 2 等于 maxNum++ 3 小于 不做操作
                if (num > max)
                {
                    maxNum = 1;
                    max = num;
                }
                else if (num == max)
                {
                    maxNum++;
                }
                // 和最小值比较 1 如果小于最小值则  minNum 设置为1 min重置
                // 2 等于 minNum++ 3 大于 不做操作
                if (num < min)
                {
                    minNum = 1;
                    min = num;
                }
                else if (num == min)
                {
                    minNum++;
                }
            }

            Console.WriteLine("最大值是：" + max + ", 数量为：" + maxNum + "， 最小值是：" + min + ", 数量为：" + minNum);
        }
    }
}
