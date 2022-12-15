using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipClient.Ingame_objects.State
{
    public interface IStateCor
    {
        void Handle();
    }
}
