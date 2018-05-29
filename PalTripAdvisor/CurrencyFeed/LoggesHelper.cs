using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyFeed
{
    public static class LoggesHelper
    {
        public static void addLogs(string text)
        {

            // Create a writer and open the file:
            StreamWriter log;

            if (!File.Exists("logs/logfile.txt"))
            {
                log = new StreamWriter("logs/logfile.txt");
            }
            else
            {
                log = File.AppendText("logs/logfile.txt");
            }

            // Write to the file:
            log.WriteLine(DateTime.Now);
            log.WriteLine(text);
            log.WriteLine();

            // Close the stream:
            log.Close();
        }
    }
}
