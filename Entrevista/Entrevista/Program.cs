using System;
using System.Linq;

namespace Entrevista
{
    class Program
    {
        static readonly string symbols = "abcdefghijklmnopqrstuvwxyz";

        static void Main(string[] args)
        {
            Console.WriteLine("Introduce una oracion: ");
            string input = Console.ReadLine();
            Console.WriteLine(Encrypt(input));
        }

        static string Encrypt(string str) 
        {
            return String.Concat(str.Select(c => RotN(c)));
        }

        static char RotN(char c, int N = 13)
        {
            int i = symbols.IndexOf(c);
            return i >= 0 ? symbols[(i + N) % symbols.Length] : c;
        }
    }
}
