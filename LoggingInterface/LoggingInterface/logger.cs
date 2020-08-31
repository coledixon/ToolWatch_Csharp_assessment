using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingInterface
{
    class logger
    {
        public static void WriteLog(string path, string output)
        {
            if (!File.Exists(path))
            {
                File.Create(path);
            }

            // begin writing to the log
            using (StreamWriter s = new StreamWriter(path))
            {
                s.WriteLine(output);
                s.Close();
            }
        }

        public static string things()
        {
            return "\\" + DateTime.UtcNow.Ticks; 
        }
        // TO DO
        // base class with more behavioural definitions
    }

    // define interface
    public interface ILogger
    {
        void WriteLog(string path, string output);
    }

    #region loggers
    // log classes
    public class LogDebug : ILogger
    {
        public string debugFile = logger.things() + "_DEBUG.txt";

        public void WriteLog(string path, string output)
        {
            string _path = path + debugFile;

            logger.WriteLog(_path, output);
        }

        public void DeleteLog(string path)
        {
            string _path = path + debugFile;
            File.Delete(_path);
        }
    }

    public class LogError : ILogger
    {
        public string errorFile = "\\" + DateTime.UtcNow.Ticks + "_ERROR.txt";
        public void WriteLog(string path, string output)
        {
            string _path = path + errorFile;

            logger.WriteLog(_path, output);
        }
    }

    public class LogInfo : ILogger
    {
        public string infoFile = "\\" + DateTime.UtcNow.Ticks + "_LOG.txt";
        public void WriteLog(string path, string output)
        {
            string _path = path + infoFile;

            logger.WriteLog(_path, output);
        }

        public void DeleteLog(string path)
        {
            string _path = path + infoFile;
            File.Delete(_path);
        }
    }
    #endregion
}
