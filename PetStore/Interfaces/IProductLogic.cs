using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Interfaces
{
    public interface IProductLogic
    {
        void AddProduct(IProduct product);
        IProduct GetProductByName(string name);
        public T GenericProductByName<T>(string name) where T : IProduct;
        IProduct SearchForProduct(string name);
        List<IProduct> GetAllProducts();
        List<IProduct> GetInStockProducts();
        List<string> GetInStockProductNames();
        List<string> GetOutOfStockProductNames();
        decimal GetTotalInventoryValue();
    }
}
