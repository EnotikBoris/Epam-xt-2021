using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3_3
{
    class Order
    {
        public Order(Pizza pizza)
        {
            Pizza = pizza;
        }

        public int Number { get; set; }
        public Pizza Pizza { get; set; }
    }
}
