namespace MXGP.Core
{
    using MXGP.Models.Races;
    using MXGP.Models.Races.Contracts;

    public abstract class RaceFactory
    {
        public static IRace CreateRace(string raceName,int laps)
        {
            IRace race = new Race(raceName,laps);

            return race;

        }
    }
}
