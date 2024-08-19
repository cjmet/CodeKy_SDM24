using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore
{
    public interface IProductLogic
    {
        void AddProduct(IProduct product);
        IProduct GetProductByName(string name);
        IProduct SearchForProduct(string name);
        List<IProduct> GetAllProducts();
        List<IProduct> GetInStockProducts();
        List<String> GetInStockProductNames();
        List<String> GetOutOfStockProductNames();
    }
}
