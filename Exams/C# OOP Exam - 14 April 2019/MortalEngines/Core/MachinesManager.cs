namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Common;
    using MortalEngines.Core.Factories;
    using MortalEngines.Entities;
    using MortalEngines.Entities.Contracts;
    using MortalEngines.Repositories;

    public class MachinesManager : IMachinesManager
    {
        private PilotFactory pilotFactory;
        private TankFactory tankFactory;
        private FighterFactory fighterFactory;

        private PilotRepository pilotRepository;
        private MashineRepository machineRepository;

        public MachinesManager()
        {
            this.pilotFactory = new PilotFactory();
            this.pilotRepository = new PilotRepository();

            this.fighterFactory = new FighterFactory();
            this.tankFactory = new TankFactory();
            this.machineRepository = new MashineRepository();
        }

        public string HirePilot(string name)
        {
            IPilot pilot = null;
            var message = string.Format(OutputMessages.PilotExists, name);

            if (!this.pilotRepository.Contains(name))
            {
                pilot = (IPilot)pilotFactory.Create(name);
                this.pilotRepository.AddUnit(pilot);

                message = string.Format(OutputMessages.PilotHired, name);
            }

            return message;
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            Tank tank = null;
            var message = string.Format(OutputMessages.MachineExists, name);

            if (!this.machineRepository.Contains(name))
            {
                tank = (Tank)tankFactory.Create(name, attackPoints, defensePoints);
                this.machineRepository.AddUnit(tank);

                message = string.Format(OutputMessages.TankManufactured,
                    tank.Name, tank.AttackPoints, tank.DefensePoints);
            }

            return message;

        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            Fighter fighter = null;
            var message = string.Format(OutputMessages.MachineExists, name);

            if (!this.machineRepository.Contains(name))
            {
                fighter = (Fighter)fighterFactory.Create(name, attackPoints, defensePoints);
                this.machineRepository.AddUnit(fighter);

                message = string.Format(OutputMessages.FighterManufactured,
                    name, fighter.AttackPoints, fighter.DefensePoints, fighter.Mode);

            }

            return message;
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            string message = string.Empty;

            var pilot = this.pilotRepository.GetByName(selectedPilotName);

            if (pilot == null)
            {
                return string.Format(OutputMessages.PilotNotFound, selectedPilotName);
            }

            var machine = this.machineRepository.GetByName(selectedMachineName);

            if (machine == null)
            {
                return string.Format(OutputMessages.MachineNotFound, selectedMachineName);
            }

            var currentMachine = (IMachine)machine;

            if (currentMachine.Pilot != null)
            {
                return string.Format(OutputMessages.MachineHasPilotAlready, selectedMachineName);
            }

            currentMachine.Pilot = (IPilot)pilot;
            return string.Format(OutputMessages.MachineEngaged, selectedPilotName, selectedMachineName);
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            IMachine attackingMachine = (IMachine)this.machineRepository.GetByName(attackingMachineName);
            IMachine defendingMachine = (IMachine)this.machineRepository.GetByName(defendingMachineName);

            if (attackingMachine == null)
            {
                return string.Format(OutputMessages.MachineNotFound, attackingMachineName);
            }

            if (defendingMachine == null)
            {
                return string.Format(OutputMessages.MachineNotFound, defendingMachineName);
            }

            if (attackingMachine.HealthPoints == 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, attackingMachineName);
            }

            if (defendingMachine.HealthPoints == 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, defendingMachineName);
            }

            attackingMachine.Attack(defendingMachine);

            return string.Format(OutputMessages.AttackSuccessful,
                defendingMachine.Name, attackingMachine.Name, defendingMachine.HealthPoints);
        }

        public string PilotReport(string pilotReporting)
        {
            var pilot = (IPilot)this.pilotRepository.GetByName(pilotReporting);

            if (pilot == null)
            {
                return string.Format(OutputMessages.PilotNotFound, pilotReporting);
            }

            return pilot.Report();

        }

        public string MachineReport(string machineName)
        {
            var machine = (IMachine)this.machineRepository.GetByName(machineName);

            if (machine == null)
            {
                return string.Format(OutputMessages.MachineNotFound, machineName);
            }

            return machine.ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            var fighter = this.machineRepository.GetByName(fighterName);
            var message = string.Format(OutputMessages.MachineNotFound, fighterName);

            if (fighter == null)
            {
                return message;
            }

            Fighter currentFighter = (Fighter)fighter;

            currentFighter.ToggleAggressiveMode();

            message = string.Format(OutputMessages.FighterOperationSuccessful, fighterName);
            return message;
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            var tank = this.machineRepository.GetByName(tankName);
            var message = string.Format(OutputMessages.MachineNotFound, tankName);

            if (tank == null)
            {
                return message;
            }

            Tank currentTank = (Tank)tank;

            currentTank.ToggleDefenseMode();

            message = string.Format(OutputMessages.TankOperationSuccessful);
            return message;

        }
    }
}