using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite
{
    public class Commando : SpecialisedSoldier,ICommando
    {

        private List<Missions> missions;

        public Commando(string id, string firstName, string lastName, decimal salary, string corps) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.missions = new List<Missions>();
        }

        public IReadOnlyCollection<Missions> Missions 
        {
            get
            { return this.missions; }
        }

        public void AddMission(Missions missions)
        {
            this.missions.Add(missions);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine(base.ToString());
            builder.AppendLine("Missions:");


            foreach (Missions mission in this.missions)
            {
                builder.AppendLine($"  {mission.ToString()}");
            }


            return builder.ToString().TrimEnd();
        }
    }
}
