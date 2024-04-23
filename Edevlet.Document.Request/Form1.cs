using Edevlet.Document.Common;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Edevlet.Document.Request
{
    public partial class FormSample : Form
    {
        IConnection _connection;
        private readonly string createDocument = "create_document_queue";
        private readonly string documentCreated = "document_created_queue";
        private readonly string documentCreateExchange = "document_create_exchange";

        private IModel _channel;
        IModel channel => _channel ?? (_channel = GetChannel());

        public FormSample()
        {
            InitializeComponent();
        }

        private void createDoc_Click(object sender, EventArgs e)
        {
            var model = new CreateDocumentModel()
            {
                UserId = 1,
                Document = DocumentType.Pdf,
            };

            WriteToQueue(createDocument, model);

            AddLog("Document is queued...");

            var consumerEvent = new EventingBasicConsumer(channel);
            consumerEvent.Received += (ch, ea) =>
            {
                var modelReceived = JsonConvert.DeserializeObject<CreateDocumentModel>(Encoding.UTF8.GetString(ea.Body.ToArray()));
                AddLog($"Received Data Url: {modelReceived.Url}" );
            };

            channel.BasicConsume(documentCreated, true, consumerEvent);
        }

        private void connection_Click(object sender, EventArgs e)
        {
            if (_connection == null || !_connection.IsOpen)
            {
                try
                {
                    _connection = GetConnection();
                    createDoc.Enabled = true;

                    channel.ExchangeDeclare(documentCreateExchange, "direct");

                    channel.QueueDeclare(createDocument, false, false, false);
                    channel.QueueBind(createDocument, documentCreateExchange, createDocument);

                    channel.QueueDeclare(documentCreated, false, false, false);
                    channel.QueueBind(documentCreated, documentCreateExchange, documentCreated);

                    AddLog("Connection is open now!");
                }
                catch (Exception ex)
                {
                    AddLog($"Error establishing connection: {ex.Message}");
                }
            }
            else
            {
                AddLog("Connection is already open!");
            }
        }

        private void WriteToQueue(string queueName, CreateDocumentModel model)
        {

            var messageArray = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(model));
            channel.BasicPublish(documentCreateExchange, queueName, null, messageArray);

            AddLog("Message Publish!");
        }

        private IModel GetChannel()
        {
            return _connection.CreateModel();
        }

        private IConnection GetConnection()
        {
            var connectionFactory = new ConnectionFactory()
            {
                Uri = new Uri(connString.Text)
            };

            return connectionFactory.CreateConnection();
        }


        private void AddLog(string logStr)
        {
            if (txtLog.InvokeRequired)
            {
                txtLog.Invoke(new Action(() => AddLog(logStr)));
                return;
            }

            logStr = $"[{DateTime.Now:dd.MM.yyyy HH:mm:ss}] - {logStr}";
            txtLog.AppendText($"{logStr}\n");

            // set the cursor to end
            txtLog.SelectionStart = txtLog.Text.Length;
            txtLog.ScrollToCaret();
        }

    }
}
