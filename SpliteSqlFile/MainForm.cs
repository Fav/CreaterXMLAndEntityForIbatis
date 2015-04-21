using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpliteSqlFile
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnSql_Click(object sender, EventArgs e)
        {
            txtSQL.Text = GetFilePath();
        }

        private void btnSavePath_Click(object sender, EventArgs e)
        {
            txtSavePath.Text = GetDirPath();
        }

        private void btnCreater_Click(object sender, EventArgs e)
        {
            string message = CheckInfo();
            if (!string.IsNullOrEmpty(message))
            {
                MessageBox.Show(message);
                return;
            }
            string context = File.ReadAllText(txtSQL.Text);
            string splitStr = "--";
            string[] parts = context.Split(new string[] { splitStr }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < parts.Length; i++)
            {
                string[] txt = parts[i].Split(new string[] { Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
                string filename = txt[0];
                File.WriteAllText(string.Format("{0}/{1}.txt", txtSavePath.Text, filename), splitStr + parts[i], Encoding.UTF8);
            }
            MessageBox.Show("完成");
        }
        private string GetDirPath()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return "";
            return fbd.SelectedPath;
        }
        private string GetFilePath()
        {
            OpenFileDialog fbd = new OpenFileDialog();
            if (fbd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return "";
            return fbd.FileName;
        }
        private string CheckInfo()
        {
            string retStr = "";
            if (string.IsNullOrEmpty(txtSavePath.Text))
            {
                retStr = "保存路径不能为空！";
            }
            else if (string.IsNullOrEmpty(txtSQL.Text))
            {
                retStr = "脚本路径不能为空！";
            }
            return retStr;
        }
    }
}
