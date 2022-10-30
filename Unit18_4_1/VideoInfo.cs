﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit18_4_1
{
     class VideoInfo: Command
    {
        private Receiver _reciever;
        private string _url;
        public VideoInfo(Receiver reciever, string url)
        {
            _reciever = reciever;
            _url = url;
        }

        public override void Cancel()
        {
            throw new NotImplementedException();
        }

        public override void Run()
        {
            _reciever.GetInfo(_url);
        }
    }
}
