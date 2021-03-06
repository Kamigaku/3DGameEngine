﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameEngine.Logging
{
    public static class Logger
    {

        public enum LogLevel
        {
            DEBUG,
            ERROR
        }

        static Logger() 
        {
                
        }

        public static void Log(LogLevel level, string message, [CallerMemberName] string callerName = "")
        {
            string msg = level.ToString() + " - [Thread n°" + Thread.CurrentThread.ManagedThreadId + " - " + callerName + "] : " + message;
            Console.WriteLine(msg);
        }

        public static void Debug(string message, [CallerMemberName] string callerName = "")
        {
            Log(LogLevel.DEBUG, message, callerName);
        }

        public static void Error(string message, [CallerMemberName] string callerName = "")
        {
            Log(LogLevel.ERROR, message, callerName);
        }

    }
}
