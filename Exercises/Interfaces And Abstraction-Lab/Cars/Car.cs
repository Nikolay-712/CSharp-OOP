using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public abstract class Car : ICar
    {

        public Car(string model, string color)
        {
            this.Model = model;
            this.Color = color;
        }

        public string Model { get; }

        public string Color { get; }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }

        protected virtual string BaseCarInfo()
        {
            return $"{this.Color} {this.GetType().Name} {this.Model}";
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(this.BaseCarInfo())
                .AppendLine(this.Start())
                .AppendLine(this.Stop());

            return stringBuilder.ToString().TrimEnd();
        }

    }
}
