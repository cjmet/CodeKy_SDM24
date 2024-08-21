using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetStore.Interfaces;

namespace PetStore.Utils
{
    static public class Extensions
    {
        public static List<T> InStock<T>(this List<T> list) where T : IProduct { return list.Where(x => x.Quantity > 0).ToList(); }

    }
}
