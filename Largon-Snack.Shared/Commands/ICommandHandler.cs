namespace Largon_Snack.Shared.Commands
{
    public interface ICommandHandler<T> where T : ICommand //T do tipo generico
    {
        ICommandResult Handle(T command);
    }
}
