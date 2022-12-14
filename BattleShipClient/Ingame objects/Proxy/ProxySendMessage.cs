using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleShipClient.Ingame_objects.Proxy
{
    public class ProxySendMessage : ISendMessage
    {
        private bool CanSendMessage;
        private String Message;
        private Socket Socket;
        public ProxySendMessage(bool canSendMessage, String message, Socket socket)
        {
            CanSendMessage = canSendMessage;
            Message = message;
            Socket = socket;
        }
        public void Send()
        {
            if (CanSendMessage)
            {
                var sendMsg = new RealSendMessage(Message, Socket);
                sendMsg.Send();
            }
            else
            {
                var errorMessage = (char)26 + " " + "Client was unauthorized to send the message." + " <EOF>";
                var sendMsg = new RealSendMessage(errorMessage, Socket);
                sendMsg.Send();
            }
        }
    }
}
