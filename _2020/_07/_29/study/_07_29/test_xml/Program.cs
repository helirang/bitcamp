using System;
using System.IO;
using System.Xml.Serialization; // XmlSerializer

namespace XmlSerialApp
{
    public class Employee   // public 이어야 함
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
            Employee emp = new Employee
            {
                Seq = 1,
                Id = 1001,
                Name = "Tim",
                Dept = "Sales"
            };

            //파일에 출력하는 예
            using (StreamWriter wr = new StreamWriter(@"C:\Temp\Emp.xml"))
            {
                XmlSerializer xs = new XmlSerializer(typeof(Employee));
                xs.Serialize(wr, emp);
            }

            //콘솔에 출력하는 예
            {
                XmlSerializer xs = new XmlSerializer(typeof(Employee));
                //객체로부터 타입을 얻는 다른 방법
                //XmlSerializer xs = new XmlSerializer(emp.GetType()); 

                xs.Serialize(Console.Out, emp);
            }
        }
    }
}