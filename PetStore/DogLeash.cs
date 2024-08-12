namespace PetStore
{
    public class DogLeash : Product
    {
        public int LengthInches { get; set; }
        public string Material { get; set; }
        public override IProduct NewProduct() { return new DogLeash(); }

    }
}
