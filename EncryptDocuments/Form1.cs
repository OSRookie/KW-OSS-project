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
            
        }

        //암호화,복호화 파일 선택
        private void btn_open_Click(object sender, EventArgs e)
        {
            if (ofd_Menu.ShowDialog() == DialogResult.OK)
            {
                txt_file.Text = ofd_Menu.FileName;
                FileInfo fileInfo = new FileInfo(txt_file.Text);
                
            }
        }

        

    }
}
