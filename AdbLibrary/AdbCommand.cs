using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace AdbLibrary
{
    public class AdbCommand
    {
        private const string ADB = @"adb.exe";
        private const string PULL = " pull ";
        private const string PUSH = " push ";

        //private const string SET_TIME = " shell settime \"";
        private const string SET_TIME = " shell date -s ";
        private const string SET_TIME_TAIL = "\"";

        private const string GET_TIME = " shell date +\"%Y-%m-%d %H:%M:%S\"";
        private const string DEVICES = " devices";
        private const string Remove_FILE = " shell rm ";
        private const string START_SERVER = " start-server ";
        private const string LS = " shell ls ";
        private const string MV = " shell mv ";
        private const string MKDIR = " shell mkdir ";
        private const string MV_SPLIT = " ";

        private static char[] SPLIT_CHARS = new char[] { '\r', '\n' };

        //从PC复制文件
        public static void CopyFromPC(string source, string dest)
        {
            Process p = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();

            startInfo.FileName = ADB;
            source = "\"" + source + "\"";
            startInfo.Arguments = PUSH + source + " " + "\"" + AndroidFileNameEncoder.ToUTF8(dest) + "\"";
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;

            p.StartInfo = startInfo;
            p.Start();
        }

        //从Android设备复制文件
        public static void CopyFromAndroid(string source, string dest)
        {
            Process p = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();

            startInfo.FileName = ADB;
            startInfo.Arguments = PULL + "\"" + AndroidFileNameEncoder.ToUTF8(source) + "\"" + " " + "\"" + dest + "\"";
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;

            p.StartInfo = startInfo;
            p.Start();
        }

        public static void AdbStartServer()
        {
            Process p = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();

            startInfo.FileName = ADB;
            startInfo.Arguments = START_SERVER;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;

            p.StartInfo = startInfo;
            p.Start();
        }

        public static bool DeviceConnected()
        {
            bool ret = false;

            Process p = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();

            startInfo.FileName = ADB;
            startInfo.Arguments = DEVICES;
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            startInfo.StandardOutputEncoding = System.Text.Encoding.UTF8;
            startInfo.CreateNoWindow = true;

            p.StartInfo = startInfo;
            p.Start();

            StreamReader reader = p.StandardOutput;

            string retMessage = reader.ReadToEnd();
            if (string.IsNullOrEmpty(retMessage))
            {
                ret = false;
            }
            else
            {
                Console.WriteLine(retMessage);

                string[] deviceList = retMessage.Split(SPLIT_CHARS);

                foreach (string s in deviceList)
                {
                    if (!string.IsNullOrEmpty(s))
                    {
                        if (s.Trim() == "MSM8625QRD5\tdevice")
                        {
                            ret = true;
                        }
                    }
                }
            }

            return ret;
        }

        public static string GetDeviceDateTime()
        {
            string ret = "";

            Process p = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();

            startInfo.FileName = ADB;
            startInfo.Arguments = GET_TIME;
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            startInfo.StandardOutputEncoding = System.Text.Encoding.UTF8;
            startInfo.CreateNoWindow = true;

            p.StartInfo = startInfo;
            p.Start();

            StreamReader reader = p.StandardOutput;

            string retMessage = reader.ReadToEnd();
            if (string.IsNullOrEmpty(retMessage))
            {
                ret = "";
            }
            else
            {
                Console.WriteLine(retMessage);
                ret = retMessage.Trim();
            }

            return ret;
        }

        public static bool SetDeviceDateTime(string dataTimeString)
        {
            bool ret = false;

            Process p = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();

            startInfo.FileName = ADB;
            startInfo.Arguments = SET_TIME + dataTimeString;
            //startInfo.Arguments = SET_TIME + dataTimeString + SET_TIME_TAIL;
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            startInfo.StandardOutputEncoding = System.Text.Encoding.UTF8;
            startInfo.CreateNoWindow = true;

            p.StartInfo = startInfo;
            p.Start();

            StreamReader reader = p.StandardOutput;

            string retMessage = reader.ReadToEnd();
            if (string.IsNullOrEmpty(retMessage))
            {
                ret = false;
            }
            else
            {
                string retString = retMessage.Trim();
                Console.WriteLine(retString);
                if (retString == "Thu Jan  1 08:00:00 CST 1970")
                {
                    ret = false;
                }
                else
                {
                    ret = true;
                }
            }

            return ret;
        }

        //相当于LS命令
        public static List<string> Ls(string directory)
        {
            if (string.IsNullOrEmpty(directory))
                return null;
            if (directory.Substring(directory.Length - 2, 1) != "//")
            {
                directory += "//";
            }

            List<string> files = new List<string>();

            Process p = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();

            startInfo.FileName = ADB;
            startInfo.Arguments = LS + AndroidFileNameEncoder.ToUTF8(directory);
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            startInfo.StandardOutputEncoding = System.Text.Encoding.UTF8;
            startInfo.CreateNoWindow = true;

            p.StartInfo = startInfo;
            p.Start();

            StreamReader reader = p.StandardOutput;
            for (string tmp = reader.ReadLine(); tmp != null; tmp = reader.ReadLine())
            {
                if (tmp.Equals("\r") || tmp.Equals("\n") || tmp.Equals(""))
                    continue;
                if (tmp.Trim().Length >= 4 &&
                    (tmp.Trim().Substring(tmp.Length - 4, 4).Equals(".txt") || tmp.Trim().Substring(tmp.Length - 4, 4).Equals(".TXT")))
                {
                    files.Add(directory + tmp);
                }
            }

            return files;
        }

        //相当于LS命令
        public static void Move(string source, string dest)
        {
            if (string.IsNullOrEmpty(dest))
            {
                return;
            }

            MakeDir(dest.Substring(0, dest.LastIndexOf('/')));

            //dest = MakeDir(dest);

            Thread.Sleep(1000);

            // 复制文件
            Process p2 = new Process();
            ProcessStartInfo startInfo2 = new ProcessStartInfo();

            startInfo2.FileName = ADB;
            startInfo2.Arguments = MV + AndroidFileNameEncoder.ToUTF8(source) 
                + MV_SPLIT + AndroidFileNameEncoder.ToUTF8(dest);
            startInfo2.RedirectStandardOutput = true;
            startInfo2.UseShellExecute = false;
            startInfo2.StandardOutputEncoding = System.Text.Encoding.UTF8;
            startInfo2.CreateNoWindow = true;

            p2.StartInfo = startInfo2;
            p2.Start();

            return;
        }

        public static string MakeDir(string directory)
        {
            if (string.IsNullOrEmpty(directory))
            {
                return "";
            }

            if (directory.Substring(directory.Length - 2, 1) != "//")
            {
                directory += "//";
            }

            // 创建文件夹
            Process p = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();

            startInfo.FileName = ADB;
            startInfo.Arguments = MKDIR + directory;
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            startInfo.StandardOutputEncoding = System.Text.Encoding.UTF8;
            startInfo.CreateNoWindow = true;

            p.StartInfo = startInfo;
            p.Start();
            return directory;
        }
    }
}
