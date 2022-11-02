using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipClient.Ingame_objects.Decorator
{
    public abstract class Decorator : Component
    {
        protected Component _component;
        public SignalMessage message;

        public Decorator(Component component, SignalMessage message)
        {
            this._component = component;
            this.message = message;
        }

        public override string ReturnMessage()
        {
            return message.messageText;
        }

        public void SetComponent(Component component)
        {
            this._component = component;
        }
    }
}
