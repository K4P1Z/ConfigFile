using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{  
        class ConfigFile
        {
            string Path;
            string EXE = Assembly.GetExecutingAssembly().GetName().Name;
            [DllImport("kernel32", CharSet = CharSet.Unicode)]
            static extern long WritePrivateProfileString(string Section, string Key, string value, string Filepath);

            [DllImport("kernel32", CharSet = CharSet.Unicode)]
            static extern long GetPrivateProfileString(string Section, string Key, string Default, StringBuilder ReVal, int Size, string Filepath);

            public ConfigFile(string IniPath = null)
            {
                Path = new FileInfo(IniPath ?? EXE + ".ini").FullName.ToString();
            }
            public string Read(string Key, string Section = null)
            {
                var RetVal = new StringBuilder(255);
                GetPrivateProfileString(Section ?? EXE, Key, "", RetVal, 255, Path);
                return RetVal.ToString();
            }
            public void Write(string Key, string Value, string Section = null)
            {
                WritePrivateProfileString(Section ?? EXE, Key, Value, Path);
            }
        public void DeleteKey(string Key, string Section= null)
        {
            Write(Key, null, Section ?? EXE);

        }
        public void DeleteSection(string Section = null)
        {
            Write(null,null, Section ?? EXE);
        }
        }
       
}

