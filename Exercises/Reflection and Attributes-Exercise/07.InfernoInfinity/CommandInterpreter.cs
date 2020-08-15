using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07.InfernoInfinity
{
    public class CommandInterpreter
    {
        public void Run()
        {
            Repository repository = new Repository();
            string command = Console.ReadLine();

            Weapon currentWeapon = null;
            string weaponName = string.Empty;
            int socketIndex = 0;

            while (command != "END")
            {

                var commandArgs = command.Split(";");

                switch (commandArgs[0])
                {
                    case "Create":
                        repository.AddWeaponInColection(WeaponFactory.CreateWeapon(commandArgs));
                        break;
                    case "Add":

                        weaponName = commandArgs[1];
                        currentWeapon = repository.ShowCurrentWeapon(weaponName);

                        if (currentWeapon != null)
                        {
                            socketIndex = int.Parse(commandArgs[2]);

                            if (socketIndex >= 0 || socketIndex < currentWeapon.GemsColection.Count)
                            {
                                currentWeapon.GemsColection.AddGemInColecton(socketIndex, GemFactory.CreateGem(commandArgs));
                            }

                        }
                        break;
                    case "Remove":
                        weaponName = commandArgs[1];
                        socketIndex = int.Parse(commandArgs[2]);

                        currentWeapon = repository.ShowCurrentWeapon(weaponName);

                        if (currentWeapon != null)
                        {
                            if (socketIndex >= 0 || socketIndex < currentWeapon.GemsColection.Count)
                            {
                                currentWeapon.GemsColection.RemoveGemFromColection(socketIndex);
                            }
                        }

                        break;
                    case "Print":
                        weaponName = commandArgs[1];
                        currentWeapon = repository.ShowCurrentWeapon(weaponName);
                        var totalPowwr = currentWeapon.GemsColection.ShowGemColection().Where(x => x != null);

                        WeaponsDamageModificator.IncreaseWeaponDamageWithGemPower(currentWeapon);

                        if (currentWeapon != null)
                        {
                            StringBuilder builder = new StringBuilder();

                            builder.Append($"{currentWeapon.Name}: {currentWeapon.MinimumDamage}-{currentWeapon.MaximumDamage} Damage, ");
                            builder.Append($"+{totalPowwr.Select(x => x.Strength).Sum()} Strength, ");
                            builder.Append($"+{totalPowwr.Select(x => x.Agility).Sum()} Agility, ");
                            builder.Append($"+{totalPowwr.Select(x => x.Vitality).Sum()} Vitality");

                            Console.WriteLine(builder.ToString());
                        }

                        break;
                }
                command = Console.ReadLine();
            }
        }

    }
}
