using System.IO.Pipes;
using CardObjectSystem.CardLibrary;
using NUnit.Framework;

namespace UnitTests.CardObjectSystemShould
{
    [TestFixture]
    public class CardParserShould
    {
        [Test]
        public void ParseValidJsonFile()
        {
            var answer = CardParser.BuildCardLibrary();
            Assert.Less(0,answer.AllCards.Count);
            Assert.AreEqual("TestCardOne",answer.AllCards[0].cardName);
            Assert.AreEqual("TestCardTwo", answer.AllCards[1].cardName);
        }
    }
}
