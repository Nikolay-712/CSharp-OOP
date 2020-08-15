namespace ViceCity.Core.Factoris
{
    using System;

    using ViceCity.Core.Contracts;
    using ViceCity.Models.Guns;
    using ViceCity.Models.Guns.Contracts;
    public class GunFactory : IFactory
    {
        public  object Create(params object[] info)
        {
            IGun gun = null;

            string gunType = info[0].ToString();
            string gunName = info[1].ToString();

            if (gunType == "Pistol")
            {
                gun = new Pistol(gunName);
            }

            else if (gunType == "Rifle")
            {
                gun = new Rifle(gunName);
            }
            else
            {
                throw new ArgumentException("Invalid gun type!");

            }

            return gun;

        }
    }
}
