using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipClient.Ingame_objects.Proxy
{
    public class RealSendMessage : ISendMessage
    {
        private String Message;
        private Socket Socket;
        public RealSendMessage(String message, Socket socket)
        {
            Message = message;
            Socket = socket;
        }
        public void Send()
        {
            try
            {
                // Encode the data string into a byte array.
                byte[] msg = Encoding.ASCII.GetBytes(Message);

                // Send the data through the socket.
                int bytesSent = Socket.Send(msg);
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                throw;
            }
            catch (SocketException se)
            {
                Console.WriteLine("SocketException : {0}", se.ToString());
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected exception : {0}", e.ToString());
                throw;
            }
        }
    }
}
