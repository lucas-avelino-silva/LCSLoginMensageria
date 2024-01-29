using Infra.EmailService;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.backgroundService
{
    public class NotificarBackgroundService : BackgroundService
    {
        public IServiceProvider serviceProvider;

        private readonly IConnection _connection;

        private readonly IModel _chennel;

        private const string ExchangeTracking = "Tracking-service";

        private const string Fila = "NotificarEmail";

        private const string RoutingKeySubscribe = "NotificarEmail";

        public NotificarBackgroundService(IServiceProvider service)
        {
            serviceProvider = service;

            var connectionFactory = new ConnectionFactory
            {
                HostName = "localhost",
            };

            _connection = connectionFactory.CreateConnection("Consumer");

            _chennel = _connection.CreateModel();

            _chennel.ExchangeDeclare(ExchangeTracking, "topic", true, false);

            _chennel.QueueDeclare(Fila, true, false, false);

            _chennel.QueueBind(Fila, ExchangeTracking, RoutingKeySubscribe);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_chennel);

            consumer.Received += async (sender, args) =>
            {
                var contentArray = args.Body.ToArray();

                var contentString = Encoding.UTF8.GetString(contentArray);

                var evento = JsonConvert.DeserializeObject<AtivarContaEvent>(contentString);

                EnviarEmail(evento).Wait();

                _chennel.BasicAck(args.DeliveryTag, false);
            };

            _chennel.BasicConsume(Fila, false, consumer);

            return Task.CompletedTask;
        }

        public async Task EnviarEmail(AtivarContaEvent evento)
        {
            using var scope = serviceProvider.CreateScope();

            var emailService = scope.ServiceProvider.GetRequiredService<IEmailSender>();

            await emailService.SendEmailAsync(evento.EmailNotificacao, "Ativação de conta", $"Clique no link para ativar a sua conta. Link: {evento.LinkAtivacao}");
        }
    }

    public class AtivarContaEvent
    {
        public AtivarContaEvent(string emailNotificacao, string linkAtivacao)
        {
            EmailNotificacao = emailNotificacao;
            LinkAtivacao = linkAtivacao;
        }

        public string? EmailNotificacao { get; set; }

        public string? LinkAtivacao { get; set; }
    }
}
