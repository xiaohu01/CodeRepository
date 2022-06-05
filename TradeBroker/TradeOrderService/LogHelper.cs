using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TradeOrderService
{
    public static class LogHelper
    {
        private static ILogger _logger = null;

        public static void Log(string message)
        {
            _logger = Logger.Instance;
            _logger.Log(message);
        }
    }
}