namespace CreaterXMLAndEntityForIbatis
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
            this.btnSavePath = new System.Windows.Forms.Button();
            this.txtMan = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSavePath = new System.Windows.Forms.TextBox();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSQL = new System.Windows.Forms.TextBox();
            this.btnSql = new System.Windows.Forms.Button();
            this.btnCreater = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tbPackageName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSavePath
            // 
            this.btnSavePath.BackColor = System.Drawing.Color.Transparent;
            this.btnSavePath.Image = ((System.Drawing.Image)(resources.GetObject("btnSavePath.Image")));
            this.btnSavePath.Location = new System.Drawing.Point(444, 218);
            this.btnSavePath.Name = "btnSavePath";
            this.btnSavePath.Size = new System.Drawing.Size(34, 26);
            this.btnSavePath.TabIndex = 0;
            this.btnSavePath.UseVisualStyleBackColor = false;
            this.btnSavePath.Click += new System.EventHandler(this.btnSavePath_Click);
            // 
            // txtMan
            // 
            this.txtMan.Location = new System.Drawing.Point(124, 20);
            this.txtMan.Name = "txtMan";
            this.txtMan.Size = new System.Drawing.Size(139, 21);
            this.txtMan.TabIndex = 1;
            this.txtMan.Text = "huqi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(48, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "创建人：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(36, 226);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "保存路径：";
            // 
            // txtSavePath
            // 
            this.txtSavePath.Location = new System.Drawing.Point(124, 223);
            this.txtSavePath.Name = "txtSavePath";
            this.txtSavePath.ReadOnly = true;
            this.txtSavePath.Size = new System.Drawing.Size(314, 21);
            this.txtSavePath.TabIndex = 3;
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.BackColor = System.Drawing.SystemColors.Window;
            this.cmbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.Location = new System.Drawing.Point(341, 19);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(137, 20);
            this.cmbLanguage.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(292, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "语言：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(15, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "SQL脚本路径：";
            // 
            // txtSQL
            // 
            this.txtSQL.Location = new System.Drawing.Point(124, 74);
            this.txtSQL.Multiline = true;
            this.txtSQL.Name = "txtSQL";
            this.txtSQL.ReadOnly = true;
            this.txtSQL.Size = new System.Drawing.Size(314, 132);
            this.txtSQL.TabIndex = 8;
            // 
            // btnSql
            // 
            this.btnSql.BackColor = System.Drawing.Color.Transparent;
            this.btnSql.Image = ((System.Drawing.Image)(resources.GetObject("btnSql.Image")));
            this.btnSql.Location = new System.Drawing.Point(444, 76);
            this.btnSql.Name = "btnSql";
            this.btnSql.Size = new System.Drawing.Size(34, 26);
            this.btnSql.TabIndex = 7;
            this.btnSql.UseVisualStyleBackColor = false;
            this.btnSql.Click += new System.EventHandler(this.btnSql_Click);
            // 
            // btnCreater
            // 
            this.btnCreater.BackColor = System.Drawing.Color.Transparent;
            this.btnCreater.Image = ((System.Drawing.Image)(resources.GetObject("btnCreater.Image")));
            this.btnCreater.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreater.Location = new System.Drawing.Point(417, 258);
            this.btnCreater.Name = "btnCreater";
            this.btnCreater.Size = new System.Drawing.Size(61, 26);
            this.btnCreater.TabIndex = 10;
            this.btnCreater.Text = "创建";
            this.btnCreater.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCreater.UseVisualStyleBackColor = false;
            this.btnCreater.Click += new System.EventHandler(this.btnCreater_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(36, 265);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(365, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "说明：目前此工具只支持如：“YPAA01A”  的标准命名SQL语句脚本";
            // 
            // tbPackageName
            // 
            this.tbPackageName.Location = new System.Drawing.Point(124, 47);
            this.tbPackageName.Name = "tbPackageName";
            this.tbPackageName.Size = new System.Drawing.Size(139, 21);
            this.tbPackageName.TabIndex = 1;
            this.tbPackageName.Text = "dzsb";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(48, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "包名：";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(515, 301);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCreater);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSQL);
            this.Controls.Add(this.btnSql);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbLanguage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSavePath);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPackageName);
            this.Controls.Add(this.txtMan);
            this.Controls.Add(this.btnSavePath);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IBATISTOOL";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSavePath;
        private System.Windows.Forms.TextBox txtMan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSavePath;
        private System.Windows.Forms.ComboBox cmbLanguage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSQL;
        private System.Windows.Forms.Button btnSql;
        private System.Windows.Forms.Button btnCreater;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbPackageName;
        private System.Windows.Forms.Label label6;
    }
}

