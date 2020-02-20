using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Navchalna
{
    class Message
    {
        public DateTime date;
        public string name;
        public string msg;

        public Message(DateTime n, string a, string b) { date = n; name = a; msg = b; }

        public static bool operator <(Message c1, Message c2)
        {
            return c1.date < c2.date;
        }
        public static bool operator >(Message c1, Message c2)
        {
            return c1.date > c2.date;
        }

        static public void WriteInFile(List<Message> info)
        {
            try
            {
                foreach (var i in info)
                {
                    System.IO.StreamWriter f = new System.IO.StreamWriter(i.name + ".txt", true);
                    f.WriteLine(i.date.ToString("MM/dd/yyyy") + "->" + i.msg);
                    f.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static public List<Message> Sort(List<Message> info)
        {
            Message temp = new Message(DateTime.Now, "", "");

            for (var write = 0; write < info.Count; write++)
            {
                for (var sort = 0; sort < info.Count - 1; sort++)
                {
                    if (info[sort].date > info[sort + 1].date)
                    {
                        temp = info[sort + 1];
                        info[sort + 1] = info[sort];
                        info[sort] = temp;
                    }
                }
            }
            return info;
        }

        static public List<Message> Parse(List<Message> info)
        {
            StreamReader reader = File.OpenText(@"../../../info.txt");
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Message a = new Message(DateTime.Now, "", "");
                string[] items = line.Split(':');
                DateTime datee = DateTime.Parse(items[0]);
                a.date = datee;
                string part = items[1];
                string[] items2 = part.Split("> ");
                a.name = items2[0];
                a.msg = items2[1];
                info.Add(a);
            }
            return info;
        }

        static void Main(string[] args)
        {
            List<Message> info = new List<Message>();
            info = Parse(info);
            info = Sort(info);
            WriteInFile(info);
        }
    }

}

