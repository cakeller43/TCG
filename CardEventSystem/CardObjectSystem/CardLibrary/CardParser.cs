using System.Collections.Generic;
using CardObjectSystem.CardObject;
using Newtonsoft.Json.Linq;

namespace CardObjectSystem.CardLibrary
{
    public static class CardParser
    {
        public static RawCardData BuildCardLibrary()
        {
            JObject jAllCards = JObject.Parse(CardObjectSystem.Properties.Resources.cardSource);

            var allCards = jAllCards.ToObject<RawCardData>();
            return allCards;

        }
    }

    public class RawCardData
    {
        public List<ConcreteBaseCard> AllCards { get; set; }
    }
}
