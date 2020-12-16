using System;
namespace Lab14
{
    public class Human: Driving, ISmart
    {
        private string name;
        public string Name
        {
            get => name;
            set => name = value;
        }

        private string surname;
        public string Surname
        {
            get => surname;
            set => surname = value;
        }

        private int year;
        public int Year
        {
            get => year;
            set => year = value;
        }

        public Human(string name,string surname, int year)
        {
            this.name = name;
            this.surname = surname;
            this.year = year;
        }
        public void Think()
        {

        }
        public void Analyze()
        {

        }
        public void Info()
        {
            Console.WriteLine($"Human {Name} {Surname} {Year} year");
        }
        public override string ToString()
        {
            return $"Class about human";
        }
        public new void Start()
        {
            gear = 1;
        }
        public new void Stop()
        {
            gear = 0;
        }
        public new void TurnRight()
        {

        }
        public new void TurnLeft()
        {

        }
    }
}
