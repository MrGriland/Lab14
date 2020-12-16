using System;
namespace Lab14
{
    [Serializable]
    public class Transport
    {
        protected int wheels;
        protected int Wheels
        {
            get => wheels;
            set => wheels = value;
        }
        protected int weight;
        protected int Weight
        {
            get => weight;
            set => weight = value;
        }
        protected double length;
        protected double Length
        {
            get => length;
            set => length = value;
        }
        public Transport(int wheels, int weight, double length)
        {
            this.wheels = wheels;
            this.weight = weight;
            this.length = length;
        }
        public virtual void Info()
        {
            Console.WriteLine($"Transport have a {wheels} swheels and a weight {weight} kg, {length} length");
        }
        public override string ToString()
        {
            return $"Class about transport";
        }
    }
}
