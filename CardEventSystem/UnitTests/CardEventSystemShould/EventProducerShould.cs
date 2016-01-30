using CardEventSystem;
using CardEventSystem.EventTypes;
using NUnit.Framework;

namespace UnitTests.CardEventSystemShould
{
    [TestFixture]
    public class EventProducerShould
    {
        private EventProducer _eventproducer;

        [SetUp]
        public void SetUp()
        {
            _eventproducer = new EventProducer();
        }

        [Test]
        public void PublishEventSerializedGameEvent()
        {
            var gameEvent = new GameEvent {RoutingKey = "key1"};

            var message = _eventproducer.PublishEvent(gameEvent);

            Assert.AreEqual("[x] Sent {\"RoutingKey\":\"key1\"}", message);
        }
    }
}
