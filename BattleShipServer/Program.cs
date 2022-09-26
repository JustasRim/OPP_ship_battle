using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net.Sockets;

namespace BattleShipServer
{
    class systemWideSettings
    {

        static void Main(string[] args)
        {
            //You cannot start 2 games in one time
            String thisprocessname = Process.GetCurrentProcess().ProcessName;

            if (Process.GetProcesses().Count(p => p.ProcessName == thisprocessname) > 1)
                return;

            AsynchronousSocketListener.StartListening();
        }
    }
   
}
