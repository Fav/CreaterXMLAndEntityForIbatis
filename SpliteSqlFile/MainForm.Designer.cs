namespace SpliteSqlFile
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
            this.label4 = new System.Windows.Forms.Label();
            this.txtSQL = new System.Windows.Forms.TextBox();
            this.btnSql = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSavePath = new System.Windows.Forms.TextBox();
            this.btnSavePath = new System.Windows.Forms.Button();
            this.btnCreater = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(14, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 12);
            this.label4.TabIndex = 15;
            this.label4.Text = "SQL脚本路径：";
            // 
            // txtSQL
            // 
            this.txtSQL.Location = new System.Drawing.Point(123, 24);
            this.txtSQL.Name = "txtSQL";
            this.txtSQL.ReadOnly = true;
            this.txtSQL.Size = new System.Drawing.Size(314, 21);
            this.txtSQL.TabIndex = 14;
            // 
            // btnSql
            // 
            this.btnSql.BackColor = System.Drawing.Color.Transparent;
            this.btnSql.Image = ((System.Drawing.Image)(resources.GetObject("btnSql.Image")));
            this.btnSql.Location = new System.Drawing.Point(443, 20);
            this.btnSql.Name = "btnSql";
            this.btnSql.Size = new System.Drawing.Size(34, 26);
            this.btnSql.TabIndex = 13;
            this.btnSql.UseVisualStyleBackColor = false;
            this.btnSql.Click += new System.EventHandler(this.btnSql_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(35, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "保存路径：";
            // 
            // txtSavePath
            // 
            this.txtSavePath.Location = new System.Drawing.Point(123, 71);
            this.txtSavePath.Name = "txtSavePath";
            this.txtSavePath.ReadOnly = true;
            this.txtSavePath.Size = new System.Drawing.Size(314, 21);
            this.txtSavePath.TabIndex = 11;
            // 
            // btnSavePath
            // 
            this.btnSavePath.BackColor = System.Drawing.Color.Transparent;
            this.btnSavePath.Image = ((System.Drawing.Image)(resources.GetObject("btnSavePath.Image")));
            this.btnSavePath.Location = new System.Drawing.Point(443, 71);
            this.btnSavePath.Name = "btnSavePath";
            this.btnSavePath.Size = new System.Drawing.Size(34, 26);
            this.btnSavePath.TabIndex = 10;
            this.btnSavePath.UseVisualStyleBackColor = false;
            this.btnSavePath.Click += new System.EventHandler(this.btnSavePath_Click);
            // 
            // btnCreater
            // 
            this.btnCreater.BackColor = System.Drawing.Color.Transparent;
            this.btnCreater.Image = ((System.Drawing.Image)(resources.GetObject("btnCreater.Image")));
            this.btnCreater.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreater.Location = new System.Drawing.Point(416, 115);
            this.btnCreater.Name = "btnCreater";
            this.btnCreater.Size = new System.Drawing.Size(61, 26);
            this.btnCreater.TabIndex = 16;
            this.btnCreater.Text = "创建";
            this.btnCreater.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCreater.UseVisualStyleBackColor = false;
            this.btnCreater.Click += new System.EventHandler(this.btnCreater_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::SpliteSqlFile.Properties.Resources.QQ截图20150421114649;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(515, 157);
            this.Controls.Add(this.btnCreater);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSQL);
            this.Controls.Add(this.btnSql);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSavePath);
            this.Controls.Add(this.btnSavePath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "分割Sql";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSQL;
        private System.Windows.Forms.Button btnSql;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSavePath;
        private System.Windows.Forms.Button btnSavePath;
        private System.Windows.Forms.Button btnCreater;
    }
}

