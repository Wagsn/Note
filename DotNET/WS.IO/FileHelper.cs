using System;
using System.IO;

namespace WS.IO
{
    /// <summary>
    /// 文件助手
    /// </summary>
    public class FileHelper
    {
        /// <summary>
        /// 文件写入内容(是否追加：默认false，如果文件存在将被删除重建)
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="contents">文件正文</param>
        public static void WriteAllText(string path, string contents, FileOption option = FileOption.Append|FileOption.Create)
        {
            if (path == null) throw new ArgumentNullException(nameof(path));

            FileInfo textFile = new FileInfo(path);
            if (!textFile.Exists)
            {
                if((option&FileOption.Create) > 0)
                {
                    DirectoryInfo textDir = textFile.Directory;
                    if (!textDir.Exists)
                    {
                        textDir.Create();
                    }
                }
                else throw new FileNotFoundException("文件未找到: "+path);
            }
            StreamWriter writer;
            if ((option & FileOption.Append) > 0)
            {
                writer = textFile.AppendText();
            }
            else
            {
                textFile.Delete();
                writer = textFile.CreateText();
            }
            writer.Write(contents);
            writer.Close();
        }
    }
}
