using _02.BookShop;
using FluentAssertions;
using NUnit.Framework;

using System;
using System.Linq;
using System.Reflection;

namespace BookShop.Test
{
    [TestFixture]
    public class BookTest
    {
        Book book = new Book("Test AuthroName", "Kniga na Knigite", 50);

        [Test]
        [TestCase("Nikolay Georgiev", "Kniga na Knigite", 50)]
        public void Correctly_Set_Book_Name(string author, string bookName, decimal price)
        {
            Book book = new Book(author, bookName, price);

            // Assert.That(book.Title, Is.EqualTo("Kniga na Knigite"));
            book.Title.Should().Be("Kniga na Knigite");
        }

        [Test]
        [TestCase("Nikolay Georgiev", "Kniga na Knigite", 50)]
        public void Correctly_Set_Author_Name(string author, string bookName, decimal price)
        {
            Book book = new Book(author, bookName, price);

            //Assert.That(book.Author, Is.EqualTo("Nikolay Georgiev"));
            book.Author.Should().Be("Nikolay Georgiev");
        }
        [Test]
        [TestCase("Nikolay", "Kniga", 50)]
        [TestCase("Vasil CW", "Kn", 50)]
        [TestCase("Nikolay Georgiev", "Oho", -5)]
        public void Test_Set_New_Book(string author, string bookName, decimal price)
        {
            var messages = Assert.Throws<ArgumentException>
                     (() => new Book(author, bookName, price)).Message;

            Console.WriteLine(messages);
        }

        [Test]
        public void Check_Methods()
        {
            Book book = new Book("Nikolay Georgiev", "Kniga na Knigite", 50);

            MethodInfo[] methodInfos = typeof(Book)
                .GetMethods(BindingFlags.NonPublic 
                | BindingFlags.Instance)
                .Where(x => x.Name.Contains("Check")).ToArray();


            string authorName = "Kole Olllle";
            var ValidOrderToMethodChechAuthorName 
                = methodInfos[0]
                .Invoke(book, new object[] { authorName })
                .Should().Be(null);
           

            string bookTitle = "Kniga za Djunglata";
            var ValidOrderToMethodChechBookTitle 
                = methodInfos[1]
                .Invoke(book, new object[] { bookTitle })
                .Should().Be(null);
          

            decimal price = 50;
            var ValidOrderToMethodChechBookPrice 
                = methodInfos[2]
                .Invoke(book, new object[] { price })
                .Should().Be(null); 
            

        }


        
    }
}
