namespace SantaWorkshop.Models.Workshops
{
    using System.Linq;

    using SantaWorkshop.Models.Dwarfs.Contracts;
    using SantaWorkshop.Models.Presents.Contracts;
    using SantaWorkshop.Models.Workshops.Contracts;
    public class Workshop : IWorkshop
    {
        public void Craft(IPresent present, IDwarf dwarf)
        {
            if (dwarf.Instruments.Count == 0 || dwarf.Energy == 0)
            {
                return;
            }

            while (true)
            {
                present.GetCrafted();
                dwarf.Work();
                var instrument = dwarf.Instruments.FirstOrDefault();
                instrument.Use();

                if (present.IsDone())
                {
                    break;
                }


                if (dwarf.Energy == 0)
                {
                    break;
                }

                if (instrument.IsBroken())
                {
                    dwarf.Instruments.Remove(instrument);

                    instrument = dwarf.Instruments.FirstOrDefault();

                    if (instrument == null)
                    {
                        break;
                    }
                }
            }


        }
    }
}
