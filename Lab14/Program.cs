using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
//using System.Runtime.Serialization.Formatters.Soap;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;

namespace Lab14
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Engine engine = new Engine("diesel", 167, 7.1, 2.4);
            Car car = new Car(4, 1222, 3.5, 210, 2004, "Volvo v60", engine);

            BinaryFormatter binf = new BinaryFormatter();
            using (FileStream fs = new FileStream("car.dat", FileMode.OpenOrCreate))
            {
                binf.Serialize(fs, car);
                Console.WriteLine($"Объект сериализован в Binary");
            }

            using (FileStream fs = new FileStream("car.dat", FileMode.OpenOrCreate))
            {
                Car newCar = (Car)binf.Deserialize(fs);
                Console.WriteLine($"Объект десериализован\n" +
                    $"Название машины: {newCar.Name}");
            }

            // JSON
            using (FileStream fs = new FileStream("engine.json", FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync(fs, engine);
                Console.WriteLine($"Объект сериализован в JSON");
            }

            using (FileStream fs = new FileStream("engine.json", FileMode.OpenOrCreate))
            {
                Engine newEngine = await JsonSerializer.DeserializeAsync<Engine>(fs);
                Console.WriteLine($"Объект десериализован\n" +
                    $"Название двигателя: {newEngine.Fuel}");
            }

            // XML
            XmlSerializer xmlf = new XmlSerializer(engine.GetType());
            using (FileStream fs = new FileStream("engine.xml", FileMode.OpenOrCreate))
            {
                xmlf.Serialize(fs, engine);
                Console.WriteLine($"Объект сериализован в XML");
            }

            using (FileStream fs = new FileStream("engine.xml", FileMode.OpenOrCreate))
            {
                Engine newEngine = (Engine)xmlf.Deserialize(fs);
                Console.WriteLine($"Объект десериализован\n" + $"Название двигателя: {newEngine.Fuel}");
            }


            //SoapFormatter formatter = new SoapFormatter();
            //// получаем поток, куда будем записывать сериализованный объект
            //using (FileStream fs = new FileStream("car.soap", FileMode.OpenOrCreate))
            //{
            //    formatter.Serialize(fs, car);

            //    Console.WriteLine("Объект сериализован");
            //}

            //// десериализация
            //using (FileStream fs = new FileStream("car.soap", FileMode.OpenOrCreate))
            //{
            //    Car newCar = (Car)formatter.Deserialize(fs);

            //    Console.WriteLine($"Объект десериализован\n" + $"Название машины: {newCar.Name}");
            //}  


            Engine[] engines = new Engine[] {new Engine("petrol", 167, 7.1, 2.4), new Engine("diesel", 130, 7.1, 2.4), new Engine("petrol", 167, 12.1, 2.5) };

            XmlSerializer xmlf1 = new XmlSerializer(engines.GetType());
            using (FileStream fs = new FileStream("engines.xml", FileMode.OpenOrCreate))
            {
                xmlf1.Serialize(fs, engines);
                Console.WriteLine($"Объект сериализован в XML");
            }

            using (FileStream fs = new FileStream("engines.xml", FileMode.OpenOrCreate))
            {
                Engine[] newEngines = (Engine[])xmlf1.Deserialize(fs);
                Console.WriteLine($"Объект десериализован\n");
                for (int i = 0; i < newEngines.Length; i++)
                {
                    Console.WriteLine($"Литров у мотора номер {i + 1} на сотню: {newEngines[i].Consumption}");
                }
            }


            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("engines.xml");
            XmlElement xRoot = xDoc.DocumentElement;

            // выбор всех дочерних узлов
            XmlNodeList childnodes = xRoot.SelectNodes("//Engine/Power");
            Console.WriteLine($"Мощности двигателей: ");
            foreach (XmlNode n in childnodes) Console.WriteLine(n.InnerText);

            childnodes = xRoot.SelectNodes("Engine[Fuel='diesel']");
            Console.WriteLine($"Вывод по топливу: ");
            foreach (XmlNode n in childnodes) Console.WriteLine(n.OuterXml);


            XDocument xdoc = XDocument.Load("engines.xml");
            foreach (XElement clockElement in xdoc.Element("ArrayOfEngine").Elements("Engine"))
            {
                XElement nameElement = clockElement.Element("Capacity");
                Console.WriteLine($"Объём двигателя: {nameElement.Value}");
            }
        }
    }
}
