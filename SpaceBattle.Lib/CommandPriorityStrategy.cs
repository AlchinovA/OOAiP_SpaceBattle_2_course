using Hwdtech;
using Moq;


namespace MySpaceShip.Numeric
{

    public class CommandPriorityStrategy
    {
        public SpaceBattle.Lib.ICommand Run(object[] args)
        {
            var error = args[0].GetType();
            Console.WriteLine(error);

            var command = args[1];
            Console.WriteLine(command);

            Dictionary<string, SpaceBattle.Lib.ICommand> subtree = new();

            Mock<SpaceBattle.Lib.ICommand> DefaultStrategy = new();

            Mock<SpaceBattle.Lib.ICommand> cmd = new();

            var cmd1 = cmd.Object;

            Dictionary<string, Dictionary<string, SpaceBattle.Lib.ICommand>> tree =
            IoC.Resolve<Dictionary<string, Dictionary<string, SpaceBattle.Lib.ICommand>>>("Handler.Tree.Command.Priority");

            if (tree.TryGetValue(command.ToString()!, out subtree!))
            {
                if (subtree.TryGetValue(error.ToString(), out cmd1))
                {
                    return cmd1;
                }
            }
            return DefaultStrategy.Object;               
        }      
    }
}
