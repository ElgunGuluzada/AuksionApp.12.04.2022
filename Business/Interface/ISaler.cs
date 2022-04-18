using AuksionApp._12._04._2022;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interface
{
    public interface ISaler
    {
        Saler Create(Saler saler);
        Saler GetOne(int id);
        List<Saler> GetAll(string filter = null);
        Saler Update(Saler saler, int id);
        Saler Delete(int id);
        List<Buyer> GetAllBuyers();
        List<Product> GetAllProducts(string name);

    }
}
