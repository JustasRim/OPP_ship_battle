﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipClient.Ingame_objects.AbstractFactory
{
    public abstract class Creator
    {
        public abstract Battalion CreateBattalion(int type);
    }
}
