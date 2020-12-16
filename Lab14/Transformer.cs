using System;
namespace Lab14
{
    public class Transformer: Car, ISmart
    {
        public Transformer(int wheels, int weight, double length, int maxspeed, int year, string name, Engine engine) : base(wheels, weight, length, maxspeed, year, name, engine)
        {
        }
        public void Think()
        {

        }
        public void Analyze()
        {

        }
        void ISmart.Info()
        {
            Console.WriteLine($"Transformer {Name} have a {Maxspeed} max speed and {Year} year");
        }
        public override void Info()
        {
            Console.WriteLine($"Car {Name} have a {Maxspeed} max speed and {Year} year");
        }
        public override string ToString()
        {
            return $"Class about transformers";
        }
    }
}
