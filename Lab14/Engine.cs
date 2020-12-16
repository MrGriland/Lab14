using System;
namespace Lab14
{
    [Serializable]
    sealed public class Engine
    {
        private string fuel;
        public string Fuel
        {
            get => fuel;
            set => fuel = value;
        }
        private int power;
        public int Power
        {
            get => power;
            set => power = value;
        }
        private double consumption;
        public double Consumption
        {
            get => consumption;
            set => consumption = value;
        }
        private double capacity;
        public double Capacity
        {
            get => capacity;
            set => capacity = value;
        }

        public Engine(string fuel = "petrol", int power = 100, double consumption = 7.4, double capacity = 2.4)
        {
            this.fuel = fuel;
            this.power = power;
            this.consumption = consumption;
            this.capacity = capacity;
        }

        public Engine()
        {
            fuel = "petrol";
            power = 100;
            consumption = 7.4;
            capacity = 2.4;
        }
        public override string ToString()
        {
            return $"fuel type {fuel}, consumption {consumption} l/100km, capacity {capacity}l, power {power}";
        }
    }
}
