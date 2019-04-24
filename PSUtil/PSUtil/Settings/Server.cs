﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSUtil.Settings
{
    public class Server
    {
        public Server(String IPPORT)
        {
            IP = IPPORT.Split(':')[0];
            Port = UInt16.Parse(IPPORT.Split(':')[1]);
        }
        public UInt16 Port;
        public String IP;
        public override string ToString()
        {
            return IP + ":" + Port;
        }
    }
}