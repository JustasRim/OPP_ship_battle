using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipClient.Ingame_objects
{
    public class DecoratorBalance : TellInfoDecorator
    {
        public DecoratorBalance(ITellOnfo iTellInfo, Player player) : base(iTellInfo, player)
        {
        }

        public override string TellInfo()
        {
            if (player != null)
            {
                return base.player.Balance.ToString();
            }
            else
            {
                return "";
            }
        }
    }
}
