using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace TradeOrderService
{
    public interface ILogger
    {
        void Log(string message);
    }
    public class Logger : ILogger
    {
        private string _filePath = @"..\..\Users\Default\log.txt";
        private static Logger _instance;
        private static readonly object _lock = new object();

        private Logger()
        {
            
        }

        public static Logger Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Logger();
                    }
                    return _instance;
                }
            }
        }
        public void Log(string message)
        {
            using(StreamWriter writer = File.AppendText(_filePath))
            {
                writer.WriteLine(message);
                writer.Close();
            }
        }
    }
}