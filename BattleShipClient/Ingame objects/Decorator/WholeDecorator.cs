using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipClient.Ingame_objects.Decorator
{
    class WholeDecorator : Decorator
    {
        public WholeDecorator(Component component, Message message) : base(component, message)
        {
        }
        public override string ReturnMessage()
        {
            return message.messageText;
        }

        public void CreateMessage(string text)
        {
            message.messageText = text;
        }       
    }
}
