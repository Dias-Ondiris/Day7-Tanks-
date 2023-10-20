using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLib.WordOfTanks
{
    public class Tank
    {
        private string name;
        private int ammoLevel;
        private int armorLevel;
        private int maneuverabilityLevel;

        public Tank(string name,int ammoLevel,int armorLevel,int maneuverabilityLevel)
        {
            this.name = name;
            this.ammoLevel = ammoLevel;
            this.armorLevel = armorLevel;
            this.maneuverabilityLevel = maneuverabilityLevel;
        }

        public static bool operator ^(Tank tank1, Tank tank2)
        {
            int winningCriteriaCount = 0;
            if (tank1.ammoLevel > tank2.ammoLevel) winningCriteriaCount++;
            if (tank1.armorLevel > tank2.armorLevel) winningCriteriaCount++;
            if (tank1.maneuverabilityLevel > tank2.maneuverabilityLevel) winningCriteriaCount++;

            return winningCriteriaCount >= 2;
        }

        public override string ToString()
        {
            return $"Tank: {name}, Ammo Level: {ammoLevel}, Armor Level: {armorLevel}, Maneuverability Level: {maneuverabilityLevel}";
        }
        public static bool operator ==(Tank tank1, Tank tank2)
        {
            return tank1.Equals(tank2);
        }

        public static bool operator !=(Tank tank1, Tank tank2)
        {
            return !tank1.Equals(tank2);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Tank tank = (Tank)obj;
            return name == tank.name;
        }
    }
}
