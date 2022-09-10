using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TFL.ClientApp.Features.Command;
using TFL.ClientApp.Infrastructure;

var hostBuilder = Host.CreateDefaultBuilder(args)
        .ConfigureServices((context, services) =>
        {
            services.AddScoped<Commandfactory, Commandfactory>();
            services.AddScoped<ICommand, GetExit>();
            services.AddScoped<ICommand, GetRoadStatus>();
        });

var command = string.Empty;

do
{
    command = Console.ReadLine() ?? "";
    var enteredText = command.ToUpper();

    var factory = new Commandfactory();
    ICommand commandText = factory.SetCommand(enteredText);

    await commandText.OnAction(enteredText);

} while (command != "Exit");




