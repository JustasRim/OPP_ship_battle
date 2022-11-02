using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipClient.Ingame_objects.Decorator
{
    public class SignalMessage : Component
    {
        public string messageText { get; set; }

        public override string ReturnMessage()
        {
            return messageText;
        }

        public void CreateEmptyMessage()
        {
            messageText = "";
        }
    }
}
