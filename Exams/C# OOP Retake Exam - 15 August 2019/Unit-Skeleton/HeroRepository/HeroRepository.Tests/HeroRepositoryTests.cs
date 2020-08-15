using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    private HeroRepository heroRepository;

    [SetUp]
    public void SetUp()
    {
        this.heroRepository = new HeroRepository();
    }

    [Test]
    public void Correctly_Set_Heros_Colectiom()
    {
        var expectedCount = 0;
        Assert.That(expectedCount, Is.EqualTo(this.heroRepository.Heroes.Count));
    }

    [Test]
    public void Add_Hero_Successfully_Test_Case_Return_Message()
    {
        Hero hero = new Hero("TestHero", 12);

        var returnMessage = this.heroRepository.Create(hero);

        var expectedMessages = "Successfully added hero TestHero with level 12";

        Assert.That(expectedMessages, Is.EqualTo(returnMessage));
    }

    [Test]
    public void Add_Hero_Successfully_Test_Case_Increase_Repository_Count()
    {
        Hero hero = new Hero("TestHero", 12);

        this.heroRepository.Create(hero);

        var expectedCount = 1;

        Assert.That(expectedCount, Is.EqualTo(this.heroRepository.Heroes.Count));
    }

    [Test]
    public void Add_Invalid_Hero()
    {
        Assert.Throws<ArgumentNullException>(() => this.heroRepository.Create(null));
    }

    [Test]
    public void Add_Hero_With_Existing_Name()
    {
        Hero hero = new Hero("TestHero", 12);

        this.heroRepository.Create(hero);

        Assert.Throws<InvalidOperationException>(() => this.heroRepository.Create(hero));
    }

    [Test]
    public void Remove_Hero_Successfully()
    {
        Hero hero = new Hero("TestHero", 12);

        this.heroRepository.Create(hero);

        Assert.IsTrue(this.heroRepository.Remove("TestHero"));

    }
    [Test]
    public void Remove_Hero_Successfully_Test_Case_Decrease_Repository_Count()
    {
        Hero hero = new Hero("TestHero", 12);

        this.heroRepository.Create(hero);

        var expextedCount = 0;

        this.heroRepository.Remove("TestHero");

        Assert.That(expextedCount, Is.EqualTo(this.heroRepository.Heroes.Count));

    }

    [Test]
    [TestCase(null)]
    [TestCase(" ")]
    public void Remove_Hero_With_InValid_Name(string invalidName)
    {
        Hero hero = new Hero("TestHero", 12);

        this.heroRepository.Create(hero);

        Assert.Throws<ArgumentNullException>(() => this.heroRepository.Remove(invalidName));
    }

    [Test]
    public void Get_Hero_With_Highest_Level_Successfully()
    {
        Hero hero = new Hero("TestHero", 12);
        Hero hero1 = new Hero("TestHero1", 15);
        Hero hero2 = new Hero("TestHero2", 2);

        this.heroRepository.Create(hero);
        this.heroRepository.Create(hero1);
        this.heroRepository.Create(hero2);

        var expectedHero = hero1;

        Assert.That(expectedHero, Is.EqualTo(this.heroRepository.GetHeroWithHighestLevel()));
    }

    [Test]
    public void Get_Hero_With_Highest_Level_With_Empty_Hero_Colection()
    {
        Assert.Throws<IndexOutOfRangeException>(() => this.heroRepository.GetHeroWithHighestLevel());
    }

    [Test]
    public void Get_Hero_Successfully()
    {
        Hero hero = new Hero("TestHero", 12);
        Hero hero1 = new Hero("TestHero1", 15);
        Hero hero2 = new Hero("TestHero2", 2);

        this.heroRepository.Create(hero);
        this.heroRepository.Create(hero1);
        this.heroRepository.Create(hero2);

        var expectedHero = hero1;

        Assert.That(expectedHero, Is.EqualTo(this.heroRepository.GetHero("TestHero1")));
    }
}