using Edevlet.Document.Common;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Edvelet.Document.Creator
{

    class Program()
    {


        static IConnection _connection;
        private static readonly string createDocument = "create_document_queue";
        private static readonly string documentCreated = "document_created_queue";
        private static readonly string documentCreateExchange = "document_create_exchange";

        static IModel _channel;
        static IModel channel => _channel ?? (_channel = GetChannel());

        static void Main(string[] args)
        {
            _connection = GetConnection(); // _connection'ı başlat

            channel.ExchangeDeclare(documentCreateExchange, "direct");

            channel.QueueDeclare(createDocument, false, false, false);
            channel.QueueBind(createDocument, documentCreateExchange, createDocument);

            channel.QueueDeclare(documentCreated, false, false, false);
            channel.QueueBind(documentCreated, documentCreateExchange, documentCreated);

            var consumerEvent = new EventingBasicConsumer(channel);

            consumerEvent.Received += (ch, ea) =>
            {
                var modelJson = (Encoding.UTF8.GetString(ea.Body.ToArray()));
                var model = JsonConvert.DeserializeObject<CreateDocumentModel>(modelJson);
                Console.WriteLine($"Received Data: {modelJson}");

                //Create Document

                Task.Delay(3000).Wait();

                //document goes to ftp

                model.Url = "https://www.turkiye.gov.tr/docs/x.pdf";

                WriteToQueue(documentCreated, model);
            };

            channel.BasicConsume(createDocument, true, consumerEvent);

            AddLog($"{documentCreateExchange} listening..");
            Console.ReadLine();
        }

        private static void WriteToQueue(string queueName, CreateDocumentModel model)
        {

            var messageArray = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(model));
            channel.BasicPublish(documentCreateExchange, queueName, null, messageArray);

            AddLog("Message Publish!");
        }

        private static IModel GetChannel()
        {
            return _connection.CreateModel();
        }

        private static IConnection GetConnection()
        {
            var connectionFactory = new ConnectionFactory()
            {
                Uri = new Uri("amqp://guest:guest@localhost:5672")
            };

            return connectionFactory.CreateConnection();
        }

        private static void AddLog(string logStr)
        {
            Console.WriteLine(logStr);
        }
    }
}