using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleShipClient.Ingame_objects.State
{
    public class ZeroState : IStateCor
    {
        private Form1 _form1 = null;

        public ZeroState(Form1 form1)
        {
            _form1 = form1;
        }
        public void Handle()
        {
            return;          
        }
    }
}
