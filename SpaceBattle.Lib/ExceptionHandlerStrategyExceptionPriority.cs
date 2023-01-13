using Hwdtech;

namespace SpaceBattle.Lib;
public class ExceptionHandlerStrategyExceptionPriority : IStrategy
{
    public object Execute(params object[] args)
    {
        ICommand command = (ICommand)args[0];
        Exception exception = (Exception)args[1];

        var ExceptionHandlers = IoC.Resolve<IDictionary<Exception, IDictionary<ICommand, IStrategy>>>("Handler.Exception.ExceptionPriority");

        return ExceptionHandlers[exception][command];
    }
}
