using System;
using System.IO;
using System.Xml.Serialization; // XmlSerializer

namespace XmlSerialApp
{
    public class Employee
    {
        public int Seq;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Dept { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader(@"C:\Temp\Emp.xml"))
            {
                XmlSerializer xs = new XmlSerializer(typeof(Employee));
                Employee emp = (Employee)xs.Deserialize(reader);

                Console.WriteLine("{0}, {1}", emp.Id, emp.Name);
            }
        }
    }
}