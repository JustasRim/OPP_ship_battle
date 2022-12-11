using BattleShipClient.Ingame_objects.Visitor;
using System.Collections.Generic;

namespace BattleShipClient.Ingame_objects.Composite
{
    internal class Composite : Component
    {
        readonly List<Component> children = new List<Component>();

        public override void Add(Component c)
        {
            children.Add(c);
        }

        public override void Visit(IVisitor visitor)
        {
            visitor.Visit(element);
            foreach (var child in children)
            {
                child.Visit(visitor);
            }
        }

        public override void Remove(Component c)
        {
           children.Remove(c);
        }
    }
}