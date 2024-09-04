namespace PetStore.Interfaces
{
    public interface IProduct
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        
        public void GetFromConsole();
        public string GetText();
        public string ToString();
        abstract public IProduct NewProduct();

        public string GetJson();
        abstract public IProduct NewFromJson(string jsonText);
    }
}
