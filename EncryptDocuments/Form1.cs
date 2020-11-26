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
                FileInfo FInfo = new FileInfo(txt_file.Text);
                if (FInfo.Extension.ToLower() == ".fe")
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
            if (txt_file.Text != "")
            {
                if (txt_password.Text.Length < 6)
                    MessageBox.Show("비밀번호는 6 자리 이상이어야합니다！", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (txt_password.Text.Length >8)
                    MessageBox.Show("비밀번호는 8 자리를 초과 할 수 없습니다！", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    EDncrypt myEDncrypt = new EDncrypt(txt_file.Text, txt_password.Text, progressBar1);
                    myEDncrypt.StartEncrypt();
                    progressBar1.Value = 0;
                }
            }
        }
        //파일 복호화
        private void btn_dec_Click(object sender, EventArgs e)
        {
            if (txt_file.Text != "")
            {
                if (txt_password.Text.Length < 6)
                    MessageBox.Show("비밀번호는 6 자리 이상이어야합니다！", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (txt_password.Text.Length > 8)
                    MessageBox.Show("비밀번호는 8 자리를 초과 할 수 없습니다！", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    EDncrypt myEDncrypt = new EDncrypt(txt_file.Text, txt_password.Text, progressBar1);
                    myEDncrypt.StartDncrypt();
                    progressBar1.Value = 0;
                }
            }
        }

        
    }

    #region 암호화,복호화클라스
    class EDncrypt
    {
        private string strFile = "";
        private string strNewFile = ""; //복호화때 필요
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
        //파일 암호화
        private void myEThread()
        {
            FileStream FStream = null;
            FileStream NewFStream = null;
            DES myDES = null;
            CryptoStream CStream = null;
            try
            {
                try
                {
                    byte[] btRKey = new byte[0];
                    int pwdLength = strPwd.Length;
                    if (pwdLength == 6)
                    {
                        btRKey = new byte[] { (byte)strPwd[0], (byte)strPwd[1], (byte)strPwd[2], (byte)strPwd[3], (byte)strPwd[4], (byte)strPwd[5], (byte)strPwd[0], (byte)strPwd[1] };
                    }
                    if (pwdLength == 7)
                    {
                        btRKey = new byte[] { (byte)strPwd[0], (byte)strPwd[1], (byte)strPwd[2], (byte)strPwd[3], (byte)strPwd[4], (byte)strPwd[5], (byte)strPwd[6], (byte)strPwd[0] };
                    }
                    if (pwdLength == 8)
                    {
                        btRKey = new byte[] { (byte)strPwd[0], (byte)strPwd[1], (byte)strPwd[2], (byte)strPwd[3], (byte)strPwd[4], (byte)strPwd[5], (byte)strPwd[6], (byte)strPwd[7] };
                    }
                    FStream = new FileStream(strFile, FileMode.Open, FileAccess.Read);
                    NewFStream = new FileStream(strFile + ".fe", FileMode.OpenOrCreate, FileAccess.Write);
                    NewFStream.SetLength((long)0);
                    byte[] buffer = new byte[0x400];
                    int MinNum = 0;
                    long length = FStream.Length;
                    int MaxNum = (int)(length / ((long)0x400));
                    PBar.Maximum = MaxNum;
                    myDES = new DESCryptoServiceProvider();
                    CStream = new CryptoStream(NewFStream, myDES.CreateEncryptor(btRKey, btRKey), CryptoStreamMode.Write);
                    while (MinNum < length)
                    {
                        int count = FStream.Read(buffer, 0, 0x400);
                        CStream.Write(buffer, 0, count);
                        MinNum += count;
                        try
                        {
                            if (PBar.Value < PBar.Maximum)
                            {
                                PBar.Value++;
                            }
                        }
                        catch
                        {
                        }
                    }
                    CStream.Close();
                    NewFStream.Close();
                    FStream.Close();
                    File.Delete(strFile);
                    MessageBox.Show("암호화 성공！", "신속한", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch { 

                }
            }
            catch { }
        }

        //문서 복호화
        private void myDThread()
        {
            FileStream FStream = null;
            FileStream NewFStream = null;
            CryptoStream CStream = null;
            try
            {
                try
                {
                    byte[] btRKey = new byte[0];
                    int pwdLength = strPwd.Length;
                    if (pwdLength == 6)
                    {
                        btRKey = new byte[] { (byte)strPwd[0], (byte)strPwd[1], (byte)strPwd[2], (byte)strPwd[3], (byte)strPwd[4], (byte)strPwd[5], (byte)strPwd[0], (byte)strPwd[1] };
                    }
                    if (pwdLength == 7)
                    {
                        btRKey = new byte[] { (byte)strPwd[0], (byte)strPwd[1], (byte)strPwd[2], (byte)strPwd[3], (byte)strPwd[4], (byte)strPwd[5], (byte)strPwd[6], (byte)strPwd[0] };
                    }
                    if (pwdLength == 8)
                    {
                        btRKey = new byte[] { (byte)strPwd[0], (byte)strPwd[1], (byte)strPwd[2], (byte)strPwd[3], (byte)strPwd[4], (byte)strPwd[5], (byte)strPwd[6], (byte)strPwd[7] };
                    }
                    FStream = new FileStream(strFile, FileMode.Open, FileAccess.Read);
                    strNewFile = strFile.Substring(0, strFile.Length - 3);
                    NewFStream = new FileStream(strNewFile, FileMode.OpenOrCreate, FileAccess.Write);
                    NewFStream.SetLength((long)0);
                    byte[] buffer = new byte[0x400];
                    int MinNum = 0;
                    long length = FStream.Length;
                    int MaxNum = (int)(length / ((long)0x400));
                    PBar.Maximum = MaxNum;
                    DES myDES = new DESCryptoServiceProvider();
                    CStream = new CryptoStream(NewFStream, myDES.CreateDecryptor(btRKey, btRKey), CryptoStreamMode.Write);
                    while (MinNum < length)
                    {
                        int count = FStream.Read(buffer, 0, 0x400);
                        CStream.Write(buffer, 0, count);
                        MinNum += count;
                        try
                        {
                            if (PBar.Value < PBar.Maximum)
                            {
                                PBar.Value++;
                            }
                        }
                        catch
                        {
                        }
                    }
                    MessageBox.Show("파일 복호화 성공！", "신속한", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("파일 복호화 실패！", "실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                CStream.Close();
                FStream.Close();
                NewFStream.Close();
            }
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
