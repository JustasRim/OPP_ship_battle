using System.Security.Permissions;

namespace BattleShipClient.Ingame_objects
{
    public class Part
    {
        public string Name { get; set; }

        public int Damage { get; set; }
         
        public int Health { get; set; }

        public int Armor { get; set; }

        public int Speed { get; set; }

        public Part(string name, int damage, int health, int armor, int speed)
        {
            Name = name;
            Damage = damage;    
            Health = health;
            Armor = armor;
            Speed = speed;
        }
    }
}
