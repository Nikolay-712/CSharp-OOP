using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double lenght, double width, double height)
        {
            this.Length = lenght;
            this.Width = width;
            this.Height = height;
        }
        private double Length 
        {
            get { return this.length; } 
            set 
            {
                this.ValidParameters(value, nameof(this.Length));
                this.length = value;
            }
        }

        private double Width 
        {
            get { return this.width; } 
            set 
            {
                this.ValidParameters(value, nameof(this.Width));
                this.width = value; 
            }
        }

        private double Height 
        { 
            get { return this.height; } 
            set
            {
                this.ValidParameters(value, nameof(this.Height));
                this.height = value;
            }
        }

        public double Volume()
        {
            double volume = this.length * this.width * this.height;
            return volume;
        }

        public double LateralSurfaceArea()
        {
            double lateralSurfaceArea = (this.length * this.height * 2) + (this.width * this.height * 2);
            return lateralSurfaceArea;
        }

        public double SurfaceArea()
        {
            double surfaceArea = (this.length * this.width * 2) + LateralSurfaceArea();
            return surfaceArea;
        }

        private void ValidParameters(double value,string parameter)
        {
            if (value < 0)
            {
                throw new ArgumentException($"{parameter} cannot be zero or negative.");
            }
        }
    }
}
