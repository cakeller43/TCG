
namespace CardEventSystem.EventTypes
{
    public class GameEvent : IGameEvent
    {
        public string RoutingKey { get; set; }
    }
}
