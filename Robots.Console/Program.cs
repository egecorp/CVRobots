using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Input data");
            ConsoleParser cp = new ConsoleParser();
            bool needContinue;
            do
            {
                try
                {
                    string inputString = System.Console.ReadLine();
                    needContinue = cp.Input(inputString);
                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e.Message);
                    System.Console.WriteLine("Programm will be restarted");
                    cp.Clear();
                    needContinue = true;
                }

            }
            while (needContinue);

            System.Console.WriteLine("Programm finished. Press Enter...");
            System.Console.ReadLine();
        }
    }
}
