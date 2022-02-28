using JobsityChatProject.Core.RepositoryInterfaces;
using RabbitMQ.Client;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsityChatProject.Infrastructure.Repository
{
    public class RabbitMqRepository : IRabbitMqRepository
    {
        private string _user = Environment.GetEnvironmentVariable("RABBIT_MQ_USER");
        private string _password = Environment.GetEnvironmentVariable("RABBIT_MQ_PASS");
        private string _host = Environment.GetEnvironmentVariable("RABBIT_MQ_HOST");
        private int _port = Convert.ToInt32(Environment.GetEnvironmentVariable("RABBIT_MQ_PORT"));

        private IConnection _conn;
        private IModel _channel;
        private readonly string _queueName;

        public RabbitMqRepository()
        {
            _queueName = "stock.messages.v1";
        }

        public void InsertStockQuoteMessage(string stockQuote)
        {
            var messageBody = Encoding.UTF8.GetBytes(stockQuote);

            Connect();

            _channel.BasicPublish("", _queueName, false, null, messageBody);

            CloseConnection();
        }
        public string GetStockQuoteMessage()
        {
            Connect();
            var messageGetResult = _channel.BasicGet(_queueName, true);
            CloseConnection();

            return Encoding.UTF8.GetString(messageGetResult.Body.ToArray());
            
        }
        private void Connect()
        {
            ConnectionFactory factory = new ConnectionFactory { HostName = _host, VirtualHost = "/", Port = _port, UserName = _user, Password = _password, ContinuationTimeout = TimeSpan.FromMinutes(5) };

            _conn = factory.CreateConnection();

            _channel = _conn.CreateModel();

            _channel.QueueDeclare(_queueName, true, false, false, null);
        }
        private void CloseConnection()
        {
            _channel.Close();
            _conn.Close();
        }
    }
}
