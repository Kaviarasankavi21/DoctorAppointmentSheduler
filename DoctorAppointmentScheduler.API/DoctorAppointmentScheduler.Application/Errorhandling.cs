using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentScheduler.Application
{
    public class Errorhandling
    {
        public void Add(string error)
        {
            string filepath = @"D:\Techtalk2025\Errorhandling\Errorpath.txt";

            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(filepath));

                string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {error}{Environment.NewLine}";
                File.AppendAllText(filepath, logEntry);

                Console.WriteLine("Error logged to: " + filepath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to write error log: " + ex.Message);
            }
        }
    }
}
