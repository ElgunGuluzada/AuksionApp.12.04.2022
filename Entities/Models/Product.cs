using Entities.Interface;
using System.Collections.Generic;

namespace AuksionApp._12._04._2022
{
    public class Product:IEntity
    {
        private static int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

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
        public List<Saler> Salers {
            get { return _salers; } 
            set { _salers = value;}    
        }
    }
}
