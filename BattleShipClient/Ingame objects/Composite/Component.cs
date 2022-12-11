using BattleShipClient.Ingame_objects.Visitor;

namespace BattleShipClient.Ingame_objects.CompositePatrtern
{
    public abstract class Component
    {
        protected Element element;
        public abstract void Add(Component c);
        public abstract void Remove(Component c);
        public abstract void Visit(IVisitor visitor);
    }
}
