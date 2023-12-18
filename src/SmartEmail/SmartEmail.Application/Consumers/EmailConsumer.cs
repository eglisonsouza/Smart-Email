using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SmartEmail.Core.Models.Agrs;
using SmartEmail.Core.Models.Ui.Settings;
using SmartEmail.Core.Services;
using System.Text;
using System.Text.Json;

namespace SmartEmail.Application.Consumers
{
    public class EmailConsumer : BackgroundService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly IServiceProvider _serviceProvider;

        private const string QUEUE_NOTIFICATION = "email";

        public EmailConsumer(IServiceProvider serviceProvider, AppSettings appSettings)
        {
            _serviceProvider = serviceProvider;

            _connection = CreateConnection(appSettings.RabbitMq!);

            _channel = _connection.CreateModel();

            QueueDeclare();
        }

        private static IConnection CreateConnection(RabbitMqSettings rabbitMqSettings)
        {
#if DEBUG
            return new ConnectionFactory
            {
                HostName = rabbitMqSettings.Host,
                Password = rabbitMqSettings.Password,
                UserName = rabbitMqSettings.UserName,
            }.CreateConnection();
#else
            return new ConnectionFactory
            {
                Uri = new Uri(rabbitMqSettings.Uri!),
            }.CreateConnection();
#endif
        }

        private void QueueDeclare()
        {
            QueueEmail();
        }

        private void QueueEmail()
        {
            _channel.QueueDeclare
                (
                    queue: QUEUE_NOTIFICATION,
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null
                );
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (sender, eventArgs) =>
            {
                try
                {
                    var emailArgs = JsonSerializer.Deserialize<EmailArgs>(Encoding.UTF8.GetString(eventArgs.Body.ToArray()));

                    ProcessNotification(emailArgs!);

                    _channel.BasicAck(eventArgs.DeliveryTag, false);
                }
                catch
                {
                    _channel.BasicNack(eventArgs.DeliveryTag, false, true);
                }
            };

            _channel.BasicConsume(QUEUE_NOTIFICATION, false, consumer);

            return Task.CompletedTask;
        }

        private void ProcessNotification(EmailArgs emailArgs)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var notificationService = scope.ServiceProvider.GetRequiredService<ISendEmailService>();

                notificationService.SendEmail(emailArgs);
            }
        }
    }
}
