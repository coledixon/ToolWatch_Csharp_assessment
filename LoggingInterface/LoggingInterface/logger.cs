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
        public string debugFile = "\\" + DateTime.UtcNow.Ticks + "_DEBUG.txt";
        public void WriteLog(string path, string output)
        {
            string _path = path + debugFile;

            // validate file exists
            if (!File.Exists(debugFile))
            {
                File.Create(_path);
            }

            // begin writing to the log
            using (StreamWriter s = new StreamWriter(_path))
            {
                s.WriteLine(output);
                s.Close();
            }
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

            // validate file exists
            if (!File.Exists(errorFile))
            {
                File.Create(_path);
            }

            // begin writing to the log
            using (StreamWriter s = new StreamWriter(_path))
            {
                s.WriteLine(output);
                s.Close();
            }
        }
    }

    public class LogInfo : ILogger
    {
        public string infoFile = "\\" + DateTime.UtcNow.Ticks + "_LOG.txt";
        public void WriteLog(string path, string output)
        {
            string _path = path + infoFile;

            // validate file exists
            if (!File.Exists(infoFile))
            {
                File.Create(_path);
            }

            // begin writing to the log
            using (StreamWriter s = new StreamWriter(_path))
            {
                s.WriteLine(output);
                s.Close();
            }
        }

        public void DeleteLog(string path)
        {
            string _path = path + infoFile;
            File.Delete(_path);
        }
    }
    #endregion
}
