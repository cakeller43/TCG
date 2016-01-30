using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace CardObjectSystem.CardObject
{
    public class EventConsumer
    {
        private readonly string _queueName;

        public EventConsumer(IEnumerable<string> routingKeys)
        {
            IModel channel;
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (channel = connection.CreateModel())
            {

                _queueName = channel.QueueDeclare().QueueName;

                //Bind to exchange for each key.
                foreach (var key in routingKeys)
                {
                    channel.QueueBind(queue: _queueName,
                                  exchange: "EventExchange",
                                  routingKey: key);
                }

                //What to do when a message is received.
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    var eventMessage = JObject.Parse(message);//event message in JSON form.
                    var routingKey = ea.RoutingKey;

                    //What to do when received.
                    Console.WriteLine(" [x] Received '{0}':'{1}'",
                                      routingKey, eventMessage);
                };

                channel.BasicConsume(queue: _queueName,
                                      noAck: true,
                                      consumer: consumer);

                Console.Read();
            }
        }

    }
}
