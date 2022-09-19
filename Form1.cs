using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Text08
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                if(saveFileDialog1.ShowDialog()==DialogResult.OK)
                {
                    StreamReader streamReader = new StreamReader(openFileDialog1.FileName);
                    StreamWriter streamWriter = new StreamWriter(saveFileDialog1.FileName);
                    while (!streamReader.EndOfStream)
                    {
                        string line = streamReader.ReadLine();
                        listBox1.Items.Add(line);
                        int i = 0;
                        while (i < line.Length)
                        {
                            if (line[i] == ' ' && line[i + 1] == ' ')
                            {
                                string substr1 = line.Substring(0, i);
                                string substr2 = line.Substring(i + 1);
                                line = substr1 + substr2;
                            }
                            else i++;
                        }
                        streamWriter.WriteLine(line);
                    }
                    streamReader.Close();
                    streamWriter.Close();
                    StreamReader streamReader1 = new StreamReader(saveFileDialog1.FileName);
                    while(!streamReader1.EndOfStream)
                    {
                        listBox2.Items.Add(streamReader1.ReadLine());
                    }
                }
            }
        }
    }
}
