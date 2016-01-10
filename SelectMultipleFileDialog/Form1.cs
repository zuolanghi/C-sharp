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

namespace SelectMultipleFileDialog
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "d:/";
            ofd.RestoreDirectory = true;
            // ofd.Filter = "jpeg图片(*.jpg)|*.jpg|png图片(*.png)|*.png|IMAGE(*.img)|*.img";
            ofd.Filter = "(*.*)|*";

            ofd.FilterIndex = 1;
            ofd.ShowHelp = true;
            ofd.Multiselect = true;
            ofd.ShowDialog();

            string []filesNames =ofd.FileNames;
            string filename = ofd.FileName;

            this.textBox1.Text = filename;
            List<DataFile> list = new List<DataFile>(filesNames.Length);
            
            for(int i=0;i<filesNames.Length; i++)
            {
                DataFile df = new DataFile();
                FileInfo file = new FileInfo(filesNames[i]);
                if (file.Exists)
                {
                    df.id = i;
                    df.fileName = file.Name;
                    df.size = file.Length;
                    df.fileType = file.Extension;
                    df.path = filesNames[i];
                    list.Add(df);
                }  
            }
            this.dataGridView1.DataSource = list;
        }
    }
}
