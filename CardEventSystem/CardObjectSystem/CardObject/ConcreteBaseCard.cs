using System.Collections.Generic;
using CardEventSystem.EventTypes;

namespace CardObjectSystem.CardObject
{
    public class ConcreteBaseCard : IBaseCard
    {
        public string cardName { get; set; }
        public List<GameEvent> relaventEvents { get; set; }
        public EventConsumer eventConsumer { get; set; }
    }
}