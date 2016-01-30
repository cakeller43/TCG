
namespace CardEventSystem.EventTypes
{
    public interface IGameEvent
    {
        string RoutingKey { get; set; }
    }
}
