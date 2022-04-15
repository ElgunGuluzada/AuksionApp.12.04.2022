using AuksionApp._12._04._2022;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interface
{
    public interface IProduct
    {
        Product Create(Product product);
        Product GetOne(Product product);
        Product GetAll(Product product);
        Product Update(Product product);
        Product Sale(Product product);
    }
}
