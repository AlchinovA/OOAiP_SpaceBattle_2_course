using Moq;
using VectorSpaceBattle;
namespace SpaceBattle.Lib.Test;

public class StartMoveCommandTest
{
    [Fact]
    public void MoveCommandContinious()
    {
        new Hwdtech.Ioc.InitScopeBasedIoCImplementationCommand().Execute();

        Hwdtech.IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Adapters.IUObject.IMoveble", 
        (object[] args) => 
        {
            MovableAdapter adapter = new MovableAdapter(args);
            return adapter;
        }).Execute();

        Mock<IUObject> command = new();
        Mock<IUObject> obj = new();
        Queue<SpaceBattle.Lib.ICommand> queue = new();

        obj.Setup(x => x.get_property("velocity")).Returns((object) new Vector(1, 1));
        obj.Setup(x => x.get_property("position")).Returns((object) new Vector(0, 0));

        command.Setup(x => x.get_property("object")).Returns((object) obj.Object);
        command.Setup(x => x.get_property("queue")).Returns((object) queue);
        command.Setup(x => x.get_property("velocity")).Returns((object) new Vector(5, 5) );

        StartMoveCommand start = new(command.Object);
        start.Execute();
        Assert.Single(queue);
    }
}
