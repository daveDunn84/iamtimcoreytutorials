// See https://aka.ms/new-console-template for more information
using Microsoft.Azure.ServiceBus;

Console.WriteLine("Hello, World!");

const string connectionString = ""; // to be copied from appsettings in sender project
const string queueName = "personqueue";
static IQueueClient queueClient; // to be checked

// we created a client to talk to the queue

// create a handler to handle events from the queue, and handle them essentially

// no polling, timer etc. needed. The handler does it



queueClient = new QueueClient(connectionString, queueName);

var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHander);

async Task ExceptionReceivedHander(ExceptionReceivedEventArgs args)
{
	throw new NotImplementedException();
}