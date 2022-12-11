using System;

namespace BattleShipClient.Ingame_objects.Visitor
{
    public class ArmorVisitor : IVisitor
    {
        public void Visit(Element element)
        {
            var unit = element as Unit;
            if (unit != null)
            {
                return;
            }

            Console.Write($"Adding armour, current armour");
            foreach (var part in unit.Parts)
            {
                if (part != null)
                {
                    continue;
                }

                part.Armor *= 3;
            }

            Console.Write($"Armour has been added");
        }
    }
}
