﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleShipClient.Ingame_objects.State
{
    public class FourState : IStateCor
    {
        private Form1 _form1 = null;

        public FourState(Form1 form1)
        {
            _form1 = form1;
        }
        public void Handle()
        {
            MessageBox.Show("You have set wrong number of 4-masts", "Error");
            _form1.SetState(new ZeroState(_form1));
            return;
        }
    }
}
