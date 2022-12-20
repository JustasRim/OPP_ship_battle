using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleShipClient.Ingame_objects.ChainOfResponsibility
{
    public class CheckUnitOfSize2 : ICheck
    {
        public ICheck Successor { get; set; }

        public void Check(Facade.Facade facade)
        {
            if (facade.Check2Masts() == false)
            {
                MessageBox.Show("You have set wrong number of 2-masts", "Error");
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
