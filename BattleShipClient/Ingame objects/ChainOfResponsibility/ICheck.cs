
using BattleShipClient.Ingame_objects.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BattleShipClient.Ingame_objects.ChainOfResponsibility
{
    public interface ICheck
    {
        ICheck Successor { get; set; }
        void Check(Facade.Facade facade);
    }
}
