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

        static private byte[] findLoc = { 0x10, 0x35, 0x40, 0x00 };

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            //openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            openFileDialog1.Filter = "hex file (*.hex)|*.hex|All files (*.*)|*.*";
            //openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                BinaryReader br = new BinaryReader(new FileStream(openFileDialog1.FileName, FileMode.Open));
                //MessageBox.Show("File size : {0} bytes", br.BaseStream.Length.ToString());
                for (int i = 0; i <= br.BaseStream.Length; i++)
                {
                    //if (br.BaseStream.ReadByte() == (byte)0x01)
                    //{
                    //    Console.WriteLine("Found the byte 01 at offset " + i);
                    //    break;
                    //}

                }
                br.Close();
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

                textBox31.Text = inifile.IniReadValue("T0", "T1~T2", openFileDialog1.FileName);
                textBox32.Text = inifile.IniReadValue("T0", "T3~T4", openFileDialog1.FileName);
                textBox33.Text = inifile.IniReadValue("T0", "T5~T6", openFileDialog1.FileName);
                textBox34.Text = inifile.IniReadValue("T0", "T7~T8", openFileDialog1.FileName);

                textBox35.Text = inifile.IniReadValue("OFF", "T1~T2", openFileDialog1.FileName);
                textBox36.Text = inifile.IniReadValue("OFF", "T3~T4", openFileDialog1.FileName);
                textBox37.Text = inifile.IniReadValue("OFF", "T5~T6", openFileDialog1.FileName);
                textBox38.Text = inifile.IniReadValue("OFF", "T7~T8", openFileDialog1.FileName);

                /****************************************************************************************/

                textBox100.Text = inifile.IniReadValue("Time_H", "T1~T2", openFileDialog1.FileName);
                textBox99.Text = inifile.IniReadValue("Time_H", "T3~T4", openFileDialog1.FileName);
                textBox98.Text = inifile.IniReadValue("Time_H", "T5~T6", openFileDialog1.FileName);
                textBox97.Text = inifile.IniReadValue("Time_H", "T7~T8", openFileDialog1.FileName);

                textBox96.Text = inifile.IniReadValue("Time_R1-1", "T1~T2", openFileDialog1.FileName);
                textBox95.Text = inifile.IniReadValue("Time_R1-1", "T3~T4", openFileDialog1.FileName);
                textBox94.Text = inifile.IniReadValue("Time_R1-1", "T5~T6", openFileDialog1.FileName);
                textBox93.Text = inifile.IniReadValue("Time_R1-1", "T7~T8", openFileDialog1.FileName);

                textBox92.Text = inifile.IniReadValue("Time_R1-2", "T1~T2", openFileDialog1.FileName);
                textBox91.Text = inifile.IniReadValue("Time_R1-2", "T3~T4", openFileDialog1.FileName);
                textBox90.Text = inifile.IniReadValue("Time_R1-2", "T5~T6", openFileDialog1.FileName);
                textBox89.Text = inifile.IniReadValue("Time_R1-2", "T7~T8", openFileDialog1.FileName);

                textBox88.Text = inifile.IniReadValue("Time_R1-3", "T1~T2", openFileDialog1.FileName);
                textBox87.Text = inifile.IniReadValue("Time_R1-3", "T3~T4", openFileDialog1.FileName);
                textBox86.Text = inifile.IniReadValue("Time_R1-3", "T5~T6", openFileDialog1.FileName);
                textBox85.Text = inifile.IniReadValue("Time_R1-3", "T7~T8", openFileDialog1.FileName);

                textBox84.Text = inifile.IniReadValue("Time_R2-1", "T1~T2", openFileDialog1.FileName);
                textBox83.Text = inifile.IniReadValue("Time_R2-1", "T3~T4", openFileDialog1.FileName);
                textBox82.Text = inifile.IniReadValue("Time_R2-1", "T5~T6", openFileDialog1.FileName);
                textBox81.Text = inifile.IniReadValue("Time_R2-1", "T7~T8", openFileDialog1.FileName);

                textBox80.Text = inifile.IniReadValue("Time_R2-2", "T1~T2", openFileDialog1.FileName);
                textBox79.Text = inifile.IniReadValue("Time_R2-2", "T3~T4", openFileDialog1.FileName);
                textBox78.Text = inifile.IniReadValue("Time_R2-2", "T5~T6", openFileDialog1.FileName);
                textBox77.Text = inifile.IniReadValue("Time_R2-2", "T7~T8", openFileDialog1.FileName);

                textBox76.Text = inifile.IniReadValue("Time_R2-3", "T1~T2", openFileDialog1.FileName);
                textBox75.Text = inifile.IniReadValue("Time_R2-3", "T3~T4", openFileDialog1.FileName);
                textBox74.Text = inifile.IniReadValue("Time_R2-3", "T5~T6", openFileDialog1.FileName);
                textBox73.Text = inifile.IniReadValue("Time_R2-3", "T7~T8", openFileDialog1.FileName);

                textBox72.Text = inifile.IniReadValue("Time_T0", "T1~T2", openFileDialog1.FileName);
                textBox71.Text = inifile.IniReadValue("Time_T0", "T3~T4", openFileDialog1.FileName);
                textBox70.Text = inifile.IniReadValue("Time_T0", "T5~T6", openFileDialog1.FileName);
                textBox69.Text = inifile.IniReadValue("Time_T0", "T7~T8", openFileDialog1.FileName);

                textBox68.Text = inifile.IniReadValue("Time_OFF", "T1~T2", openFileDialog1.FileName);
                textBox67.Text = inifile.IniReadValue("Time_OFF", "T3~T4", openFileDialog1.FileName);
                textBox66.Text = inifile.IniReadValue("Time_OFF", "T5~T6", openFileDialog1.FileName);
                textBox65.Text = inifile.IniReadValue("Time_OFF", "T7~T8", openFileDialog1.FileName);

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

                inifile.IniWriteValue("T0", "T1~T2", textBox31.ToString(), saveFileDialog1.FileName);
                inifile.IniWriteValue("T0", "T3~T4", textBox32.ToString(), saveFileDialog1.FileName);
                inifile.IniWriteValue("T0", "T5~T6", textBox33.ToString(), saveFileDialog1.FileName);
                inifile.IniWriteValue("T0", "T7~T8", textBox34.ToString(), saveFileDialog1.FileName);

                inifile.IniWriteValue("OFF", "T1~T2", textBox35.ToString(), saveFileDialog1.FileName);
                inifile.IniWriteValue("OFF", "T3~T4", textBox36.ToString(), saveFileDialog1.FileName);
                inifile.IniWriteValue("OFF", "T5~T6", textBox37.ToString(), saveFileDialog1.FileName);
                inifile.IniWriteValue("OFF", "T7~T8", textBox38.ToString(), saveFileDialog1.FileName);

                /****************************************************************************************/

                inifile.IniWriteValue("Time_H", "T1~T2", textBox100.Text, saveFileDialog1.FileName);
                inifile.IniWriteValue("Time_H", "T3~T4", textBox99.Text, saveFileDialog1.FileName);
                inifile.IniWriteValue("Time_H", "T5~T6", textBox98.Text, saveFileDialog1.FileName);
                inifile.IniWriteValue("Time_H", "T7~T8", textBox97.Text, saveFileDialog1.FileName);

                inifile.IniWriteValue("Time_R1-1", "T1~T2", textBox96.Text, saveFileDialog1.FileName);
                inifile.IniWriteValue("Time_R1-1", "T3~T4", textBox95.Text, saveFileDialog1.FileName);
                inifile.IniWriteValue("Time_R1-1", "T5~T6", textBox94.Text, saveFileDialog1.FileName);
                inifile.IniWriteValue("Time_R1-1", "T7~T8", textBox93.Text, saveFileDialog1.FileName);

                inifile.IniWriteValue("Time_R1-2", "T1~T2", textBox92.Text, saveFileDialog1.FileName);
                inifile.IniWriteValue("Time_R1-2", "T3~T4", textBox91.Text, saveFileDialog1.FileName);
                inifile.IniWriteValue("Time_R1-2", "T5~T6", textBox90.Text, saveFileDialog1.FileName);
                inifile.IniWriteValue("Time_R1-2", "T7~T8", textBox89.Text, saveFileDialog1.FileName);

                inifile.IniWriteValue("Time_R1-3", "T1~T2", textBox88.Text, saveFileDialog1.FileName);
                inifile.IniWriteValue("Time_R1-3", "T3~T4", textBox87.Text, saveFileDialog1.FileName);
                inifile.IniWriteValue("Time_R1-3", "T5~T6", textBox86.Text, saveFileDialog1.FileName);
                inifile.IniWriteValue("Time_R1-3", "T7~T8", textBox85.Text, saveFileDialog1.FileName);

                inifile.IniWriteValue("Time_R2-1", "T1~T2", textBox84.Text, saveFileDialog1.FileName);
                inifile.IniWriteValue("Time_R2-1", "T3~T4", textBox83.Text, saveFileDialog1.FileName);
                inifile.IniWriteValue("Time_R2-1", "T5~T6", textBox82.Text, saveFileDialog1.FileName);
                inifile.IniWriteValue("Time_R2-1", "T7~T8", textBox81.Text, saveFileDialog1.FileName);

                inifile.IniWriteValue("Time_R2-2", "T1~T2", textBox80.Text, saveFileDialog1.FileName);
                inifile.IniWriteValue("Time_R2-2", "T3~T4", textBox79.Text, saveFileDialog1.FileName);
                inifile.IniWriteValue("Time_R2-2", "T5~T6", textBox78.Text, saveFileDialog1.FileName);
                inifile.IniWriteValue("Time_R2-2", "T7~T8", textBox77.Text, saveFileDialog1.FileName);

                inifile.IniWriteValue("Time_R2-3", "T1~T2", textBox76.Text, saveFileDialog1.FileName);
                inifile.IniWriteValue("Time_R2-3", "T3~T4", textBox75.Text, saveFileDialog1.FileName);
                inifile.IniWriteValue("Time_R2-3", "T5~T6", textBox74.Text, saveFileDialog1.FileName);
                inifile.IniWriteValue("Time_R2-3", "T7~T8", textBox73.Text, saveFileDialog1.FileName);

                inifile.IniWriteValue("Time_T0", "T1~T2", textBox72.ToString(), saveFileDialog1.FileName);
                inifile.IniWriteValue("Time_T0", "T3~T4", textBox71.ToString(), saveFileDialog1.FileName);
                inifile.IniWriteValue("Time_T0", "T5~T6", textBox70.ToString(), saveFileDialog1.FileName);
                inifile.IniWriteValue("Time_T0", "T7~T8", textBox69.ToString(), saveFileDialog1.FileName);

                inifile.IniWriteValue("Time_OFF", "T1~T2", textBox68.ToString(), saveFileDialog1.FileName);
                inifile.IniWriteValue("Time_OFF", "T3~T4", textBox67.ToString(), saveFileDialog1.FileName);
                inifile.IniWriteValue("Time_OFF", "T5~T6", textBox66.ToString(), saveFileDialog1.FileName);
                inifile.IniWriteValue("Time_OFF", "T7~T8", textBox65.ToString(), saveFileDialog1.FileName);
            }
        }
        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);

            //string hex1 = BitConverter.ToString(ba);
            //return hex1.Replace("-", "");

            return hex.ToString();
        }

        public static byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
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
