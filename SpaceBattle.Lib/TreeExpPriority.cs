using Moq;


namespace MySpaceShip.Numeric
{
    public class TreeExpPriority
    {
        public Dictionary<string, Dictionary<string, SpaceBattle.Lib.ICommand>> Get_tree(object[] args)
        {
            Dictionary<string, Dictionary<string, SpaceBattle.Lib.ICommand>> tree = new();

                Mock<SpaceBattle.Lib.ICommand> HandleStrategy = new();

                Mock<SpaceBattle.Lib.ICommand> OtherHandleStrategy = new();

                Dictionary<string, SpaceBattle.Lib.ICommand> Exceptions = new() { { "SpaceBattle.Lib.ExceptionThrower", HandleStrategy.Object }, { "SpaceBattle.Lib.MoveCommand", OtherHandleStrategy.Object } };

                tree = new() { { "System.Exception", Exceptions }, { "System.ArgumentException", Exceptions } };

                return tree;
        }
    }
}
