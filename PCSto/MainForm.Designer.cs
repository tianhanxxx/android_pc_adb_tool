namespace PCSto
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.buttonConnect = new System.Windows.Forms.Button();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.菜单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pC路径设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonPull = new System.Windows.Forms.Button();
            this.buttonTimeSync = new System.Windows.Forms.Button();
            this.buttonPush = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabelText = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelDeviceTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelDataSync = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStripMain.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(23, 42);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(144, 47);
            this.buttonConnect.TabIndex = 0;
            this.buttonConnect.Text = "连接设备";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.菜单ToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(390, 25);
            this.menuStripMain.TabIndex = 1;
            this.menuStripMain.Text = "菜单";
            this.menuStripMain.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStripMain_ItemClicked);
            // 
            // 菜单ToolStripMenuItem
            // 
            this.菜单ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pC路径设置ToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolStripMenuItemHelp,
            this.退出ToolStripMenuItem});
            this.菜单ToolStripMenuItem.Name = "菜单ToolStripMenuItem";
            this.菜单ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.菜单ToolStripMenuItem.Text = "菜单";
            // 
            // pC路径设置ToolStripMenuItem
            // 
            this.pC路径设置ToolStripMenuItem.Name = "pC路径设置ToolStripMenuItem";
            this.pC路径设置ToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.pC路径设置ToolStripMenuItem.Text = "PC路径设置";
            this.pC路径设置ToolStripMenuItem.Click += new System.EventHandler(this.pC路径设置ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(136, 6);
            // 
            // toolStripMenuItemHelp
            // 
            this.toolStripMenuItemHelp.Name = "toolStripMenuItemHelp";
            this.toolStripMenuItemHelp.Size = new System.Drawing.Size(139, 22);
            this.toolStripMenuItemHelp.Text = "帮助";
            this.toolStripMenuItemHelp.Click += new System.EventHandler(this.toolStripMenuItemHelp_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // buttonPull
            // 
            this.buttonPull.Location = new System.Drawing.Point(23, 95);
            this.buttonPull.Name = "buttonPull";
            this.buttonPull.Size = new System.Drawing.Size(144, 47);
            this.buttonPull.TabIndex = 2;
            this.buttonPull.Text = "数据导出";
            this.buttonPull.UseVisualStyleBackColor = true;
            this.buttonPull.Click += new System.EventHandler(this.buttonPull_Click);
            // 
            // buttonTimeSync
            // 
            this.buttonTimeSync.Location = new System.Drawing.Point(218, 42);
            this.buttonTimeSync.Name = "buttonTimeSync";
            this.buttonTimeSync.Size = new System.Drawing.Size(144, 47);
            this.buttonTimeSync.TabIndex = 3;
            this.buttonTimeSync.Text = "时间同步";
            this.buttonTimeSync.UseVisualStyleBackColor = true;
            this.buttonTimeSync.Click += new System.EventHandler(this.buttonTimeSync_Click);
            // 
            // buttonPush
            // 
            this.buttonPush.Location = new System.Drawing.Point(218, 95);
            this.buttonPush.Name = "buttonPush";
            this.buttonPush.Size = new System.Drawing.Size(144, 47);
            this.buttonPush.TabIndex = 4;
            this.buttonPush.Text = "数据导入";
            this.buttonPush.UseVisualStyleBackColor = true;
            this.buttonPush.Click += new System.EventHandler(this.buttonPush_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar,
            this.toolStripStatusLabelText,
            this.toolStripStatusLabelDeviceTime,
            this.toolStripStatusLabelDataSync});
            this.statusStrip.Location = new System.Drawing.Point(0, 162);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(390, 22);
            this.statusStrip.TabIndex = 7;
            this.statusStrip.Text = "状态栏";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Maximum = 10;
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatusLabelText
            // 
            this.toolStripStatusLabelText.Name = "toolStripStatusLabelText";
            this.toolStripStatusLabelText.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabelDeviceTime
            // 
            this.toolStripStatusLabelDeviceTime.Name = "toolStripStatusLabelDeviceTime";
            this.toolStripStatusLabelDeviceTime.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabelDataSync
            // 
            this.toolStripStatusLabelDataSync.Name = "toolStripStatusLabelDataSync";
            this.toolStripStatusLabelDataSync.Size = new System.Drawing.Size(0, 17);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 184);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.buttonPush);
            this.Controls.Add(this.buttonTimeSync);
            this.Controls.Add(this.buttonPull);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.menuStripMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripMain;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 216);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 216);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "北京申通数据同步工具";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem 菜单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pC路径设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.Button buttonPull;
        private System.Windows.Forms.Button buttonTimeSync;
        private System.Windows.Forms.Button buttonPush;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemHelp;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelText;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelDeviceTime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelDataSync;
    }
}

