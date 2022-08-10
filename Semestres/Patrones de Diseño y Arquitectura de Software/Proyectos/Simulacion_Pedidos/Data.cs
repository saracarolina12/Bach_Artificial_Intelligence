using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion_Pedidos
{
    public class Products
    {
        public int idProduct { get; set; }
        public string name { get; set; }
        public int quantity { get; set; }
        //public int price { get; set; }
    }
    public class Root
    {
        public int idStore { get; set; }
        public string storeName { get; set; }
        public List<Products> products { get; set; }
    }
}
