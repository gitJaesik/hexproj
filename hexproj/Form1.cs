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

        // TODO
        // 1. ini 저장 + 저장 & merge에서 Regular eXpression 사용하기
        // 2. HashTable을 사용해서 구분별로 저장하도록하기 -> 일반화 프로그래밍 Dictionary<string>
        // 3. 새로 파일을 오픈하였을 때, 모든 것을 리셋하는 부분이 필요하다.
        Dictionary<string,string> hexHeader = new Dictionary<string,string>();
        // 3540 ~ 3590
        string otherData1 = "";
        string otherData2 = "";

        private void button1_Click(object sender, EventArgs e)
        {
            // 초기화 두번째
            wholeFile = "";
            upperFile = "";
            downFile = "";
            modifyFile = "";
            currentLine = "";
            otherData1 = "";
            otherData2 = "";

            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            //openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            openFileDialog1.Filter = "hex file (*.hex)|*.hex|All files (*.*)|*.*";
            //openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
                BinaryReader br = new BinaryReader(new FileStream(openFileDialog1.FileName, FileMode.Open));

                char semicolonVal;
                //byte[] dataCount;
                char[] readDataSize = new char[1*2];
                char[] readAddress = new char[2*2];
                char[] readRecordType = new char[1*2]; // EOF == 0x01
                char[] readData = new char[16*2];      // MAX == 0x10
                char[] readChecksum = new char[1*2];
                char[] readLineSplit = new char[2];

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

                    if (endFlag == false)
                    {
                        readLineSplit = br.ReadChars(2);
                        currentLine += new string(readLineSplit);
                    }

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
                        string tmpStrToDecimal = "";
                        switch(currentAddress)
                        {
                            case "3540":
                                statusOfFiled = 1;

                                // 3540의 0~ 10까지의 Hex Data를 저장 (Hex 단위 = byte 단위 로)
                                for (int i = 0; i < 11; i++)
                                {
                                    otherData1 += readData[i * 2 + 0] + "" + readData[i * 2 + 1];
                                }
                                int countM = 110;
                                for (int i = 11; i < 15; i++)
                                {
                                    tmpStrToDecimal = readData[i * 2 + 0] + "" + readData[i * 2 + 1]; 
                                    this.Controls["textBox" + countM].Text = Convert.ToInt32(tmpStrToDecimal, 16).ToString();
                                    countM--;
                                }
                                //textBox3.Text = readData[15*2+0]+""+readData[15*2+1];
                                //tempVal = Convert.ToInt32(new string(hexDataArr), 16);
                                tmpStrToDecimal = readData[15*2+0]+""+readData[15*2+1];
                                textBox3.Text = Convert.ToInt32(tmpStrToDecimal, 16).ToString();

                                break;
                            case "3550":
                                int countN = 0;
                                for (int i = 0; i < 16; i++)
                                {
                                    countN = i + 4;
                                    //this.Controls["textBox" + n].Text = readData[i * 2 + 0] + "" + readData[i * 2 + 1];
                                    tmpStrToDecimal = readData[i * 2 + 0] + "" + readData[i * 2 + 1]; 
                                    this.Controls["textBox" + countN].Text = Convert.ToInt32(tmpStrToDecimal, 16).ToString();
                                }
                                    break;
                            case "3560":
                                int countK = 0;
                                for (int i = 0; i < 16; i++)
                                {
                                    countK = i + 20;
                                    //this.Controls["textBox" + n].Text = readData[i * 2 + 0] + "" + readData[i * 2 + 1];
                                    tmpStrToDecimal = readData[i * 2 + 0] + "" + readData[i * 2 + 1]; 
                                    this.Controls["textBox" + countK].Text = Convert.ToInt32(tmpStrToDecimal, 16).ToString();
                                }
                                break;
                            case "3570":
                                int countH = 0;
                                for (int i = 0; i < 3; i++)
                                {
                                    countH = i + 36;
                                    //this.Controls["textBox" + n].Text = readData[i * 2 + 0] + "" + readData[i * 2 + 1];
                                    tmpStrToDecimal = readData[i * 2 + 0] + "" + readData[i * 2 + 1]; 
                                    this.Controls["textBox" + countH].Text = Convert.ToInt32(tmpStrToDecimal, 16).ToString();
                                }

                                int countL = 100;
                                for (int i = 3; i < 16; i++)
                                {
                                    //countL = i + 36;
                                    //this.Controls["textBox" + n].Text = readData[i * 2 + 0] + "" + readData[i * 2 + 1];
                                    tmpStrToDecimal = readData[i * 2 + 0] + "" + readData[i * 2 + 1]; 
                                    this.Controls["textBox" + countL].Text = Convert.ToInt32(tmpStrToDecimal, 16).ToString();
                                    countL--;
                                }
                                break;
                            case "3580":
                                int countI = 87;
                                for (int i = 0; i < 16; i++)
                                {
                                    //countL = i + 36;
                                    //this.Controls["textBox" + n].Text = readData[i * 2 + 0] + "" + readData[i * 2 + 1];
                                    tmpStrToDecimal = readData[i * 2 + 0] + "" + readData[i * 2 + 1]; 
                                    this.Controls["textBox" + countI].Text = Convert.ToInt32(tmpStrToDecimal, 16).ToString();
                                    countI--;
                                }
                                break;
                            case "3590":
                                int countJ = 71;
                                for (int i = 0; i < 7; i++)
                                {
                                    //this.Controls["textBox" + n].Text = readData[i * 2 + 0] + "" + readData[i * 2 + 1];
                                    tmpStrToDecimal = readData[i * 2 + 0] + "" + readData[i * 2 + 1]; 
                                    this.Controls["textBox" + countJ].Text = Convert.ToInt32(tmpStrToDecimal, 16).ToString();
                                    countJ--;
                                }

                                //textBox102.Text = readData[7*2+0]+""+readData[7*2+1];
                                tmpStrToDecimal = readData[7*2+0]+""+readData[7*2+1];
                                textBox102.Text = Convert.ToInt32(tmpStrToDecimal, 16).ToString();

                                // 3590의 사용하지 않은 데이터 모두
                                for (int i = 8; i < 16; i++ )
                                {
                                    otherData2 += readData[i * 2 + 0] + "" + readData[i * 2 + 1];
                                }
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
            openFileDialog1.Filter = "ini file (*.ini)|*.ini|All files (*.*)|*.*";
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
            /////////////////////////////////////////////////// 유효화 검사
            int validationCheck = 0;
            int wrongInputNumber;
            wrongInputNumber = 0;
            for (int i = 3; i < 39; i++)
            {
                validationCheck = Convert.ToInt32(this.Controls["textBox" + i].Text);
                if (validationCheck < 0 || validationCheck > 255)
                    wrongInputNumber++;
            }
            if(wrongInputNumber > 0)
                MessageBox.Show("Heat_Percent_Table에 잘못 된 값이 "+wrongInputNumber +"개 들어 있습니다.");

            wrongInputNumber = 0;
            for (int i = 65; i < 101; i++)
            {
                validationCheck = Convert.ToInt32(this.Controls["textBox" + i].Text);
                if (validationCheck < 0 || validationCheck > 255)
                    wrongInputNumber++;
            }
            if(wrongInputNumber > 0)
                MessageBox.Show("Heat_Time_Table 잘못 된 값이 "+wrongInputNumber +"개 들어 있습니다.");

            wrongInputNumber = 0;
            for (int i = 102; i < 103; i++)
            {
                validationCheck = Convert.ToInt32(this.Controls["textBox" + i].Text);
                if (validationCheck < 0 || validationCheck > 255)
                    wrongInputNumber++;
            }
            if(wrongInputNumber > 0)
                MessageBox.Show("Heat_Percent_Table에 잘못 된 값이 "+wrongInputNumber +"개 들어 있습니다.");

            wrongInputNumber = 0;
            for (int i = 107; i < 111; i++)
            {
                validationCheck = Convert.ToInt32(this.Controls["textBox" + i].Text);
                if (validationCheck < 0 || validationCheck > 255)
                    wrongInputNumber++;
            }
            if(wrongInputNumber > 0)
                MessageBox.Show("Heat_Percent_Table에 잘못 된 값이 "+wrongInputNumber +"개 들어 있습니다.");
            /////////////////////////////////////////////////// 유효화 검사 끝


            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            saveFileDialog1.Filter = "hex file (*.hex)|*.hex|All files (*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = saveFileDialog1.FileName;
                string changedFile = "";
                string oneLineData = ""; // to checksum
                string retCheckSum = "";

                int decimalToHexTemp = 0;
                int n = 0;
                // 데이터 짜집기해서 저장하기
                for(int i = 0; i < 6; i++)
                {
                    //changedFile += ":" + "10" + "35" + (i + 4) + "0" + "00";
                    oneLineData += "10" + "35" + (i + 4) + "0" + "00";
                    if (i == 0)
                    {
                        oneLineData += otherData1;
                        //this.Controls["textBox" + n].Text = readData[i * 2 + 0] + "" + readData[i * 2 + 1];
                        n = 110;
                        for(int j = 0; j < 4; j++)
                        {
                            //oneLineData += this.Controls["textBox" + n].Text;
                            decimalToHexTemp = Convert.ToInt32(this.Controls["textBox" + n].Text);
                            if (decimalToHexTemp < 16)
                                oneLineData += "0";
                            oneLineData += decimalToHexTemp.ToString("X");
                            n--;
                        }
                        //oneLineData += this.Controls["textBox" + "3"].Text;
                        decimalToHexTemp = Convert.ToInt32(this.Controls["textBox" + "3"].Text);
                        if (decimalToHexTemp < 16)
                            oneLineData += "0";
                        oneLineData += decimalToHexTemp.ToString("X");
                        retCheckSum = getCheckSumFromOneLineData(oneLineData);
                        oneLineData += retCheckSum;
                    }
                    else if(i == 1)
                    {
                        for(int j = 0; j < 16; j++)
                        {
                            n = j + 4;
                            //oneLineData += this.Controls["textBox" + n].Text;
                            decimalToHexTemp = Convert.ToInt32(this.Controls["textBox" + n].Text);
                            if (decimalToHexTemp < 16)
                                oneLineData += "0";
                            oneLineData += decimalToHexTemp.ToString("X");
                        }
                        retCheckSum = getCheckSumFromOneLineData(oneLineData);
                        oneLineData += retCheckSum;
                    }
                    else if(i == 2)
                    {
                        for(int j = 0; j < 16; j++)
                        {
                            n = j + 20;
                            //oneLineData += this.Controls["textBox" + n].Text;
                            decimalToHexTemp = Convert.ToInt32(this.Controls["textBox" + n].Text);
                            if (decimalToHexTemp < 16)
                                oneLineData += "0";
                            oneLineData += decimalToHexTemp.ToString("X");
                        }
                        retCheckSum = getCheckSumFromOneLineData(oneLineData);
                        oneLineData += retCheckSum;
                    }
                    else if(i == 3)
                    {
                        for(int j = 0; j < 3; j++)
                        {
                            n = j + 36;
                            //oneLineData += this.Controls["textBox" + n].Text;
                            decimalToHexTemp = Convert.ToInt32(this.Controls["textBox" + n].Text);
                            if (decimalToHexTemp < 16)
                                oneLineData += "0";
                            oneLineData += decimalToHexTemp.ToString("X");
                        }
                        n = 100;
                        for(int h = 0; h < 13; h++)
                        {
                            //oneLineData += this.Controls["textBox" + n].Text;
                            decimalToHexTemp = Convert.ToInt32(this.Controls["textBox" + n].Text);
                            if (decimalToHexTemp < 16)
                                oneLineData += "0";
                            oneLineData += decimalToHexTemp.ToString("X");
                            n--;
                        }
                        retCheckSum = getCheckSumFromOneLineData(oneLineData);
                        oneLineData += retCheckSum;
                    }
                    else if(i == 4)
                    {
                        n = 87;
                        for(int j = 0; j < 16; j++)
                        {
                            //oneLineData += this.Controls["textBox" + n].Text;
                            decimalToHexTemp = Convert.ToInt32(this.Controls["textBox" + n].Text);
                            if (decimalToHexTemp < 16)
                                oneLineData += "0";
                            oneLineData += decimalToHexTemp.ToString("X");
                            n--;
                        }
                        retCheckSum = getCheckSumFromOneLineData(oneLineData);
                        oneLineData += retCheckSum;
                    }
                    else if(i == 5)
                    {
                        n = 71;
                        for (int j = 0; j < 7; j++)
                        {
                            //oneLineData += this.Controls["textBox" + n].Text;
                            decimalToHexTemp = Convert.ToInt32(this.Controls["textBox" + n].Text);
                            if (decimalToHexTemp < 16)
                                oneLineData += "0";
                            oneLineData += decimalToHexTemp.ToString("X");
                            n--;
                        }
                        //oneLineData += this.Controls["textBox" + "102"].Text;
                        decimalToHexTemp = Convert.ToInt32(this.Controls["textBox" + "102"].Text);
                        if (decimalToHexTemp < 16)
                            oneLineData += "0";
                        oneLineData += decimalToHexTemp.ToString("X");
                        oneLineData += otherData2;
                        retCheckSum = getCheckSumFromOneLineData(oneLineData);
                        oneLineData += retCheckSum;
                    }

                    changedFile += ":" + oneLineData+"\r\n";
                    oneLineData = "";
                }

                // Hex 파일 형태 데이터 저장하기
                wholeFile = upperFile + changedFile + downFile;
                StreamWriter sw = new StreamWriter(new FileStream(saveFileDialog1.FileName, FileMode.Create));
                sw.WriteLine(wholeFile);
                sw.Close();
                MessageBox.Show("저장되었습니다.");
            }

        }

        private string getCheckSumFromOneLineData(string str)
        {
            // error check
            if (str.Length != 40)
                MessageBox.Show("에러 발생");


            //MessageBox.Show(Convert.ToInt32("3A", 16)+"");  // 16진수로 바꾸는 것
            char[] hexDataArr;
            int tempVal = 0;
            int sum = 0;
            string retHexStr = "";

            for(int i = 0; i < 20; i++)
            {
                //hexDataArr = str.ToCharArray()
                //hexDataArr = str.ToCharArray(i * 0, 2);
                //tempVal = (byte)Convert.ToInt32(new string(str.ToCharArray(i * 1, 2)), 16);
                hexDataArr = str.ToCharArray(i * 2, 2); 
                tempVal = Convert.ToInt32(new string(hexDataArr), 16);
                //sum += tempVal;
                sum = sum + tempVal;
            }

            //MessageBox.Show(sum+"");
            sum %= 256;
            //MessageBox.Show(sum+"");
            sum = 256 - sum;
            //MessageBox.Show(sum+"");
            //MessageBox.Show(sum.ToString("X"));

            if (sum < 16)
                retHexStr += "0";
            retHexStr += sum.ToString("X");
            return retHexStr;

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
