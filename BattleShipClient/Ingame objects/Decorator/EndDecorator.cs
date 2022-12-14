using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipClient.Ingame_objects.Decorator
{
    class EndDecorator : Decorator
    {
        public EndDecorator(Component component, SignalMessage message) : base(component, message)
        {
        }
        public override string ReturnMessage()
        {
            return message.messageText;
        }
        public void CreateEndMessage(string text)
        {
            message.messageText += text;
        }
    }
}
