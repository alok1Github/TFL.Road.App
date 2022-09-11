using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using TFL.ClientApp.Infrastructure;

var hostBuilder = Host.CreateDefaultBuilder(args)
        .ConfigureAppConfiguration((context, builder) =>
        {
            builder.Sources.Clear();
            builder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        });

var command = string.Empty;

do
{
    command = Console.ReadLine() ?? "";
    var enteredText = command.ToUpper();

    var factory = new Commandfactory();
    ICommand commandText = factory.SetCommand(enteredText);

    await commandText.OnAction(enteredText);

} while (command != "EXIT");




