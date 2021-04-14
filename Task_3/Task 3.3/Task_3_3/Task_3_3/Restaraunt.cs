using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3_3
{
    class Restaraunt
    {
        public Action<User, Pizza> OnCreated;

        public Order CreatePizza(Pizza pizza, User user)
        {
            var order = new Order(pizza);

            OnCreated(user, pizza);

            return order;
        }
    }
}
