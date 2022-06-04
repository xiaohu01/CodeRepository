﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TradeOrderService
{
    public class Client
    {
        public Client()
        {
            _clientCallback = null;
            _username = string.Empty;
        }

        private static INotifyOrderService _clientCallback;
        public INotifyOrderService ClientCallback
        {
            get { return _clientCallback; }
            set { _clientCallback = value; }
        }

        private string _username;
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
    }
}