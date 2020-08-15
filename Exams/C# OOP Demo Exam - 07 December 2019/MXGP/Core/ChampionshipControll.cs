using MXGP.Core.Contracts;
using MXGP.Repositories;
using MXGP.Utilities.Messages;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Core
{
    public class ChampionshipController : IChampionshipController
    {
        private RiderRepository riderRepository;
        private MotorcycleRepository motorcycleRepository;
        private RaceRepository raceRepository;

        public ChampionshipController()
        {
            this.riderRepository = new RiderRepository();
            this.motorcycleRepository = new MotorcycleRepository();
            this.raceRepository = new RaceRepository();
        }

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            var currentRider = this.riderRepository.GetByName(riderName);
            var currentMotorcycle = this.motorcycleRepository.GetByName(motorcycleModel);

            if (currentRider.CanParticipate)
            {
                currentRider.AddMotorcycle(currentMotorcycle);
                return string.Format(OutputMessages.MotorcycleReplaced,currentRider.Name,currentMotorcycle.Model);
               
            }

            currentRider.AddMotorcycle(currentMotorcycle);

            return string.Format(OutputMessages.MotorcycleAdded, riderName, motorcycleModel);
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            var currentRace = this.raceRepository.GetByName(raceName);
            var currentRider = this.riderRepository.GetByName(riderName);

            currentRace.AddRider(currentRider);
            
            return string.Format(OutputMessages.RiderAdded, riderName, raceName);
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            var currentMotorcycle = MotorcycleFactory.CreateMotorcycle(type, model, horsePower);
            this.motorcycleRepository.Add(currentMotorcycle);

            return string.Format(OutputMessages.MotorcycleCreated, type, model);

        }

        public string CreateRace(string name, int laps)
        {
            var currentRace = RaceFactory.CreateRace(name, laps);
            this.raceRepository.Add(currentRace);

            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string CreateRider(string riderName)
        {
            var currenrRider = RiderFactory.CreateRider(riderName);
            this.riderRepository.Add(currenrRider);

            return string.Format(OutputMessages.RiderCreated, riderName);
        }

        public string StartRace(string raceName)
        {
            StringBuilder builder = new StringBuilder();

            var currentRace = this.raceRepository.GetByName(raceName);

            if (currentRace.Riders.Count < 3)
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages.RaceInvalid, raceName, currentRace.Riders.Count));
            }

            var topRiders = currentRace.Riders
                .OrderByDescending(x => x.Motorcycle.CalculateRacePoints(currentRace.Laps)).Take(3).ToArray();

            topRiders[0].WinRace();

            var RiderFirstPosition = string.Format(OutputMessages.RiderFirstPosition, topRiders[0].Name, currentRace.Name);
            var RiderSecondPosition = string.Format(OutputMessages.RiderSecondPosition, topRiders[1].Name, currentRace.Name);
            var RiderThirdPosition = string.Format(OutputMessages.RiderThirdPosition, topRiders[2].Name, currentRace.Name);

            this.raceRepository.Remove(currentRace);

            builder.AppendLine(RiderFirstPosition).AppendLine(RiderSecondPosition).AppendLine(RiderThirdPosition);

            return builder.ToString().TrimEnd();
        }
    }
}
