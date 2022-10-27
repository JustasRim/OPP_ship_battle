using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipClient.Ingame_objects
{
    public class Player : ITellOnfo
    {
   
        public string Name { get; set; }
        public int Balance { get; set; }

        public Player(string name, int balance)
        {
            this.Name = name;
            this.Balance = balance;
        }

        public Player()
        {

        }

        public override string TellInfo()
        {
            return ($"Hello my name is name {this.Name}");
        }
    }
}
