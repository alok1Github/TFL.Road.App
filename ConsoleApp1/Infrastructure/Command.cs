using TFL.ClientApp.Builder;
using TFL.ClientApp.Features.Command;
using TFL.ClientApp.Features.Result;

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
                    Command = new GetExit(); // Ideally this should come from IOC
                    break;
                default:
                    Command = GetRoadStatusInjected(); // Ideally this should come from IOC
                    break;
            }

            return Command;
        }

        private static ICommand GetRoadStatusInjected() =>
                     new GetRoadStatus(new APIBuilder(), new AppSettingBuilder(), new URIBuilder(),
                    new ResultHandler(new ValidRoadResult(), new InvalidRoadResult(new ErrorResult())));


    }
}
