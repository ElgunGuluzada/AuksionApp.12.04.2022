using Entities.Interface;
using System.Collections.Generic;

namespace AuksionApp._12._04._2022
{
    public class Product : IEntity
    {

        public int Id {get; set;}

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private double _price;

        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }
        List<Saler> _salers;
        public List<Saler> Salers
        {
            get { return _salers; }
            set { _salers = value; }
        }
    }
}
