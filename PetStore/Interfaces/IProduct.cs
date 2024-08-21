namespace PetStore.Interfaces
{
    public interface IProduct
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public void GetFromConsole();
        public string GetText();
        public string GetJson();
        public string ToString();
        abstract public IProduct NewProduct();
    }
}
