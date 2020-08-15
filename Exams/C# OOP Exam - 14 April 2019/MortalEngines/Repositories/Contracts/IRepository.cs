namespace MortalEngines.Repositories.Contracts
{
    public interface IRepository
    {
        void AddUnit(object unit);

        object GetByName(string name);

        bool Contains(string name);
    }
}
