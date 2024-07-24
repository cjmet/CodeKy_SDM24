
namespace PetStore
{
    public class ProductLogic
    {
        private List<Product> _products;
        private Dictionary<string, CatFood> _catFood;
        private Dictionary<string, DogLeash> _dogLeash;

        public ProductLogic()
        {
            _products = new List<Product>();
            _catFood = new Dictionary<string, CatFood>();
            _dogLeash = new Dictionary<string, DogLeash>();
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
            if (product is CatFood)
            {
                _catFood.Add(product.Name, product as CatFood);
            }
            else if (product is DogLeash)
            {
                _dogLeash.Add(product.Name, product as DogLeash);
            }
            else { throw new Exception("the product added is neither CatFood nor DogLeash."); }   // if it's not defined and indexed in a dictionary, throw an exception.
        }

        public List<Product> GetAllProducts()
        {
            return _products;
        }

        public CatFood GetCatFoodByName(string name)
        {
            CatFood catFood = null;

            // Just returning catFood[name] would throw an exception if the key doesn't exist.
            _catFood.TryGetValue(name, out catFood);
            return catFood;
        }

        // GetCatFoodByName only returns exact matches, so lets improve on that.
        // This only returns the first match, not all matches. 
        // We can further improve on this to return all matches later.
        public CatFood SearchForCatFood(string name)
        {
            CatFood catFood = null;
            name = name.ToLower();
            foreach (var key in _catFood.Keys)
            {
                if (key.ToLower().Contains(name))
                {
                    catFood = _catFood[key];
                    break;
                }
            }
            return catFood;
        }

        // Another way to search for CatFood.
        // This is more of the C# style of doing things.
        // However, this uses a lambda expression, which we may not have covered in class yet.
        public CatFood SearchForCatFoodAlt(string name)
        {
            CatFood catFood = null;
            name = name.ToLower();

            var keys = _catFood.Keys.ToList();
            var key = keys.Find(k => k.ToLower().Contains(name));
            if (key != null)
            {
                catFood = _catFood[key];
            }
            return catFood;
        }

    }
}
