using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;


namespace hexproj
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private IniFile inifile = new IniFile();

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            //openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            //openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //if ((myStream = openFileDialog1.OpenFile()) != null)
                    //{
                    //    using (myStream)
                    //    {
                    //        // Insert code to read the stream here.
                    //    }
                    //}
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "../";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ////label.text = inifile.IniReadValue(섹션이름, 키이름, inifile이름);
                //label.text = inifile.IniReadValue("Section1", "Key", "./test.ini");
                textBox3.Text = inifile.IniReadValue("H", "T1~T2", openFileDialog1.FileName);
                textBox4.Text = inifile.IniReadValue("H", "T3~T4", openFileDialog1.FileName);
                textBox5.Text = inifile.IniReadValue("H", "T5~T6", openFileDialog1.FileName);
                textBox6.Text = inifile.IniReadValue("H", "T7~T8", openFileDialog1.FileName);

                textBox7.Text = inifile.IniReadValue("R1-1", "T1~T2", openFileDialog1.FileName);
                textBox8.Text = inifile.IniReadValue("R1-1", "T3~T4", openFileDialog1.FileName);
                textBox9.Text = inifile.IniReadValue("R1-1", "T5~T6", openFileDialog1.FileName);
                textBox10.Text = inifile.IniReadValue("R1-1", "T7~T8", openFileDialog1.FileName);

                textBox11.Text = inifile.IniReadValue("R1-2", "T1~T2", openFileDialog1.FileName);
                textBox12.Text = inifile.IniReadValue("R1-2", "T3~T4", openFileDialog1.FileName);
                textBox13.Text = inifile.IniReadValue("R1-2", "T5~T6", openFileDialog1.FileName);
                textBox14.Text = inifile.IniReadValue("R1-2", "T7~T8", openFileDialog1.FileName);

                textBox15.Text = inifile.IniReadValue("R1-3", "T1~T2", openFileDialog1.FileName);
                textBox16.Text = inifile.IniReadValue("R1-3", "T3~T4", openFileDialog1.FileName);
                textBox17.Text = inifile.IniReadValue("R1-3", "T5~T6", openFileDialog1.FileName);
                textBox18.Text = inifile.IniReadValue("R1-3", "T7~T8", openFileDialog1.FileName);

                textBox19.Text = inifile.IniReadValue("R2-1", "T1~T2", openFileDialog1.FileName);
                textBox20.Text = inifile.IniReadValue("R2-1", "T3~T4", openFileDialog1.FileName);
                textBox21.Text = inifile.IniReadValue("R2-1", "T5~T6", openFileDialog1.FileName);
                textBox22.Text = inifile.IniReadValue("R2-1", "T7~T8", openFileDialog1.FileName);

                textBox23.Text = inifile.IniReadValue("R2-2", "T1~T2", openFileDialog1.FileName);
                textBox24.Text = inifile.IniReadValue("R2-2", "T3~T4", openFileDialog1.FileName);
                textBox25.Text = inifile.IniReadValue("R2-2", "T5~T6", openFileDialog1.FileName);
                textBox26.Text = inifile.IniReadValue("R2-2", "T7~T8", openFileDialog1.FileName);

                textBox27.Text = inifile.IniReadValue("R2-3", "T1~T2", openFileDialog1.FileName);
                textBox28.Text = inifile.IniReadValue("R2-3", "T3~T4", openFileDialog1.FileName);
                textBox29.Text = inifile.IniReadValue("R2-3", "T5~T6", openFileDialog1.FileName);
                textBox30.Text = inifile.IniReadValue("R2-3", "T7~T8", openFileDialog1.FileName);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            saveFileDialog1.Filter = "ini file (*.ini)|*.ini|All files (*.*)|*.*";
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //inifile.IniWriteValue(섹션이름, 키이름, 값, Inifile생성 위치);
                //inifile.IniWriteValue("Section1", "Key", "Value", "./test.ini");
                inifile.IniWriteValue("H", "T1~T2", textBox3.Text, saveFileDialog1.FileName);
                inifile.IniWriteValue("H", "T3~T4", textBox4.Text, saveFileDialog1.FileName);
                inifile.IniWriteValue("H", "T5~T6", textBox5.Text, saveFileDialog1.FileName);
                inifile.IniWriteValue("H", "T7~T8", textBox6.Text, saveFileDialog1.FileName);

                inifile.IniWriteValue("R1-1", "T1~T2", textBox7.Text, saveFileDialog1.FileName);
                inifile.IniWriteValue("R1-1", "T3~T4", textBox8.Text, saveFileDialog1.FileName);
                inifile.IniWriteValue("R1-1", "T5~T6", textBox9.Text, saveFileDialog1.FileName);
                inifile.IniWriteValue("R1-1", "T7~T8", textBox10.Text, saveFileDialog1.FileName);

                inifile.IniWriteValue("R1-2", "T1~T2", textBox11.Text, saveFileDialog1.FileName);
                inifile.IniWriteValue("R1-2", "T3~T4", textBox12.Text, saveFileDialog1.FileName);
                inifile.IniWriteValue("R1-2", "T5~T6", textBox13.Text, saveFileDialog1.FileName);
                inifile.IniWriteValue("R1-2", "T7~T8", textBox14.Text, saveFileDialog1.FileName);

                inifile.IniWriteValue("R1-3", "T1~T2", textBox15.Text, saveFileDialog1.FileName);
                inifile.IniWriteValue("R1-3", "T3~T4", textBox16.Text, saveFileDialog1.FileName);
                inifile.IniWriteValue("R1-3", "T5~T6", textBox17.Text, saveFileDialog1.FileName);
                inifile.IniWriteValue("R1-3", "T7~T8", textBox18.Text, saveFileDialog1.FileName);

                inifile.IniWriteValue("R2-1", "T1~T2", textBox19.Text, saveFileDialog1.FileName);
                inifile.IniWriteValue("R2-1", "T3~T4", textBox20.Text, saveFileDialog1.FileName);
                inifile.IniWriteValue("R2-1", "T5~T6", textBox21.Text, saveFileDialog1.FileName);
                inifile.IniWriteValue("R2-1", "T7~T8", textBox22.Text, saveFileDialog1.FileName);

                inifile.IniWriteValue("R2-2", "T1~T2", textBox23.Text, saveFileDialog1.FileName);
                inifile.IniWriteValue("R2-2", "T3~T4", textBox24.Text, saveFileDialog1.FileName);
                inifile.IniWriteValue("R2-2", "T5~T6", textBox25.Text, saveFileDialog1.FileName);
                inifile.IniWriteValue("R2-2", "T7~T8", textBox26.Text, saveFileDialog1.FileName);

                inifile.IniWriteValue("R2-3", "T1~T2", textBox27.Text, saveFileDialog1.FileName);
                inifile.IniWriteValue("R2-3", "T3~T4", textBox28.Text, saveFileDialog1.FileName);
                inifile.IniWriteValue("R2-3", "T5~T6", textBox29.Text, saveFileDialog1.FileName);
                inifile.IniWriteValue("R2-3", "T7~T8", textBox30.Text, saveFileDialog1.FileName);

                //inifile.IniWriteValue("R1-3", "T1~T2", textBox15.ToString(), saveFileDialog1.FileName);
                //inifile.IniWriteValue("R1-3", "T3~T4", textBox16.ToString(), saveFileDialog1.FileName);
                //inifile.IniWriteValue("R1-3", "T5~T6", textBox17.ToString(), saveFileDialog1.FileName);
                //inifile.IniWriteValue("R1-3", "T7~T8", textBox18.ToString(), saveFileDialog1.FileName);

                //inifile.IniWriteValue("R1-3", "T1~T2", textBox15.ToString(), saveFileDialog1.FileName);
                //inifile.IniWriteValue("R1-3", "T3~T4", textBox16.ToString(), saveFileDialog1.FileName);
                //inifile.IniWriteValue("R1-3", "T5~T6", textBox17.ToString(), saveFileDialog1.FileName);
                //inifile.IniWriteValue("R1-3", "T7~T8", textBox18.ToString(), saveFileDialog1.FileName);
            }
        }
    }

    public class IniFile
    {
        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileString(
            String section, String key, String def, StringBuilder retVal, int Size, String filePat);

        [DllImport("Kernel32.dll")]
        private static extern long WritePrivateProfileString(
            String Section, String Key, String val, String filePath);

        public void IniWriteValue(String Section, String Key, String Value, string avaPath)
        {
            WritePrivateProfileString(Section, Key, Value, avaPath);
        }

        public String IniReadValue(String Section, String Key, string avsPath)
        {
            StringBuilder temp = new StringBuilder(2000);
            int i = GetPrivateProfileString(Section, Key, "", temp, 2000, avsPath);
            return temp.ToString();
        }
    }


}
