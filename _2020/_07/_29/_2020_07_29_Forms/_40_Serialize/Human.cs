using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _40_Serialize
{
    [Serializable]
    class Human
    {
        //public string Name { get; set; }
        //public int Age { get; set; }
        //public float Height { get; set; }
        //public float Weight { get; set; }
        public string Name;
        public int Age;
        public float Height;
        public float Weight;

        public override string ToString()
        {
            return Name + " : " + Age + " : "
                + Height + " : " + Weight;
        }
    }
}
