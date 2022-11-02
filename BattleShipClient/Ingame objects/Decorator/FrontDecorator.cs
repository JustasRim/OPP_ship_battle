using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipClient.Ingame_objects.Decorator
{
    class FrontDecorator : Decorator
    {
        public FrontDecorator(Component component, Message message) : base(component, message)
        {
        }
        public string ReturnMessageText()
        {
            return message.messageText;
        }

        public void CreateMessage(string text)
        {
            message.messageText = text + message.messageText;         
        }

     
    }
}
