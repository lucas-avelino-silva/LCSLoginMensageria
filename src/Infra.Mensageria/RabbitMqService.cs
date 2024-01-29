using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Infra.Mensageria
{
    public class RabbitMqService : IMessageBusService
    {
        private readonly IConnection _connection;

        private readonly IModel _channel;

        private const string _exchange = "Tracking-service";

        public RabbitMqService()
        {
            var connectFactory = new ConnectionFactory
            {
                HostName = "localhost",
            };

            _connection = connectFactory.CreateConnection("publish-mail");

            _channel = _connection.CreateModel();

            //_channel.QueueDeclare("NotificarEmail", false, false, false, null);
        }

        public void Publicar(object data, string routingKey)
        {
            var type = data.GetType();

            var json = JsonConvert.SerializeObject(data);

            var byteArray = Encoding.UTF8.GetBytes(json);

            Console.WriteLine($"{type.Name} publicado");

            _channel.BasicPublish(exchange: _exchange, routingKey: routingKey, mandatory: false, basicProperties: null, body: byteArray);
        }
    }
}
