namespace MXGP.Repositories
{
    using System.Linq;
    using System;

    using MXGP.Models.Riders.Contracts;
    using MXGP.Repositories.Contracts;
    using System.Collections.Generic;
    using MXGP.Utilities.Messages;

    public class RiderRepository : IRepository<IRider>
    {
        private List<IRider> riders;

        public RiderRepository()
        {
            this.riders = new List<IRider>();
        }

        public void Add(IRider rider)
        {

            var ridersByName = this.riders.Select(x => x.Name).ToArray();

            if (ridersByName.Contains(rider.Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RiderExists,rider.Name));
            }
            this.riders.Add(rider);
        }

        public IReadOnlyCollection<IRider> GetAll()
        {
            return this.riders.AsReadOnly();
        }

        public IRider GetByName(string name)
        {
            var currentRider = this.riders.FirstOrDefault(x => x.Name == name);

            if (currentRider == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound,name));
            }
            
            return currentRider;
        }

        public bool Remove(IRider rider)
        {
            var isRemoved = this.riders.Remove(rider);

            return isRemoved;
        }
    }
}
