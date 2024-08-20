using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PetStore
{
        public interface IProduct 
        {
        public String Name { get; set; }
        public Int32 Quantity { get; set; }

        public void GetFromConsole();
        public String GetText();
        public String GetJson();
        public String ToString();
        abstract public IProduct NewProduct();
    }
}
