using BattleShipClient.Ingame_objects.Facade;
using BattleShipClient.Ingame_objects.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleShipClient.Ingame_objects.ChainOfResponsibility
{
    public class CheckUnitOfSize1 : ICheck
    {
        public ICheck Successor { get; set; }

        public void Check(Facade.Facade facade)
        {
            if (facade.Check1Masts() == false)
            {
                MessageBox.Show("You have set wrong number of 1-masts", "Error");
                facade.noError = false;
                return;
            }
            else if (Successor != null)
            {
                Successor.Check(facade);
            }
            else
            {
                facade.noError = true;
                return;
            }
        }
    }
}
