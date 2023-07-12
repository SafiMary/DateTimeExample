using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeExample
{
    internal class Remind
    {
        DateTime dateTime;
        string text;
        public Remind(DateTime date) 
        {
            this.dateTime = date;
            text = string.Empty;
        }
        public Remind(DateTime date, string text)
        {
            this.dateTime = date;
            this.text = text;
        }
        public void addText(string txt)
        {
            this.text += txt;
        }
        public string Print()
        {
            return dateTime.ToString("yyyy-MM-dd") +
                " " + text;
        }
    }
}
