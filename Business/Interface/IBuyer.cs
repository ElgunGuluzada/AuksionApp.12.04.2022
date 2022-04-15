using AuksionApp._12._04._2022;
using System.Collections.Generic;

namespace Business.Interface
{
    public interface IBuyer
    {
        Buyer Create(Buyer buyer);
        Buyer GetOne(int id);
        List<Buyer> GetAll();
        Buyer Update(Buyer buyer, int id);
        Buyer Delete(int id);




    }
}
