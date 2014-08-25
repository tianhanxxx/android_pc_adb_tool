using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using AdbLibrary;
using ApplicationConfig;
using System.IO;

namespace PCSto
{
    public partial class MainForm : Form
    {
        public static string DATA_PATH = "DataPath";
        public static string SYSTEM_DATA_PATH = "SystemDataPath";
        public static string SCAN_DATA_PATH = "ScanDataPath";

        // 掌机基础数据路径
        public static string DEVICE_SYSTEM_PATH = "//storage//sdcard0//sto//system";
        // 掌机扫描数据路径
        public static string DEVICE_DATA_PATH = "//storage//sdcard0//sto//data";
        // 掌机扫描数据备份路径
        public static string DEVICE_BACK_PATH = "//storage//sdcard0//sto//back";

        delegate void UpdateConnectionStateHandler(bool state, string dateTime);
        UpdateConnectionStateHandler updateConnectionState;

        // 检测设备连接线程
        Thread checkConnectionStateThread;

        private void UpdateConnectionStateMethod(bool state, string dateTime)
        {
            if (state)
            {
                toolStripStatusLabelDeviceTime.Text = dateTime;
                toolStripStatusLabelText.Text = "设备已连接";
            }
            else
            {
                toolStripStatusLabelText.Text = "设备未连接";
                toolStripStatusLabelDeviceTime.Text = "";
            }
        }

        delegate void UpdateProcessBarHandler(int step);
        UpdateProcessBarHandler updateProcessBar;
        private void UpdateProcessBarMethod(int step)
        {
            if (step == -1)
            {
                toolStripProgressBar.Value = 0;
                toolStripStatusLabelDataSync.Text = "数据同步完成";
            }
            else if (step == -2)
            {
                toolStripProgressBar.Value = 0;
                toolStripStatusLabelDataSync.Text = "无同步数据";
            }
            else
            {
                toolStripStatusLabelDataSync.Text = "正在同步数据";
                toolStripProgressBar.Value = step % toolStripProgressBar.Maximum;
            }
        }


        public MainForm()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            updateConnectionState = new UpdateConnectionStateHandler(UpdateConnectionStateMethod);
            // 启动检测设备连接状态的线程
            CheckConnectionStateMethod();
            updateProcessBar = new UpdateProcessBarHandler(UpdateProcessBarMethod);
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void pC路径设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new ConfigForm()).ShowDialog();
        }

        private void toolStripMenuItemHelp_Click(object sender, EventArgs e)
        {
            (new HelpForm()).ShowDialog();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (AdbCommand.DeviceConnected())
            {
                toolStripStatusLabelText.Text = "设备已连接";
            }
            else
            {
                toolStripStatusLabelText.Text = "设备未连接";
                toolStripStatusLabelDeviceTime.Text = "";
            }
        }

        private void buttonTimeSync_Click(object sender, EventArgs e)
        {
            string localTimeString = DateTime.Now.ToString("yyyyMMdd.HHmmss");
            if (AdbCommand.SetDeviceDateTime(localTimeString))
            {
                toolStripStatusLabelText.Text = "时间同步成功";
                toolStripStatusLabelDeviceTime.Text = DateTime.Now.ToString("yyyy-MM-dd.HH:mm:ss");
            }
            else
            {
                toolStripStatusLabelText.Text = "时间同步失败";
            }
        }

        private void buttonPull_Click(object sender, EventArgs e)
        {
            Thread d = new Thread(new ThreadStart(PullFileMethod));
            d.Start();
        }

        private void PullFileMethod()
        {
            string localDataPath = Config.DefaultConfig[DATA_PATH, SCAN_DATA_PATH];
            if (string.IsNullOrEmpty(localDataPath))
            {
                localDataPath = Environment.CurrentDirectory;
                Config.DefaultConfig[DATA_PATH, SCAN_DATA_PATH] = localDataPath;
                Config.DefaultConfig.Save();
            }
                
            if (!Directory.Exists(localDataPath))
            {
                try
                {
                    Directory.CreateDirectory(localDataPath);
                }
                catch
                {
                    updateProcessBar.Invoke(-2);
                    return;
                }
            }

            List<string> dataFiles = AdbCommand.Ls(DEVICE_DATA_PATH);

            if (dataFiles == null || dataFiles.Count == 0)
            {
                updateProcessBar.Invoke(-2);
                return;
            }
            else
            {
                int max = toolStripProgressBar.Maximum;
                toolStripProgressBar.Value = 0;
                int count = 0;

                foreach (string s in dataFiles)
                {
                    // 获取s的文件名，判断在本地是否存在，如果存在，
                    // 则为文件增加序号，最终结果变化为：
                    // xxxx.txt,xxxx_1.txt,xxxx_2.txt等
                    string tmpPath = GetFilePath(s, localDataPath);

                    if (string.IsNullOrEmpty(tmpPath))
                    {
                        continue;
                    }

                    AdbCommand.CopyFromAndroid(s, tmpPath);
                    AdbCommand.Move(s, DEVICE_BACK_PATH + "//" + GetFileName(tmpPath,'\\') + ".txt");
                    updateProcessBar.Invoke(++count);
                }

                updateProcessBar.Invoke(-1);
            }
        }

        private string GetFilePath(string s, string localDataPath)
        {
            if (!Directory.Exists(localDataPath))
            {
                return "";
            }

            string filename = GetFileName(s,'/');
            string ret = localDataPath + "\\" + filename;
            if (string.IsNullOrEmpty(filename))
            {
                return "";
            }

            DirectoryInfo info = new DirectoryInfo(localDataPath);
            int fileCount = 0;

            foreach (FileInfo fi in info.GetFiles())
            {
                string fi_fileName = GetFileName(fi.FullName, '\\');
                if (fi_fileName.StartsWith(filename))
                {
                    fileCount++;
                }
            }

            if (fileCount > 0)
            {
                ret += "_" + fileCount;
            }

            ret += ".txt";

            return ret;
            
        }

        private string GetFileName(string s, char split)
        {
            if (string.IsNullOrEmpty(s))
            {
                return "";
            }
            int begin = s.LastIndexOf(split);
            int end = s.LastIndexOf('.');
            if (begin >= end)
            {
                return "";
            }
            return s.Substring(begin + 1, end - begin - 1);
            
        }

        private void buttonPush_Click(object sender, EventArgs e)
        {
            Thread d = new Thread(new ThreadStart(pushFileMethod));
            d.Start();
        }

        private void pushFileMethod()
        {
            string localSystemFilePath = Config.DefaultConfig[DATA_PATH, SYSTEM_DATA_PATH];


            if (string.IsNullOrEmpty(localSystemFilePath))
            {
                localSystemFilePath = Environment.CurrentDirectory;
                Config.DefaultConfig[DATA_PATH, SYSTEM_DATA_PATH] = localSystemFilePath;
                Config.DefaultConfig.Save();
            }

            if (!Directory.Exists(localSystemFilePath))
            {
                try
                {
                    Directory.CreateDirectory(localSystemFilePath);
                }
                catch
                {
                    updateProcessBar.Invoke(-2);
                    return;
                }
            }

            if (!Directory.Exists(localSystemFilePath))
            {
                return;
            }
            
            DirectoryInfo dir = new DirectoryInfo(localSystemFilePath);
            FileInfo[] files = dir.GetFiles();

            int txtCount = GetTxtFileCount(files);

            if (txtCount <= 0)
            {
                updateProcessBar.Invoke(-2);
                return;
            }

            int max = toolStripProgressBar.Maximum;
            toolStripProgressBar.Value = 0;
            int count = 0;

            AdbCommand.MakeDir(DEVICE_SYSTEM_PATH);

            foreach (FileInfo file in files)
            {

                if (file.FullName.Length < 4)
                {
                    continue;
                }
                else if (file.FullName.Substring(file.FullName.Length - 4, 4) == ".TXT"
                    || file.FullName.Substring(file.FullName.Length - 4, 4) == ".txt")
                {
                    AdbCommand.CopyFromPC(file.FullName, DEVICE_SYSTEM_PATH);
                    updateProcessBar.Invoke(++count);
                }
            }

            updateProcessBar.Invoke(-1);
            
        }

        private int GetTxtFileCount(FileInfo[] files)
        {
            int count = 0;
            if (files == null)
            {
                return count;
            }
            foreach (FileInfo file in files)
            {

                if (file.FullName.Length < 4)
                {
                    continue;
                }
                else if (file.FullName.Substring(file.FullName.Length - 4, 4) == ".TXT"
                    || file.FullName.Substring(file.FullName.Length - 4, 4) == ".txt")
                {
                    count++;
                }
            }

            return count;
        }

        private void CheckConnectionStateMethod()
        {
            checkConnectionStateThread =
                new Thread(new ThreadStart(CheckConnectionState));
            checkConnectionStateThread.Start();
        }

        private void CheckConnectionState()
        {
            // 确保adb服务运行
            AdbCommand.AdbStartServer();

            while(true)
            {
                bool state = AdbCommand.DeviceConnected();
                if (!state)
                {
                    updateConnectionState.BeginInvoke(state, "", null, null);
                }
                else
                {
                    string timeString = AdbCommand.GetDeviceDateTime();
                    updateConnectionState.BeginInvoke(state,timeString, null, null);
                }
                Thread.Sleep(5000);
            }
        }

        private void menuStripMain_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string versionString = this.Text + " V" + Application.ProductVersion;
            this.Text = versionString;
            
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (checkConnectionStateThread != null
                && checkConnectionStateThread.ThreadState != ThreadState.Stopped)
            {
                checkConnectionStateThread.Abort();
            }
        }
    }
}
