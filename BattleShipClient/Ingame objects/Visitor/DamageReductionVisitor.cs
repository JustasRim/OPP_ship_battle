using System;

namespace BattleShipClient.Ingame_objects.Visitor
{
    public class DamageReductionVisitor : IVisitor
    {
        public void Visit(Element element)
        {
            var unit = element as Unit;
            if (unit != null)
            {
                return;
            }

            Console.Write($"Adding damage reduction, current value = {unit.DamageReduction}");
            unit.DamageReduction *= 1.5f;

            Console.Write($"Damega reduction after increase is {unit.DamageReduction}");
        }
    }
}
