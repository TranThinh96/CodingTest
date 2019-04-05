using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Model
{
    public class ProductDetail
    {
        public int Id { get; set; }
        public int IdProduct { get; set; }
        public int IdSize { get; set; }
        public int IdColor { get; set; }

        public int Quantity { get; set; }
    }
}
