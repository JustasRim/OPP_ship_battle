﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleShipClient.Ingame_objects.ChainOfResponsibility
{
    public class CheckUnitOfSize3 : ICheck
    {
        public ICheck Successor { get; set; }

        public void Check(Facade.Facade facade)
        {
            Console.WriteLine("Checking masts size of 3");
            if (facade.Check3Masts() == false)
            {
                MessageBox.Show("You have set wrong number of 3-masts", "Error");
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
