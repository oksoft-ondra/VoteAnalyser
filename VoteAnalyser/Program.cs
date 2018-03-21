using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = Colorful.Console;
using c = Colorful.Console;

namespace VoteAnalyser
{
    class Program
    {
        static void Main(string[] args)
        {
            c.WriteAscii("VoteAnalyser", Color.DodgerBlue);
            c.WriteLine("VoteAnalyser v2", Color.Yellow);
            List<string> p = new List<string>();
            List<int> v = new List<int>();
            string i = "NoData";
            c.WriteLine("Write info and end line with enter: / Napište informace a ukončete vpis enterem:");
            c.WriteLine("Write voted people names: / Napište jména:");
            while (i != "")
            {
                i = c.ReadLine();
                if (i != "") { p.Add(i); }
            }

            i = "NoData";
            c.WriteLine("Write count of voters: / Napište počet voličů:");
            while (i != "")
            {
                i = c.ReadLine();
                if (i != "") { v.Add(int.Parse(i)); }
            }
            c.WriteLine("help - Help; czhelp - Nápověda (česky)");
            while (true) {

                string cmd;
                c.Write("[VoteAnalyser] ", Color.Yellow);
                c.Write(" -> ", Color.DodgerBlue);
                cmd = c.ReadLine().ToLower();
                switch (cmd)
                {
                    case "list":
                        ListAll(p, v);
                        break;
                    case "num":
                        ListNum(p, v);
                        break;
                    case "quit":
                        Environment.Exit(0);
                        break;
                    case "let":
                        ByFirst(p, v);
                        break;
                    case "help":
                        c.WriteLine("list - Writes things");
                        c.WriteLine("num - Sortes by votes");
                        c.WriteLine("quit    - Exit");
                        c.WriteLine("let - By first letter (a: 10, b: 30, ...)");
                        c.WriteLine("czhelp - Czech Help/Česká nápověda");
                        c.WriteLine("renew - Refresh program, add new info");
                        break;
                    case "czhelp":
                        c.WriteLine("list - Vypíše vše");
                        c.WriteLine("num - Seřadí dle počtu hlasů");
                        c.WriteLine("quit - Konec");
                        c.WriteLine("let - Dle počátečního písmena (a: 10, b: 30, ...)");
                        c.WriteLine("help - English help/Anglická nápověda");
                        c.WriteLine("renew - Obnovit program, zadat informace znovu");
                        break;
                    case "renew":
                        c.Clear();
                        Main(null);
                        break;
                }
            }
            c.ReadLine();
        }


        public static List<string> ListAll(List<string> p, List<int> v)
        {
            int x;
            List<string> usp = new List<string>();
            for (x = 0; x != p.Count; x++)
            {
                usp.Add(p[x] + ": " + v[x].ToString());
            }
            List<string> sp = usp.ToList();
            sp.Sort();
            for (x = 0; x != sp.Count; x++)
            {
                c.WriteLine(sp[x]);
            }

            return sp;
        }
        public static List<string> ListNum(List<string> p, List<int> v)
        {
            int x;
            int y;
            int buffer;
            string namer;
            for (y = 0; y != p.Count; y++)
            {
                for (x = 0; x != p.Count - 1; x++)
                {
                    if (v[x] < v[x + 1])
                    {
                        buffer = v[x];
                        v[x] = v[x + 1];
                        v[x + 1] = buffer;

                        namer = p[x];
                        p[x] = p[x + 1];
                        p[x + 1] = namer;
                    }
                }
            }

           
            for (x = 0; x!= p.Count; x++)
            {
                c.WriteLine(p[x] + ": " + v[x].ToString());
            }

            return p;
        }

        public static List<string> ByFirst(List<string> p, List<int> v)
        {
            List<int> q = new List<int>();
            int b = 0;
            
            for (char h = 'a'; h != '{'; h = getNextChar(h))
            {
                for(int x = 0; x != p.Count; x++)
                {
                    if (p[x][0].ToString().ToLower()[0] == h) { b = b + v[x]; }
                }
                if (b != 0) { c.WriteLine(h.ToString().ToUpper() + ": " + b.ToString()); }
                b = 0;
            }
            return null; // No return, now
        }

        public static char getNextChar(char h)
        {

            // convert char to ascii
            int ascii = (int)h;
            // get the next ascii
            int nextAscii = ascii + 1;
            // convert ascii to char
            char nextChar = (char)nextAscii;
            return nextChar;
        }
    }
}
