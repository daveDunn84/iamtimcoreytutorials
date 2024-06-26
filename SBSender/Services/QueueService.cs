﻿using System.Text;
using System.Text.Json;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;

namespace SBSender.Services
{
    public class QueueService : IQueueService
    {
        private readonly IConfiguration _configuration;

        public QueueService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // in the demo we create a queue called "PersonQueue"
        public async Task SendMessageAsync<T>(T ServiceBusMessage, string queueName)
        {
            var queueClient = new QueueClient(_configuration.GetConnectionString("AzureServiceBus"), queueName);
            string messageBody = JsonSerializer.Serialize(ServiceBusMessage);
            var message = new Message(Encoding.UTF8.GetBytes(messageBody));

            await queueClient.SendAsync(message);
        }
    }
}