using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace _08.MilitaryElite
{
    public class Program
    {
        static void Main()
        {

            var somting = Assembly.GetExecutingAssembly();









































            var soldiersList = new List<Soldier>();

            string soldierInfo = Console.ReadLine();

            while (soldierInfo != "End")
            {
                var info = soldierInfo.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string id = info[1];
                string firstName = info[2];
                string lastName = info[3];

                decimal salary = 0;
                string corps = string.Empty;

                switch (info[0])
                {
                    case "Private":
                        salary = decimal.Parse(info[4]);
                        Private @private = new Private(id, firstName, lastName, salary);
                        soldiersList.Add(@private);
                        break;
                    case "LieutenantGeneral":
                        salary = decimal.Parse(info[4]);
                        LieutenantGeneral general = new LieutenantGeneral(id, firstName, lastName, salary);

                        var targetId = info.Skip(5);

                        foreach (var currentID in targetId)
                        {
                            var currentSoldier = soldiersList.Where(x => x.Id == currentID).FirstOrDefault();
                            if (currentSoldier != null)
                            {
                                var type = currentSoldier.GetType().Name;

                                if (type == "Private")
                                {
                                    general.AddSoldier((Private)currentSoldier);
                                }
                            }

                        }
                        soldiersList.Add(general);
                        break;
                    case "Engineer":
                        salary = decimal.Parse(info[4]);
                        corps = info[5];


                        if (corps == "Airforces" || corps == "Marines")
                        {
                            Engineer engineer = new Engineer(id, firstName, lastName, salary, corps);

                            var repaiers = info.Skip(6).ToArray();
                            while (repaiers.Length != 0)
                            {
                                var repaierInfo = repaiers.Take(2).ToArray();
                                Repairs repairs = new Repairs(repaierInfo[0], int.Parse(repaierInfo[1]));

                                engineer.AddRepairs(repairs);

                                repaiers = repaiers.Skip(2).ToArray();
                            }
                            soldiersList.Add(engineer);
                        }



                        break;
                    case "Commando":
                        salary = decimal.Parse(info[4]);
                        corps = info[5];



                        if (corps == "Airforces" || corps == "Marines")
                        {

                            Commando commando = new Commando(id, firstName, lastName, salary, corps);

                            var missions = info.Skip(6).ToArray();
                            while (missions.Length != 0)
                            {
                                var missionInfo = missions.Take(2).ToArray();
                                Missions missions1 = new Missions(missionInfo[0], missionInfo[1]);


                                if (missions1.State == "Finished" || missions1.State == "inProgress")
                                {
                                    commando.AddMission(missions1);
                                }


                                missions = missions.Skip(2).ToArray();

                            }
                            soldiersList.Add(commando);

                        }


                        break;
                    case "Spy":
                        string codeNumber = info[4];
                        Spy spy = new Spy(id, firstName, lastName,int.Parse(codeNumber));
                        soldiersList.Add(spy);
                        break;
                    default:
                        break;
                }


                soldierInfo = Console.ReadLine();
            }

            soldiersList.ForEach(Console.WriteLine);
        }

       

    }
}
