using System;
namespace Lab14
{
    [Serializable]
    public class Car: Transport
    {
        private int maxspeed;
        public int Maxspeed
        {
            get => maxspeed;
            set => maxspeed = value;
        }
        [NonSerialized]
        private int year;
        public int Year
        {
            get => year;
            set => year = value;
        }

        private string name;
        public string Name
        {
            get => name;
            set => name = value;
        }

        private Engine engine;
        public Engine Engine
        {
            get => engine;
            set => engine = value;
        }
        public Car(int wheels = 3, int weight = 555, double length = 543) : base(wheels, weight, length)
        {

        }
        public Car(int wheels, int weight, double length, int maxspeed, int year, string name, Engine engine): base(wheels, weight, length)
        {
            this.maxspeed = maxspeed;
            this.year = year;
            this.name = name;
            this.engine = engine;
        }
        public override void Info()
        {
            Console.WriteLine($"Car {Name} have a {Maxspeed} max speed and {Year} year");
        }
        public override string ToString()
        {
            return $"Class about car";
        }
    }
}
