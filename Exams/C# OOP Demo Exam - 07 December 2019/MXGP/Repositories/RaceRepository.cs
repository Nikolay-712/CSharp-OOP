

namespace MXGP.Repositories
{
    using System.Linq;
    using System;

    using MXGP.Models.Races.Contracts;
    using MXGP.Repositories.Contracts;
    using System.Collections.Generic;
    using MXGP.Utilities.Messages;

    public class RaceRepository : IRepository<IRace>
    {
        private List<IRace> races;

        public RaceRepository()
        {
            this.races = new List<IRace>();
        }
        public void Add(IRace race)
        {
            var racesByName = this.races.Select(x => x.Name).ToArray();

            if (racesByName.Contains(race.Name))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, race.Name));
            }
            this.races.Add(race);
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            return this.races.AsReadOnly();
        }

        public IRace GetByName(string name)
        {
            var currentRace = this.races.FirstOrDefault(x => x.Name == name);

            if (currentRace == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, name));
            }

            return currentRace;
        }

        public bool Remove(IRace race)
        {
            var isRemoved = this.races.Remove(race);
            return isRemoved;
        }
    }
}
