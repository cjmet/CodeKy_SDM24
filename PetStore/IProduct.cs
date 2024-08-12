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
        public string Name { get; set; }

        public void GetFromConsole();
        public String GetText();
        public String GetJson();
        public string ToString();
        abstract public IProduct NewProduct();
    }
}
