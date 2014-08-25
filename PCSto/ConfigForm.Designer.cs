namespace PCSto
{
    partial class ConfigForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonSystemDataPath = new System.Windows.Forms.Button();
            this.textBoxSystemDataPath = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonScanDataPath = new System.Windows.Forms.Button();
            this.textBoxScanDataPath = new System.Windows.Forms.TextBox();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonSystemDataPath);
            this.groupBox1.Controls.Add(this.textBoxSystemDataPath);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 68);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PC基础数据路径";
            // 
            // buttonSystemDataPath
            // 
            this.buttonSystemDataPath.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonSystemDataPath.Location = new System.Drawing.Point(214, 28);
            this.buttonSystemDataPath.Name = "buttonSystemDataPath";
            this.buttonSystemDataPath.Size = new System.Drawing.Size(39, 23);
            this.buttonSystemDataPath.TabIndex = 1;
            this.buttonSystemDataPath.Text = "...";
            this.buttonSystemDataPath.UseVisualStyleBackColor = true;
            this.buttonSystemDataPath.Click += new System.EventHandler(this.buttonSystemDataPath_Click);
            // 
            // textBoxSystemDataPath
            // 
            this.textBoxSystemDataPath.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxSystemDataPath.Location = new System.Drawing.Point(7, 29);
            this.textBoxSystemDataPath.Name = "textBoxSystemDataPath";
            this.textBoxSystemDataPath.Size = new System.Drawing.Size(201, 21);
            this.textBoxSystemDataPath.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonScanDataPath);
            this.groupBox2.Controls.Add(this.textBoxScanDataPath);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(13, 87);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(259, 68);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "PC扫描数据保存";
            // 
            // buttonScanDataPath
            // 
            this.buttonScanDataPath.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonScanDataPath.Location = new System.Drawing.Point(214, 27);
            this.buttonScanDataPath.Name = "buttonScanDataPath";
            this.buttonScanDataPath.Size = new System.Drawing.Size(39, 23);
            this.buttonScanDataPath.TabIndex = 3;
            this.buttonScanDataPath.Text = "...";
            this.buttonScanDataPath.UseVisualStyleBackColor = true;
            this.buttonScanDataPath.Click += new System.EventHandler(this.buttonScanDataPath_Click);
            // 
            // textBoxScanDataPath
            // 
            this.textBoxScanDataPath.Font = new System.Drawing.Font("宋体", 9F);
            this.textBoxScanDataPath.Location = new System.Drawing.Point(7, 28);
            this.textBoxScanDataPath.Name = "textBoxScanDataPath";
            this.textBoxScanDataPath.Size = new System.Drawing.Size(201, 21);
            this.textBoxScanDataPath.TabIndex = 2;
            // 
            // buttonAccept
            // 
            this.buttonAccept.Location = new System.Drawing.Point(13, 163);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(121, 23);
            this.buttonAccept.TabIndex = 2;
            this.buttonAccept.Text = "保存";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(151, 163);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(121, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.SelectedPath = "C:\\Users\\Administrator\\Desktop";
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 198);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 236);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 236);
            this.Name = "ConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "路径设置";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxSystemDataPath;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonScanDataPath;
        private System.Windows.Forms.TextBox textBoxScanDataPath;
        private System.Windows.Forms.Button buttonSystemDataPath;
        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;

    }
}