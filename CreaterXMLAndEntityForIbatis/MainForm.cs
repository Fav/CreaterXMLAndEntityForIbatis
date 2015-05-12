using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreaterXMLAndEntityForIbatis
{
    /// <summary>
    /// 信息界面
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// 构造
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            this.cmbLanguage.Items.AddRange(new string[] { "JAVA", "C#" });
            this.cmbLanguage.SelectedIndex = 0;
        }

        private void btnCreater_Click(object sender, EventArgs e)
        {
            this.btnCreater.Enabled = false;
            string message = CheckInfo();
            if (string.IsNullOrEmpty(message))
            {
                foreach (string name in lstFileName)
                {
                    CInputInfo info = new CInputInfo()
                    {
                        create = txtMan.Text,
                        savePath = txtSavePath.Text,
                        language = cmbLanguage.Text,
                        sqlPath = name,
                        packageName = tbPackageName.Text,
                    };
                    ActionOperation.Instance.ActionCreate(info);
                }
                MessageBox.Show("生成成功！");
            }
            else
            {
                MessageBox.Show(message);
                return;
            }
            this.btnCreater.Enabled = true;
        }

        private void btnSavePath_Click(object sender, EventArgs e)
        {
            this.txtSavePath.Text = GetPath();
        }
        List<string> lstFileName = new List<string>();
        private void btnSql_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            if (ofd.ShowDialog()!= System.Windows.Forms.DialogResult.OK)
            {
                return; 
            }
            lstFileName.Clear();
            lstFileName = ofd.FileNames.ToList();
            foreach (string name in lstFileName)
            {
                txtSQL.Text += name + "\r\n";
            }
        }

        private string GetPath()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return ""; 
            return fbd.SelectedPath;
        }

        private string CheckInfo()
        {
            string retStr = "";
            if (string.IsNullOrEmpty(txtMan.Text))
            {
                retStr = "创建人不能为空！";
            }
            else if (string.IsNullOrEmpty(txtSavePath.Text))
            {
                retStr = "保存路径不能为空！";
            }
            else if (string.IsNullOrEmpty(txtSQL.Text))
            {
                retStr = "脚本路径不能为空！";
            }
            else if (string.IsNullOrEmpty(cmbLanguage.Text))
            {
                retStr = "语言不能为空！";
            }
            else if (string.IsNullOrEmpty(tbPackageName.Text))
            {
                retStr = "包名不能为空！";
            }
            return retStr;
        }
    }
}
