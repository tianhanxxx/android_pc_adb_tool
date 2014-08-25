using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdbLibrary
{
    //路径操作封装
    public class AndroidFilePath
    {
        //保存路径的数据结构
        private List<string> filePath;
        //根目录
        private static string root = "/";
        //路径分隔符
        private static string depart = "/";

        public static string Depart
        {
            get { return depart; }
        }

        public static string Root
        {
            get { return root; }
        }

        //创建新的路径实例，初始化为根目录
        public AndroidFilePath()
        {
            filePath = new List<string>();
            filePath.Add(root);
        }
        //重载ToString方法，返回路径字符串
        new public string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (string str in filePath)
            {                
                sb.Append(str);
            }
            return sb.ToString();
        }
        //进入下一级目录（文件）
        public void Enter(string target)
        {
            filePath.Add(target);
        }
        //返回上一层目录
        public void Revert()
        {
            if (filePath.Count > 1)
                filePath.RemoveAt(filePath.Count - 1);
        }
        //回到ROOT目录
        public void SetRoot()
        {
            filePath.Clear();
            filePath.Add(root);
        }
        //设置路径
        public void SetPath(string path)
        {
            filePath.Clear();
            filePath.Add(root);

            string[] tmp = path.Split(new char[]{depart[0]});
            foreach (string str in tmp)
            {
                if (string.IsNullOrEmpty(str))
                    continue;
                filePath.Add(str + depart);
            }
        }
    }

    //文件类型（区分文件和文件夹）
    public enum FileType
    {
        文件,
        文件夹,        
    }
}
