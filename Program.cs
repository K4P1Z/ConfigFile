using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lekcja programowania");

            string wartosc_parametru;

            var Ini = new ConfigFile(@".\config.ini");

            wartosc_parametru = Ini.Read("ipaddress", "Drukarka");
            Console.WriteLine("IP address=" + wartosc_parametru);

            wartosc_parametru = Ini.Read("port", "Drukarka");
            Console.WriteLine("Port=" + wartosc_parametru);

            string nazwa_drukarki;
            wartosc_parametru = Ini.Read("nazwadrukarki", "Drukarka");

            Console.ReadLine();
        }
    }

   
}
