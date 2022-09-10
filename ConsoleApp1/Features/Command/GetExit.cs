using TFL.ClientApp.Infrastructure;

namespace TFL.ClientApp.Features.Command
{
    public class GetExit : ICommand
    {
        public Task OnAction(string command)
        {
            Environment.Exit(1);

            return Task.CompletedTask;
        }
    }
}
