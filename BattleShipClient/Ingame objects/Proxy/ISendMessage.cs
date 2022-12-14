using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipClient.Ingame_objects.Proxy
{
    internal interface ISendMessage
    {
        void Send();
    }
}
