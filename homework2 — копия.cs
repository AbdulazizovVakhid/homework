using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{

    class Parse
    {
        protected string s;
        private int index;
        public override string ToString()
        {
            return $"s: {s}";
        }

        public virtual int Parse(string s)
        {
            this.s = s;
            index = 0;
            return SumSub();
        }
        private int parse ()
        {
            int num = MulDiv();
            while (index < s.Length)
            {
                if (s[index] == '+')
                {
                    index++;
                    int Newint = index;
                    int b = Num();
                    if ((index < s.Length) && (s[index] == '*' || (s[index] == '/')))
                    {
                        index = Newint;
                        num += UmDel(s, ref index);
                    }
                    else
                    {
                        num += b;
                    }
                }
                else if (s[index] == '-')
                {
                    index++;
                    int Newint = index;
                    int b = Num();
                    if ((index < s.Length) && (s[index] == '*' || (s[index] == '/')))
                    {
                        index = Newint;
                        num -= UmDel();
                    }
                    else
                    {
                        num -= b;
                    }
                }
                else if (s[index] == '*')
                {
                    index++;
                    int b = Num();
                    num *= b;
                }
                else if (s[index] == '/')
                {
                    index++;
                    int b = Num();
                    num /= b;
                }
                else
                {
                    Console.WriteLine("Error");
                    return 0;
                }
            }

            return num;
        }
        private int checkTheNumber(string s, ref int i)
        {
            string buff = "0";
            for (; i < s.Length && char.IsDigit(s[i]); i++)
            {
                buff += s[i];
            }

            return int.Parse(buff);//01
        }



        private int MulDiv(string s, ref int i)
        {
            int numirbl = Num(s, ref i);
            while (i < s.Length && (s[i] == '*' || s[i] == '/'))
            {
                if (s[i] == '*')
                {
                    i++;
                    int q = Num(s, ref i);
                    numirbl *= q;
                }
                else if (s[i] == '/')
                {
                    i++;
                    int q = Num(s, ref i);
                    numirbl /= q;
                }
            }
            return numirbl;
        }



        static void Main(string[] args)
        {
            while (true)
            {
                var dateNow = DateTime.Now;
                Console.WriteLine(dateNow);
                var s = Console.ReadLine();
                Console.WriteLine(Parse(s));
                var dateNow2 = DateTime.Now;
                Console.WriteLine(dateNow - dateNow2);

            }
        }

    }
    class Parser : Parse
    {
        public override int Parse(string s)
        {
            var time12 = DateTime.Now;
            var r = base.Parse(s);
            Console.WriteLine((DateTime.Now - time12).TotalMilliseconds);
            return r;
        }

        public void PrintS()
        {
            Console.WriteLine($"PrintS: {s}");
        }
    }
       
}

