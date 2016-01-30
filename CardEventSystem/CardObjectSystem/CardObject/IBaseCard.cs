using System.Collections.Generic;
using CardEventSystem.EventTypes;

namespace CardObjectSystem.CardObject
{
    public interface IBaseCard
    {
        string cardName { get; set; }

        List<GameEvent> relaventEvents { get; set; }

        EventConsumer eventConsumer { get; set; }

    }
}
