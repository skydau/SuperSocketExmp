using SuperSocket.SocketBase;
using SuperSocket.SocketEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService1
{
    public partial class Service1 : ServiceBase
    {
        public IBootstrap bootstrap;
        public Service1()
        {
            InitializeComponent();
            bootstrap = BootstrapFactory.CreateBootstrap();
        }

        protected override void OnStart(string[] args)
        {
            //StartServer();
        }

        protected override void OnStop()
        {
            bootstrap?.Stop();
        }

        protected void StartServer()
        {
            if (!bootstrap.Initialize())
            {
                return;
            }

            var result = bootstrap?.Start();

            if (result == StartResult.Failed)
            {
                return;
            }
        }
    }
}
