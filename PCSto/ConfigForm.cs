using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ApplicationConfig;

namespace PCSto
{
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();

            string scan_path = Config.DefaultConfig[MainForm.DATA_PATH, MainForm.SCAN_DATA_PATH];
            string system_path = Config.DefaultConfig[MainForm.DATA_PATH, MainForm.SYSTEM_DATA_PATH];

            textBoxScanDataPath.Text = scan_path;
            textBoxSystemDataPath.Text = system_path;

        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxScanDataPath.Text)
                || string.IsNullOrEmpty(textBoxSystemDataPath.Text))
            {
                MessageBox.Show("请补全路径信息");
            }
            else
            {
                Config.DefaultConfig[MainForm.DATA_PATH, MainForm.SCAN_DATA_PATH] = textBoxScanDataPath.Text;
                Config.DefaultConfig[MainForm.DATA_PATH, MainForm.SYSTEM_DATA_PATH] = textBoxSystemDataPath.Text;
                Config.DefaultConfig.Save();

                this.Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSystemDataPath_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowDialog();
            string path = folderBrowserDialog.SelectedPath;
            if (string.IsNullOrEmpty(path))
            {
                MessageBox.Show("请选择有效路径");
                return;
            }
            else
            {
                textBoxSystemDataPath.Text = path;
            }
        }

        private void buttonScanDataPath_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowDialog();
            string path = folderBrowserDialog.SelectedPath;
            if (string.IsNullOrEmpty(path))
            {
                MessageBox.Show("请选择有效路径");
                return;
            }
            else
            {
                textBoxScanDataPath.Text = path;
            }
        }

        
    }
}
