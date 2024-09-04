using PetStore.Interfaces;
using PetStore.Utils;

namespace PetStore.Logic
{
    public class ProductLogic : IProductLogic  // cjm - Interface added for DI
    {
        private Dictionary<string, IProduct> _products;

        public ProductLogic()
        {
            _products = new Dictionary<string, IProduct>();
        }

        public void AddProduct(IProduct product)
        {
            _products.Add(product.Name, product);
        }
        public List<IProduct> GetAllProducts()
        {
            return _products.Values.ToList();
        }
        public T GenericProductByName<T>(string name) where T : IProduct
        {
            IProduct _product = null;

            _products.TryGetValue(name, out _product);
            return (T)_product;
        }
        public IProduct GetProductByName(string name)
        {
            IProduct _product = null;

            // Just returning catFood[name] would throw an exception if the key doesn't exist.
            _products.TryGetValue(name, out _product);
            return _product;
        }
        // This is more of the C# style of doing things.
        // However, this uses a lambda expression, which we may not have covered in class yet.
        public IProduct SearchForProduct(string name)
        {
            IProduct _product = null;
            name = name.ToLower();

            var keys = _products.Keys.ToList();
            var key = keys.Find(k => k.ToLower().Contains(name));
            if (key != null)
            {
                _product = _products[key];
            }
            return _product;
        }
        public List<IProduct> GetInStockProducts()
        {
            return _products.Values.Where(p => p.Quantity > 0).ToList();
        }
        public List<string> GetInStockProductNames()
        {
            //return _products.Values.Where(p => p.Quantity > 0).Select(p => p.Name).ToList();
            return _products.Values.ToList().InStock().Select(p => p.Name).ToList();
        }
        public List<string> GetOutOfStockProductNames()
        {
            return _products.Values.Where(p => p.Quantity <= 0).Select(p => p.Name).ToList();
        }
        public decimal GetTotalInventoryValue()
        {
            return _products.Values.ToList().InStock().Sum(p => p.Price * p.Quantity);
        }
    }
}
