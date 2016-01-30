using CardObjectSystem.CardObject;

namespace CardObjectSystem.CardLibrary
{
    public class CardFactory
    {
        public IBaseCard MakeCard(string cardType)
        {
            return new ConcreteBaseCard();
        }
    }
}
