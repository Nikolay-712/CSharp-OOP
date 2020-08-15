namespace SantaWorkshop.Core
{
    using System;
    using System.Text;
    using System.Linq;

    using SantaWorkshop.Core.Contracts;
    using SantaWorkshop.Models.Dwarfs;
    using SantaWorkshop.Models.Instruments;
    using SantaWorkshop.Models.Workshops;
    using SantaWorkshop.Repositories;
    using SantaWorkshop.Utilities.Messages;


    public class Controller : IController
    {
        private DwarfRepository dwarfRepository;
        private PresentRepository presentRepository;
        private Workshop workshop;

        public Controller()
        {
            this.dwarfRepository = new DwarfRepository();
            this.presentRepository = new PresentRepository();
            this.workshop = new Workshop();
        }


        public string AddDwarf(string dwarfType, string dwarfName)
        {
            switch (dwarfType)
            {
                case "HappyDwarf":
                    this.dwarfRepository.Add(new HappyDwarf(dwarfName));
                    break;
                case "SleepyDwarf":
                    this.dwarfRepository.Add(new SleepyDwarf(dwarfName));
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidDwarfType);
            }

            return string.Format(OutputMessages.DwarfAdded, dwarfType, dwarfName);
        }

        public string AddInstrumentToDwarf(string dwarfName, int power)
        {
            var instrument = new Instrument(power);

            var dwarf = this.dwarfRepository.FindByName(dwarfName);

            if (dwarf == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentDwarf);
            }

            dwarf.AddInstrument(instrument);
            return string.Format(OutputMessages.InstrumentAdded, instrument.Power, dwarf.Name);
        }

        public string AddPresent(string presentName, int energyRequired)
        {
            var present = new Present(presentName, energyRequired);
            this.presentRepository.Add(present);

            return string.Format(OutputMessages.PresentAdded, present.Name);
        }

        public string CraftPresent(string presentName)
        {
            var present = this.presentRepository.FindByName(presentName);
            var workers = this.dwarfRepository.Models.Where(x => x.Energy >= 50).OrderByDescending(x => x.Instruments.Count).ToArray();

            if (workers.Length == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.DwarfsNotReady);
            }

            

            foreach (var dwarf in workers)
            {
                this.workshop.Craft(present, dwarf);

                if (present.IsDone())
                {
                    return string.Format(OutputMessages.PresentIsDone, present.Name);
                }

                if (dwarf.Energy == 0)
                {
                    this.dwarfRepository.Remove(dwarf);
                }
            }

            return string.Format(OutputMessages.PresentIsNotDone, present.Name);

        }

        public string Report()
        {
            StringBuilder stringBuilder = new StringBuilder();
            var dwarfInfo = string.Join(Environment.NewLine, this.dwarfRepository.Models.Where(x => x.Energy > 0));

            stringBuilder
                .AppendLine($"{this.presentRepository.Models.Where(x => x.IsDone() == true).Count()} presents are done!")
                .AppendLine("Dwarfs info:")
                .AppendLine(dwarfInfo);

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
