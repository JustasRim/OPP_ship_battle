using System.Collections.Generic;

namespace BattleShipClient.Ingame_objects.Observer
{
    public class Publisher
    {
        private IList<ISubscriber> _subscribers;

        public Publisher()
        {
            _subscribers = new List<ISubscriber>();
        }

        public void RegisterSubscriber(ISubscriber subscriber)
        {
            _subscribers.Add(subscriber);
        }

        public void Notify()
        {
            foreach (var sub in _subscribers)
            {
                sub.Update();
            }
        }

        public void Unsubscribe(ISubscriber subscriber)
        {
            _subscribers.Remove(subscriber);
        }
    }
}
