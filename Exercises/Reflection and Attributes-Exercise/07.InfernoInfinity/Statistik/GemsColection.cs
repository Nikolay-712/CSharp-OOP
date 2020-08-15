namespace _07.InfernoInfinity
{
    using System.Linq;
    using System.Collections.Generic;

    public class GemsColection
    {
        private Gem[] WeaponGemsColection;
        public int Count { get; private set; }
        public GemsColection(int count)
        {
            this.WeaponGemsColection = new Gem[count];
            this.Count = count;
        }

        public void AddGemInColecton(int index, Gem gem)
        {
            this.WeaponGemsColection[index] = gem;
        }

        public void RemoveGemFromColection(int index)
        {
            this.WeaponGemsColection[index] = null;
        }

        public IReadOnlyCollection<Gem> ShowGemColection()
        {
            return this.WeaponGemsColection;
        }


    }
}
