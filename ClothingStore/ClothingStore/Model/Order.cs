﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Model
{
    public class Order
    {
        public int Id { get; set; }
        public int IdUser { get; set; }

        public DateTime Date { get; set; }
    }
}
