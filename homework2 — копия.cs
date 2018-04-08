using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var s = Console.ReadLine();
                Console.WriteLine(Parse(s));
            }
        }

        static int Parse(string s)
        {
            int index = 0;
            int num = Num(s, ref index);
            while (index < s.Length)
            {
                if (s[index] == '+')
                {
                    index++;
                    int Newint = index;
                    int b = Num(s, ref index);
                    if ((index < s.Length)&&(s[index]=='*'||(s[index]=='/')))
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
                    int b = Num(s, ref index);
                    if ((index < s.Length) && (s[index] == '*' || (s[index] == '/')))
                    {
                        index = Newint;
                        num -= UmDel(s, ref index);
                    }
                    else
                    {
                        num -= b;
                    }
                }
                else if (s[index]=='*')
                {
                    index++;
                    int b = Num(s, ref index);
                    num *= b;
                }
                else if (s[index] == '/')
                {
                    index++;
                    int b = Num(s, ref index);
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

        static int Num(string s, ref int i)
        {
            string buff = "0";
            for (; i < s.Length && char.IsDigit(s[i]); i++)
            {
                buff += s[i];
            }

            return int.Parse(buff);//01
        }
        // Для умножения и деления 
        static int UmDel (string s , ref int i)
        {
            int numirbl = Num(s, ref i);
            while (i<s.Length && (s[i]== '*'|| s[i] == '/'))
            {
                if (s[i]=='*')
                {
                    i++;
                    int q = Num(s, ref i);
                    numirbl *= q;
                }
                else if (s[i]=='/')
                {
                    i++;
                    int q = Num(s, ref i);
                    numirbl /= q;
                }
            }
            return numirbl;
        }
    }
}

