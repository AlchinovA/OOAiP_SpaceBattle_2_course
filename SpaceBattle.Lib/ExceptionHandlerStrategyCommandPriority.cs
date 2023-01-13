using Hwdtech;

namespace SpaceBattle.Lib;
public class ExceptionHandlerStrategyCommandPriority : IStrategy
{
    public object Execute(params object[] args)
    {
        ICommand command = (ICommand)args[0];
        Exception exception = (Exception)args[1];

        var ExceptionHandlers = IoC.Resolve<IDictionary<ICommand, IDictionary<Exception, IStrategy>>>("Handler.Exception.CommandPriority");

        return ExceptionHandlers[command][exception];
    }
}
