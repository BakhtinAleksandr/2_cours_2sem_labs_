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

namespace Directory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        IHashtable table = new LineHashtable(100);
        //сохранение наденных данных в файл
        private void button3_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;
            // сохраняем текст в файл
            System.IO.File.WriteAllText(filename, textBox1.Text);
            MessageBox.Show("Файл сохранен");
        }

        //открытие файла и создание хэш-таблицы
        private void button1_Click(object sender, EventArgs e)
        {
            table.Clear();
            textBox1.Clear();
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            using (StreamReader sr = new StreamReader(filename, Encoding.GetEncoding(1251)))
            {
                string line;
                
                while ((line = sr.ReadLine()) != null)
                {
                    Info inf = new Info();
                    textBox1.Text += line + Environment.NewLine;
                    inf.Number = long.Parse(line);                   
                    line = sr.ReadLine();

                    textBox1.Text += line + Environment.NewLine;
                    inf.Age = int.Parse(line);
                    line = sr.ReadLine();

                    textBox1.Text += line + Environment.NewLine;
                    inf.FIO = line;
                    table.Add(inf);
                    line = sr.ReadLine();
                }
            }
        }

        //поиск нужного человека по номеру
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            if (textBox2.Text == "")
            {
                MessageBox.Show("Введите номер");
            }
            else
            {
                long num = long.Parse(textBox2.Text);
                Info info = table.Find(long.Parse(textBox2.Text));
                string N, A;
                N = info.Number.ToString();
                A = info.Age.ToString();
                textBox1.Text += N + Environment.NewLine
                + A + Environment.NewLine + info.FIO + Environment.NewLine;
            }
        }
    }
}
