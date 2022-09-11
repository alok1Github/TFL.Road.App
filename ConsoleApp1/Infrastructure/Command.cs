using TFL.ClientApp.Features.Command;

namespace TFL.ClientApp.Infrastructure
{
    public interface ICommand
    {
        Task OnAction(string command);
    }
    public class Commandfactory
    {
        public ICommand SetCommand(string commandText)
        {
            ICommand Command = null;

            switch (commandText)
            {
                case "EXIT":
                    Command = new GetExit();
                    break;
                default:
                    Command = new GetRoadStatus();
                    break;
            }

            return Command;
        }
    }
}
