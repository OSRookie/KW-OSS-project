using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;
using System.Security.Cryptography;
using System.Threading;

namespace EncryptDocuments
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            FileMenu(Application.ExecutablePath + ",0", Application.ExecutablePath);
            string[] str = Environment.GetCommandLineArgs();
            try
            {
                string strFile = "";
                for (int i = 2; i < str.Length; i++)
                    strFile += str[i];
                FileInfo FInfo = new FileInfo(strFile);
                if (FInfo.Extension.ToLower() == ".fe")
                {
                    txt_file.Text = strFile;
                    btn_enc.Enabled = false;
                    btn_dec.Enabled = true;
                }
            }
            catch { }
        }
        //암호화,복호화 파일 선택
        private void btn_open_Click(object sender, EventArgs e)
        {
            if (ofd_Menu.ShowDialog() == DialogResult.OK)
            {
                txt_file.Text = ofd_Menu.FileName;
                FileInfo fileInfo = new FileInfo(txt_file.Text);
                if (fileInfo.Extension.ToLower() == ".fe")
                {
                    btn_enc.Enabled = false;
                    btn_dec.Enabled = true;
                }
                else
                {
                    btn_enc.Enabled = true;
                    btn_dec.Enabled = false;
                }
            }
        }
        //바로 가기 메뉴
        public static void FileMenu(string strPath, string strName)
        {
            try
            {
                Registry.ClassesRoot.CreateSubKey(".fe");
                RegistryKey RKey1 = Registry.ClassesRoot.OpenSubKey(".fe", true);
                RKey1.SetValue("", "fefile");
                RKey1.Close();
                Registry.ClassesRoot.CreateSubKey("fefile");
                RegistryKey RKey2 = Registry.ClassesRoot.OpenSubKey("fefile", true);
                RKey2.CreateSubKey("DefaultIcon");
                RKey2.CreateSubKey("shell");
                RKey2.Close();
                RegistryKey RKey3 = Registry.ClassesRoot.OpenSubKey("fefile\\DefaultIcon", true);
                RKey3.SetValue("", strPath);
                RKey3.Close();
                RegistryKey RKey4 = Registry.ClassesRoot.OpenSubKey("fefile\\shell", true);
                RKey4.CreateSubKey("복호화");
                RKey4.Close();
                RegistryKey RKey5 = Registry.ClassesRoot.OpenSubKey("fefile\\shell\\복호화", true);
                RKey5.CreateSubKey("command");
                RKey5.Close();
                RegistryKey RKey6 = Registry.ClassesRoot.OpenSubKey("fefile\\shell\\복호화\\command", true);
                RKey6.SetValue("", strName + " \\F %1");
                RKey6.Close();
            }
            catch
            {
            }
        }
        //비밀번호 표시
        private void chk_password_CheckedChanged(object sender, EventArgs e)
        {
            bool ch=chk_password.Checked;
            if (ch == true)
            {
                txt_password.UseSystemPasswordChar = false;
            }else if(ch == false)
            {
                txt_password.UseSystemPasswordChar = true;
            }
            
        }

        //파일 암호화
        private void btn_enc_Click(object sender, EventArgs e)
        {

        }
        //파일 복호화
        private void btn_dec_Click(object sender, EventArgs e)
        {

        }

        
    }

    #region 암호화,복호화클라스
    class EDncrypt
    {
        private string strFile = "";
        private string strNewFile = "";
        private string strPwd = "";
        private ProgressBar PBar = null;
        private Thread EThread = null;
        private Thread DThread = null;
        public EDncrypt(string name,string pwd,ProgressBar pb)
        {
            strFile = name;
            strPwd = pwd;
            PBar = pb;
            EThread = new Thread(new ThreadStart(this.myEThread));
            DThread = new Thread(new ThreadStart(this.myDThread));
        }
        //문서 암호화  
        private void myDThread()
        {
            throw new NotImplementedException();
        }
        //파일 복호화
        private void myEThread()
        {
            throw new NotImplementedException();
        }

        //암호화 스레드 실행
        public void StartEncrypt()
        {
            EThread.Start();
        }
        //복호화 스레드 실행
        public void StartDncrypt()
        {
            DThread.Start();
        }
    }
    #endregion

}
