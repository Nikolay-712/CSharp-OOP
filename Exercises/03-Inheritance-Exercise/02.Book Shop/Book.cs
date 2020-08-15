using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.BookShop
{
    public class Book
    {
        private string title;

        private string author;

        private decimal price;

        public Book(string author, string title, decimal price)
        {
            this.Author = author;
            this.Title = title;
            this.Price = price;
        }

        public virtual decimal Price
        {
            get { return this.price; }
            protected set 
            {
                CheckPrice(value);
                this.price = value;
            }
        }


        public string Author
        {
            get { return this.author; }
            private set 
            {
                CheckAuthorName(value);
                this.author = value; 
            }
        }


        public string Title
        {
            get { return this.title; }
            private set 
            {
                CheckTitleName(value);
                this.title = value; 
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            var typeName = GetType();



            stringBuilder.AppendLine($"Type: {typeName.Name}")
                .AppendLine($"Title: {this.title}")
                .AppendLine($"Author: { this.author}")
                .AppendLine($"Price: {this.price:f2}");


            return stringBuilder.ToString().TrimEnd();

        }

        private void CheckAuthorName(string name)
        {
            var lastName = name.Split(" ", StringSplitOptions.RemoveEmptyEntries).Skip(1).FirstOrDefault();

            if (lastName != null)
            {
                if (char.IsDigit(lastName[0]))
                {
                    throw new ArgumentException("Author not valid!");
                }
            }
            else
            {
                throw new ArgumentException("Author not valid!");
            }

            
        }

        private void CheckTitleName(string title)
        {
            if (title.Length < 3)
            {
                throw new ArgumentException("Title not valid!");

            }
        }

        private void CheckPrice(decimal price)
        {
            if (price <= 0)
            {
                throw new ArgumentException("Price not valid!");
            }
        }

    }
}
