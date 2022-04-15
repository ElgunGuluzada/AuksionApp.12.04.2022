using AuksionApp._12._04._2022;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interface
{
    public interface IProduct
    {
        Product Create(Product product);
        Product GetOne(int id);
        List<Product> GetAll();
        Product Update(Product product, int id);
        Product Sale(int id);
    }
}
