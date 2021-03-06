﻿namespace FurnitureManufacturer.Models
{
    using FurnitureManufacturer.Interfaces;

    public class Chair : Furniture, IChair
    {
        public Chair(string model, MaterialType material, decimal price, decimal height, int numberOfLegs) : base(model, material, price, height)
        {
            NumberOfLegs = numberOfLegs;
        }

        public int NumberOfLegs { get; private set; }

        public override string ToString()
        {
            return base.ToString() + string.Format(", Legs: {0}", this.NumberOfLegs);
        }
    }
}
