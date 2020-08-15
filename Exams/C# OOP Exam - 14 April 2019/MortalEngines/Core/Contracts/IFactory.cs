namespace MortalEngines.Core.Contracts
{
    interface IFactory
    {
        object Create(params object[] parameters);
    }
}
