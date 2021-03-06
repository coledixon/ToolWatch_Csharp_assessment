﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            // CD: deprecated // string logPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            props p = new props();

            // define log location (setting to non-roaming users appdata store)
            p.path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            // instantiate objects
            LogDebug _debug = new LogDebug();
            LogError _error = new LogError();
            LogInfo _info = new LogInfo();

            // write to the specified logs
            #if DEBUG // env debug == true
            try
            {
                _debug.WriteLog(p.path, "debug statement");
            }
            catch (Exception e)
            {
                _debug.DeleteLog(p.path); // remove failed log
                _error.WriteLog(p.path, e.Message); // error logger
            }
            #endif
            
            try
            {
                _info.WriteLog(p.path, "hello, world"); // default logger
            }
            catch (Exception e)
            {
                _info.DeleteLog(p.path); // remove failed log
                _error.WriteLog(p.path, e.Message); // error logger
            }
        }
    }
}

