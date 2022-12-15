using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleShipClient.Ingame_objects.State
{
    public class TwoState : IStateCor
    {
        private Form1 _form1 = null;

        public TwoState(Form1 form1)
        {
            _form1 = form1;
        }
        public void Handle()
        {
            MessageBox.Show("You have set wrong number of 2-masts", "Error");
            return;
        }
    }
}
