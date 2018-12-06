using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labSheet10ConorKoritor
{
    class Bike
    {

        private int ID { get; set; }
        private string Name { get; set; }
        public decimal Price { get; set; }
        public string Gender { get; set; }

        public Bike(int id, string name, decimal price, string gender)
        {
            ID = id;
            Name = name;
            Price = price;
            Gender = gender;
        }

        public override string ToString()
        {
            return string.Format($"{ID}   {Name}   {Price:C}   {Gender}");
        }

    }
}
