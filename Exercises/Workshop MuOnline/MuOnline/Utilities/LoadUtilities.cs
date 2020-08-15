namespace MuOnline.Utilities
{
    using MuOnline.Repositories;
    public class LoadUtilities
    {
        private static HeroRepository HeroRepository;
        private static ItemRepository ItemRepository;
        private static MonsterRepository MonsterRepository;

        public LoadUtilities()
        {
            HeroRepository = new HeroRepository();
            ItemRepository = new ItemRepository();
            MonsterRepository = new MonsterRepository();
        }

        public static ItemRepository LoadItemRepository() { return ItemRepository; }
        public static HeroRepository LoadHeroRepository() { return HeroRepository; }
        public static MonsterRepository LoadMonsterRepository() { return MonsterRepository; }

    }
}
