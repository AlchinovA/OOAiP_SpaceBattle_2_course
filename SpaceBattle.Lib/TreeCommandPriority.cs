using Moq;


namespace MySpaceShip.Numeric
{
    public class TreeCommandPriority
    {
        public Dictionary<string, Dictionary<string, SpaceBattle.Lib.ICommand>> Get_tree(object[] args)
        {
            Dictionary<string, Dictionary<string, SpaceBattle.Lib.ICommand>> tree = new();

            Mock<SpaceBattle.Lib.ICommand> HandleStrategy = new();

            Mock<SpaceBattle.Lib.ICommand> OtherHandleStrategy = new();

            Dictionary<string, SpaceBattle.Lib.ICommand> Exceptions = new() { { "System.Exception", HandleStrategy.Object }, { "System.ArgumentException", OtherHandleStrategy.Object } };

            tree = new() { { "SpaceBattle.Lib.ExceptionThrower", Exceptions }, { "SpaceBattle.Lib.MoveCommand", Exceptions } };

            return tree;
        }
    }
}
