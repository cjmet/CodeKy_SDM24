using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore
{
    internal class CatToys : Product, IProduct
    {
        public override IProduct NewProduct() { return new CatToys(); }
    }
}
