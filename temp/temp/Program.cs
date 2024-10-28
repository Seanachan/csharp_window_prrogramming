using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace temp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float f;
            int i;
            Console.WriteLine(float.TryParse("123",out f));
            Console.WriteLine(int.TryParse("123.12", out i));
            Console.Read();
        }
    }
}
