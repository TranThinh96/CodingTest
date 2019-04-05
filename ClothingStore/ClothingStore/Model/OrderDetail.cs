using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Model
{
    public class OrderDetail
    {
        public int IdOrder { get; set; }

        public int IdProductDetail { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
