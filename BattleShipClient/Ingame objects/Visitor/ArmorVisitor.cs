using System;
using System.Diagnostics;

namespace BattleShipClient.Ingame_objects.Visitor
{
    public class ArmorVisitor : IVisitor
    {
        public void Visit(Element element)
        {
            var unit = element as Unit;
            if (unit == null)
            {
                return;
            }

            Debug.WriteLine($"Adding armor, current armor");
            foreach (var part in unit.Parts)
            {
                if (part == null)
                {
                    continue;
                }

                part.Armor *= 3;
            }

            Debug.WriteLine($"armor has been added");
        }
    }
}
