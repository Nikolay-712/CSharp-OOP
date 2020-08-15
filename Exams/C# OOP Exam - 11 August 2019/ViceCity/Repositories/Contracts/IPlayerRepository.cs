namespace ViceCity.Repositories.Contracts
{
    using System.Collections.Generic;
    using ViceCity.Models.Players.Contracts;
    interface IPlayerRepository
    {
        IReadOnlyCollection<IPlayer> Models { get; }
        void Add(IPlayer model);
    }
}
