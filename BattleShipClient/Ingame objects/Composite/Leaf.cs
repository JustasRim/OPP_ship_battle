using BattleShipClient.Ingame_objects.Visitor;
using System;

namespace BattleShipClient.Ingame_objects.Composite
{
    internal class Leaf : Component
    {
        public override void Add(Component c)
        {
            throw new System.NotImplementedException();
        }

        public override void Visit(IVisitor visitor)
        {
            visitor.Visit(element);
        }

        public override void Remove(Component c)
        {
            throw new System.NotImplementedException();
        }
    }
}
