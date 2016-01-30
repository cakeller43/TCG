using System;
using System.Net.Http;
using System.Text;
using CardEventSystem.EventTypes;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace CardEventSystem
{
    public class EventProducer
    {
        private readonly ConnectionFactory _factory;

        public EventProducer()
        {
            _factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = _factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "EventExchange", type: "direct");
            }
        }

        public string PublishEvent(IGameEvent eventToPublish)
        {
            using (var connection = _factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {

                string message = JsonConvert.SerializeObject(eventToPublish);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(   exchange: "EventExchange",
                                        routingKey: eventToPublish.RoutingKey,
                                        basicProperties: null,
                                        body: body);
                return $"[x] Sent {message}";
            }

        }
            
    }
}
