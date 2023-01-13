using Moq;
using Hwdtech;
using Hwdtech.Ioc;

namespace SpaceBattle.Lib.Test;

public class ExceptionHandlerStrategyTests
{
    [Fact]
    void ExceptionHandlerStrategyExceptionPriorityTest()
    {
        var Handler = new Mock<IStrategy>();

        var ExceptionStrategyDict = new Mock<IDictionary<ICommand, IStrategy>>();
        ExceptionStrategyDict.Setup(ed => ed[It.IsAny<ICommand>()]).Returns(Handler.Object);

        var HandlerDict = new Mock<IDictionary<Exception, IDictionary<ICommand, IStrategy>>>();

        HandlerDict.Setup(md => md[It.IsAny<Exception>()]).Returns(ExceptionStrategyDict.Object);

        Handler.Setup(_s => _s.Execute(It.IsAny<object[]>())).Returns(HandlerDict.Object);

        new InitScopeBasedIoCImplementationCommand().Execute();
        IoC.Resolve<Hwdtech.ICommand>("Scopes.Current.Set", IoC.Resolve<object>("Scopes.New", IoC.Resolve<object>("Scopes.Root"))).Execute();
        IoC.Resolve<Hwdtech.ICommand>("IoC.Register","Handler.Exception.ExceptionPriority", (object[] props) => Handler.Object.Execute()).Execute();

        var exception = new ExceptionHandlerStrategyExceptionPriority();

        Assert.NotNull(exception.Execute(new Mock<ICommand>().Object, new Mock<Exception>().Object));
    }
    [Fact]
    void ExceptionHandlerStrategyCommandPriorityTest()
    {
        var Handler = new Mock<IStrategy>();

        var ExceptionStrategyDict = new Mock<IDictionary<Exception, IStrategy>>();
        ExceptionStrategyDict.Setup(ed => ed[It.IsAny<Exception>()]).Returns(Handler.Object);

        var HandlerDict = new Mock<IDictionary<ICommand, IDictionary<Exception, IStrategy>>>();

        HandlerDict.Setup(md => md[It.IsAny<ICommand>()]).Returns(ExceptionStrategyDict.Object);

        Handler.Setup(_s => _s.Execute(It.IsAny<object[]>())).Returns(HandlerDict.Object);

        new InitScopeBasedIoCImplementationCommand().Execute();
        IoC.Resolve<Hwdtech.ICommand>("Scopes.Current.Set", IoC.Resolve<object>("Scopes.New", IoC.Resolve<object>("Scopes.Root"))).Execute();
        IoC.Resolve<Hwdtech.ICommand>("IoC.Register","Handler.Exception.CommandPriority", (object[] props) => Handler.Object.Execute()).Execute();

        var exception = new ExceptionHandlerStrategyCommandPriority();

        Assert.NotNull(exception.Execute(new Mock<ICommand>().Object, new Mock<Exception>().Object));
    }
}
