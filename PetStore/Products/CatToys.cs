using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetStore.Interfaces;

namespace PetStore.Products
{
    internal class CatToys : Product, IProduct
    {
        public override IProduct NewProduct() { return new CatToys(); }
    }
}
