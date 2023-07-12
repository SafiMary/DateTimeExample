using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DateTimeExample
{
    public partial class Form1 : Form
    {
        List<object> remind_lst = new List<object>();
        
        
        public Form1()
        {
            InitializeComponent();
            dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            //monthCalendar1.AddBoldedDate(new DateTime(2023,06, 30));
            monthCalendar1.MaxSelectionCount = 1;

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime dt = dateTimePicker1.Value;
            monthCalendar1.AddBoldedDate(dt);
            textDate.Text += $"\n{dateTimePicker1.Text}";
        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            string dates = string.Empty;
            foreach (var item in monthCalendar1.BoldedDates)
            {
                dates += item.ToString("yyyy-MM-dd HH:mm:ss") + "\n";
            }
            MessageBox.Show(dates);
            monthCalendar1.UpdateBoldedDates();
            // Показать номера недель.
            monthCalendar1.ShowWeekNumbers = true;
            //monthCalendar1.AddBoldedDate(new DateTime(2023, 06, 29));
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            var dt = monthCalendar1.SelectionRange.Start;
            
            textDate.Text += $"\n {dt}";
        }

        private void btnAddRemind_MouseClick(object sender, MouseEventArgs e)
        {
            var dt = monthCalendar1.SelectionRange.Start;
            var txt = textDate.Text;
            var remind = new Remind(dt, txt);
            remind_lst.Add(remind);
        }

        private void btnShow_MouseClick(object sender, MouseEventArgs e)
        {
            textDate.Text = "";
            foreach (var item in remind_lst)
            {
                textDate.Text += ((Remind)item).Print();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "myText";
            saveFileDialog.CreatePrompt = true;
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.InitialDirectory = @"D:/";
            saveFileDialog.Title = "Сохраните свой файл здесь";
            saveFileDialog.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(@"D:/myText.txt", true))
                {
                    sw.WriteLine(textDate.Text);
                }
            }
            MessageBox.Show("Файл сохранен");


        }

        private void btnAddRemind_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.FileName = "myText";
            openFileDialog.InitialDirectory = @"D:/";
            openFileDialog.Title = "Какой файл нужно открыть?";
            openFileDialog.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
               string filename = openFileDialog.FileName;//получили файл
               string fileText = System.IO.File.ReadAllText(filename);//считали
               textDate.Text = fileText;
            }
            MessageBox.Show("Файл открыт");

        }

        private void textDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonClean_Click(object sender, EventArgs e)
        {
            textDate.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Teal;
            
        }
    
    }
    }

