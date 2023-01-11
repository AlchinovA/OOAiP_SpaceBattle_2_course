namespace SpaceBattle.Lib
{
    public interface IMacroCommand : ICommand
    {
        public List<ICommand> commands { get; set; }
    }
}
