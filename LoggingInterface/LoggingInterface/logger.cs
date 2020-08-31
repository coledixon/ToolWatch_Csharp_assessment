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

        // set datetime stamp for use in filename
        public static string SetDateTimeTicks()
        {
            return "\\" + DateTime.UtcNow.Ticks; 
        }
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
        public string debugFile = logger.SetDateTimeTicks() + "_DEBUG.txt";

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
        public string errorFile = logger.SetDateTimeTicks() + "_ERROR.txt";
        public void WriteLog(string path, string output)
        {
            string _path = path + errorFile;

            logger.WriteLog(_path, output);
        }
    }

    public class LogInfo : ILogger
    {
        public string infoFile = logger.SetDateTimeTicks() + "_LOG.txt";
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
