using System;

namespace BattleShipClient.Ingame_objects.Visitor
{
    public class RepairVisitor : IVisitor
    {
        public void Visit(Element element)
        {
            var unit = element as Unit;
            if (unit != null)
            {
                return;
            }

            Console.Write($"Repairing ship, current health = {unit.Health}");
            foreach (var part in unit.Parts)
            {
                if (part != null) 
                { 
                    continue; 
                }

                part.Health *= 2;
            }

            Console.Write($"Parts have been repaired, the ships health is now {unit.Health}");
        }
    }
}
