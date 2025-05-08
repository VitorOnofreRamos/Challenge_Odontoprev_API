using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Challenge_Odontoprev_API.Services;

public class RabbitMQAuthConsumer : BackgroundService
{
    private readonly IConnectionFactory _connectionFactory;
    private readonly IConnection _connection;
    private readonly IModel _channel;
    private readonly string _authExchange;
    private readonly string _userCreatedQueue;
    private readonly string _userLoggedInQueue;

    public RabbitMQAuthConsumer(IConnectionFactory connectionFactory, IConfiguration configuration)
    {
        _connectionFactory = connectionFactory;
        _connection = _connectionFactory.CreateConnection();
        _channel = _connection.CreateModel();

        _authExchange = configuration["RabbitMQSettings:AuthExhange"];
        _userCreatedQueue = configuration["RabbitMQSettings:UserCreatedQueue"];
        _userLoggedInQueue = configuration["RabbitMQSettings:UserLoggedInQueue"];

        // Garante que as filas e exchange existem
        _channel.ExchangeDeclare(
            exchage: _authExchange,
            type: ExchangeType.Topic,
            durable: true);

        _channel.QueueDeclare(
            queue: _userCreatedQueue,
            durable: true,
            exclusive: false,
            autoDelete: false);

        _channel.QueueDeclare(
            queue: _userLoggedInQueue,
            durable: true,
            exclusive: false,
            autoDelete: false);

        _channel.QueueBind(
            queue: _userCreatedQueue,
            exchange: _authExchange,
            routingKey: "user.created");

        _channel.QueueBind(
            queue: _userLoggedInQueue,
            exchange: _authExchange,
            routingKey: "user.loggedin");
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        throw new NotImplementedException();
    }

    private void ProcessUserCreatedMessage(string message)
    {
        var userCreated = JsonConvert.DeserializeObject<UserCreatedEvent>(message);
        Console.WriteLine($"Usário criado: {userCreated.Username}");

        // Aqui você pode adiciona lógica aicional como:
        // - Log de auditoria
        // - Notificações
        // - Sincronização de dados
    }

    private void ProcessUserLoggedInMessage(string message)
    { 
        var userLoggedIn = JsonConvert.DeserializeObject<UserLoggedInEvent> (message);
        Console.WriteLine($"Usário logado: {userLoggedIn.Username} em {userLoggedIn.LoggedInAt}");

        // Lógica adicional para eventos de login 
    }

    public override void Dispose()
    {
        _channel?.Close();
        _connection?.CloseReason();
        base.Dispose();
    }
}

// Classes para deserialização de eventos
public class UserCreatedEvent
{
    public string Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class UserLoggedInEvent
{
    public string Id { get; set; }
    public string Username { get; set; }
    public DateTime LoggedInAt { get; set; }
}
