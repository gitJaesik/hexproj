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

        string wholeFile = "";
        string upperFile = "";
        string downFile = "";
        string modifyFile = "";
        string currentLine = "";

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

                char semicolonVal;
                //byte[] dataCount;
                char[] readDataSize = new char[1*2];
                char[] readAddress = new char[2*2];
                char[] readRecordType = new char[1*2]; // EOF == 0x01
                char[] readData = new char[16*2];      // MAX == 0x10
                char[] readChecksum = new char[1*2];
                char[] readLineSplit = new char[2];

                string tmpStr;
                string currentAddress;

                int statusOfFiled = 0;

                bool endFlag = false;

                while (true)
                {
                    if (endFlag == true)
                        break;

                    semicolonVal = br.ReadChar();
                    currentLine += semicolonVal;

                    readDataSize = br.ReadChars(2);
                    currentLine += new string(readDataSize);

                    readAddress = br.ReadChars(4);
                    currentLine += new string(readAddress);

                    readRecordType = br.ReadChars(2);
                    currentLine += new string(readRecordType);

                    //if (readRecordType[1].CompareTo('1') == 0)
                    if (readRecordType[1] == '1')
                        endFlag = true;
                    // 00 Data, 01 End Of File, 02~05 address

                    int lengthOfHexData = twoHexCharToIntNumber(readDataSize[0], readDataSize[1]);
                    readData = br.ReadChars(lengthOfHexData * 2);
                    currentLine += new string(readData);

                    readChecksum = br.ReadChars(2);
                    currentLine += new string(readChecksum);

                    //if (endFlag == false)
                    //{
                    readLineSplit = br.ReadChars(2);
                    currentLine += new string(readLineSplit);
                    //}

                    // 원하는 주소값을 찾으면, 작업 시작
                    currentAddress = new string(readAddress);
                    //if(currentAddress == "3540" || currentAddress == "3550" ....);
                    if(currentAddress.CompareTo("3540") == 0||
                       currentAddress.CompareTo("3550") == 0|| 
                       currentAddress.CompareTo("3560") == 0|| 
                       currentAddress.CompareTo("3570") == 0|| 
                       currentAddress.CompareTo("3580") == 0|| 
                       currentAddress.CompareTo("3590") == 0|| 
                       currentAddress.CompareTo("35A0") == 0)
                    {
                        switch(currentAddress)
                        {
                            case "3540":
                                statusOfFiled = 1;
                                textBox110.Text = readData[11*2+0]+""+readData[11*2+1];
                                textBox109.Text = readData[12*2+0]+""+readData[12*2+1];
                                textBox108.Text = readData[13*2+0]+""+readData[13*2+1];
                                textBox107.Text = readData[14*2+0]+""+readData[14*2+1];
                                textBox3.Text = readData[15*2+0]+""+readData[15*2+1];
                                break;
                            case "3550":
                                textBox4.Text = readData[0*2+0]+""+readData[0*2+1];
                                textBox5.Text = readData[1*2+0]+""+readData[1*2+1];
                                textBox6.Text = readData[2*2+0]+""+readData[2*2+1];
                                textBox7.Text = readData[3*2+0]+""+readData[3*2+1];
                                textBox8.Text = readData[4*2+0]+""+readData[4*2+1];
                                textBox9.Text = readData[5*2+0]+""+readData[5*2+1];
                                textBox10.Text = readData[6*2+0]+""+readData[6*2+1];
                                textBox11.Text = readData[7*2+0]+""+readData[7*2+1];
                                textBox12.Text = readData[8*2+0]+""+readData[8*2+1];
                                textBox13.Text = readData[9*2+0]+""+readData[9*2+1];
                                textBox14.Text = readData[10*2+0]+""+readData[10*2+1];
                                textBox15.Text = readData[11*2+0]+""+readData[11*2+1];
                                textBox16.Text = readData[12*2+0]+""+readData[12*2+1];
                                textBox17.Text = readData[13*2+0]+""+readData[13*2+1];
                                textBox18.Text = readData[14*2+0]+""+readData[14*2+1];
                                textBox19.Text = readData[15*2+0]+""+readData[15*2+1];
                                break;
                            case "3560":
                                textBox20.Text = readData[0*2+0]+""+readData[0*2+1];
                                textBox21.Text = readData[1*2+0]+""+readData[1*2+1];
                                textBox22.Text = readData[2*2+0]+""+readData[2*2+1];
                                textBox23.Text = readData[3*2+0]+""+readData[3*2+1];
                                textBox24.Text = readData[4*2+0]+""+readData[4*2+1];
                                textBox25.Text = readData[5*2+0]+""+readData[5*2+1];
                                textBox26.Text = readData[6*2+0]+""+readData[6*2+1];
                                textBox27.Text = readData[7*2+0]+""+readData[7*2+1];
                                textBox28.Text = readData[8*2+0]+""+readData[8*2+1];
                                textBox29.Text = readData[9*2+0]+""+readData[9*2+1];
                                textBox30.Text = readData[10*2+0]+""+readData[10*2+1];
                                textBox31.Text = readData[11*2+0]+""+readData[11*2+1];
                                textBox32.Text = readData[12*2+0]+""+readData[12*2+1];
                                textBox33.Text = readData[13*2+0]+""+readData[13*2+1];
                                textBox34.Text = readData[14*2+0]+""+readData[14*2+1];
                                textBox35.Text = readData[15*2+0]+""+readData[15*2+1];
                                break;
                            case "3570":
                                textBox36.Text = readData[0*2+0]+""+readData[0*2+1];
                                textBox37.Text = readData[1*2+0]+""+readData[1*2+1];
                                textBox38.Text = readData[2*2+0]+""+readData[2*2+1];
                                textBox100.Text = readData[3*2+0]+""+readData[3*2+1];
                                textBox99.Text = readData[4*2+0]+""+readData[4*2+1];
                                textBox98.Text = readData[5*2+0]+""+readData[5*2+1];
                                textBox97.Text = readData[6*2+0]+""+readData[6*2+1];
                                textBox96.Text = readData[7*2+0]+""+readData[7*2+1];
                                textBox95.Text = readData[8*2+0]+""+readData[8*2+1];
                                textBox94.Text = readData[9*2+0]+""+readData[9*2+1];
                                textBox93.Text = readData[10*2+0]+""+readData[10*2+1];
                                textBox92.Text = readData[11*2+0]+""+readData[11*2+1];
                                textBox91.Text = readData[12*2+0]+""+readData[12*2+1];
                                textBox90.Text = readData[13*2+0]+""+readData[13*2+1];
                                textBox89.Text = readData[14*2+0]+""+readData[14*2+1];
                                textBox88.Text = readData[15*2+0]+""+readData[15*2+1];
                                break;
                            case "3580":
                                textBox87.Text = readData[0*2+0]+""+readData[0*2+1];
                                textBox86.Text = readData[1*2+0]+""+readData[1*2+1];
                                textBox85.Text = readData[2*2+0]+""+readData[2*2+1];
                                textBox84.Text = readData[3*2+0]+""+readData[3*2+1];
                                textBox83.Text = readData[4*2+0]+""+readData[4*2+1];
                                textBox82.Text = readData[5*2+0]+""+readData[5*2+1];
                                textBox81.Text = readData[6*2+0]+""+readData[6*2+1];
                                textBox80.Text = readData[7*2+0]+""+readData[7*2+1];
                                textBox79.Text = readData[8*2+0]+""+readData[8*2+1];
                                textBox78.Text = readData[9*2+0]+""+readData[9*2+1];
                                textBox77.Text = readData[10*2+0]+""+readData[10*2+1];
                                textBox76.Text = readData[11*2+0]+""+readData[11*2+1];
                                textBox75.Text = readData[12*2+0]+""+readData[12*2+1];
                                textBox74.Text = readData[13*2+0]+""+readData[13*2+1];
                                textBox73.Text = readData[14*2+0]+""+readData[14*2+1];
                                textBox72.Text = readData[15*2+0]+""+readData[15*2+1];
                                break;
                            case "3590":
                                textBox71.Text = readData[0*2+0]+""+readData[0*2+1];
                                textBox70.Text = readData[1*2+0]+""+readData[1*2+1];
                                textBox69.Text = readData[2*2+0]+""+readData[2*2+1];
                                textBox68.Text = readData[3*2+0]+""+readData[3*2+1];
                                textBox67.Text = readData[4*2+0]+""+readData[4*2+1];
                                textBox66.Text = readData[5*2+0]+""+readData[5*2+1];
                                textBox65.Text = readData[6*2+0]+""+readData[6*2+1];
                                textBox102.Text = readData[7*2+0]+""+readData[7*2+1];
                                break;

                            case "35A0":
                                statusOfFiled = 2;  // Just For Passing
                                break;

                            default:
                                break;
                        }
                    }

                    if (statusOfFiled == 0)
                        upperFile += currentLine;
                    else if (statusOfFiled == 1)
                        modifyFile += currentLine;
                    else if (statusOfFiled == 2)
                        downFile += currentLine;
                    currentLine = "";
                }

                wholeFile = upperFile + modifyFile + downFile;

                textBox101.Text = wholeFile;
                //MessageBox.Show(upperFile);
                //MessageBox.Show(modifyFile);
                //MessageBox.Show(downFile);

                MessageBox.Show(wholeFile.Length + "");
                br.Close();
            }
        }

        private int twoHexCharToIntNumber(char x, char y)
        {
            int retX = 0;
            int retY = 0;

            int total = 0;

            retX = (int)Char.GetNumericValue(x);
            if (retX == -1) // a~f
                retX = hexAlphaToInt(x);

            retY = (int)Char.GetNumericValue(y);
            if (retY == -1) // a~f
                retY = hexAlphaToInt(y);

            total = retX * 16 + retY * 1;

            return total;
        }

        private int hexAlphaToInt(char alphaChar)
        {
            int ret = 0;

            switch(alphaChar)
            {
                case 'a': case 'A':
                    ret = 10;
                    break;
                case 'b': case 'B':
                    ret = 11;
                    break;
                case 'c': case 'C':
                    ret = 12;
                    break;
                case 'd': case 'D':
                    ret = 13;
                    break;
                case 'e': case 'E':
                    ret = 14;
                    break;
                case 'f': case 'F':
                    ret = 15;
                    break;
                default:
                    MessageBox.Show("system error: hex val over f");
                    break;
            }

            return ret;
        }




        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "../";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // temp part
                textBox110.Text = inifile.IniReadValue("Temp", "a", openFileDialog1.FileName);
                textBox109.Text = inifile.IniReadValue("Temp", "b", openFileDialog1.FileName);
                textBox108.Text = inifile.IniReadValue("Temp", "c", openFileDialog1.FileName);
                textBox107.Text = inifile.IniReadValue("Temp", "d", openFileDialog1.FileName);

                /****************************************************************************************/
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

                /****************************************************************************************/
                textBox102.Text = inifile.IniReadValue("N_Cycle", "a", openFileDialog1.FileName);

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            saveFileDialog1.Filter = "ini file (*.ini)|*.ini|All files (*.*)|*.*";
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // temp part
                inifile.IniWriteValue("Temp", "a", textBox110.Text, saveFileDialog1.FileName);
                inifile.IniWriteValue("Temp", "b", textBox109.Text, saveFileDialog1.FileName);
                inifile.IniWriteValue("Temp", "c", textBox108.Text, saveFileDialog1.FileName);
                inifile.IniWriteValue("Temp", "d", textBox107.Text, saveFileDialog1.FileName);

                /****************************************************************************************/
                
                // percent

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

                inifile.IniWriteValue("T0", "T1~T2", textBox31.Text, saveFileDialog1.FileName);
                inifile.IniWriteValue("T0", "T3~T4", textBox32.Text, saveFileDialog1.FileName);
                inifile.IniWriteValue("T0", "T5~T6", textBox33.Text, saveFileDialog1.FileName);
                inifile.IniWriteValue("T0", "T7~T8", textBox34.Text, saveFileDialog1.FileName);

                inifile.IniWriteValue("OFF", "T1~T2", textBox35.Text, saveFileDialog1.FileName);
                inifile.IniWriteValue("OFF", "T3~T4", textBox36.Text, saveFileDialog1.FileName);
                inifile.IniWriteValue("OFF", "T5~T6", textBox37.Text, saveFileDialog1.FileName);
                inifile.IniWriteValue("OFF", "T7~T8", textBox38.Text, saveFileDialog1.FileName);

                /****************************************************************************************/

                // time

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

                inifile.IniWriteValue("Time_T0", "T1~T2", textBox72.Text, saveFileDialog1.FileName);
                inifile.IniWriteValue("Time_T0", "T3~T4", textBox71.Text, saveFileDialog1.FileName);
                inifile.IniWriteValue("Time_T0", "T5~T6", textBox70.Text, saveFileDialog1.FileName);
                inifile.IniWriteValue("Time_T0", "T7~T8", textBox69.Text, saveFileDialog1.FileName);

                inifile.IniWriteValue("Time_OFF", "T1~T2", textBox68.Text, saveFileDialog1.FileName);
                inifile.IniWriteValue("Time_OFF", "T3~T4", textBox67.Text, saveFileDialog1.FileName);
                inifile.IniWriteValue("Time_OFF", "T5~T6", textBox66.Text, saveFileDialog1.FileName);
                inifile.IniWriteValue("Time_OFF", "T7~T8", textBox65.Text, saveFileDialog1.FileName);

                /****************************************************************************************/
                inifile.IniWriteValue("N_Cycle", "a", textBox102.Text, saveFileDialog1.FileName);
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

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            saveFileDialog1.Filter = "hex file (*.hex)|*.hex|All files (*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
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
