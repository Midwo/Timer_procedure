using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apka_procedury
{
    class Error
    {

        public static int statusError = 0;

        public static void SaveErrorLogging(Exception ex)
        {


            string strPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            strPath += @"\Log.txt";
            if (!File.Exists(strPath))
            {
                File.Create(strPath).Dispose();
            }
            using (StreamWriter sw = File.AppendText(strPath))
            {
                sw.WriteLine("=============Error Logging ===========");
                sw.WriteLine("===========Start============= " + DateTime.Now);
                sw.WriteLine("Error Message: " + ex.Message);
                sw.WriteLine("Stack Trace: " + ex.StackTrace);
                sw.WriteLine("===========End============= " + DateTime.Now);

            }
        }

        public static void ReadError()
        {
            string strPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            strPath += @"\Log.txt";
            using (StreamReader sr = new StreamReader(strPath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }


        }
    }
    }

