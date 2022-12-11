using System;
using System.Diagnostics;

namespace BattleShipClient.Ingame_objects.Visitor
{
    public class DamageReductionVisitor : IVisitor
    {
        public void Visit(Element element)
        {
            var unit = element as Unit;
            if (unit == null)
            {
                return;
            }

            Debug.WriteLine($"Adding damage reduction, current value = {unit.DamageReduction}");
            unit.DamageReduction *= 1.5f;

            Debug.WriteLine($"Damega reduction after increase is {unit.DamageReduction}");
        }
    }
}
