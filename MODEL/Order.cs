using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class Order
    {
        int number;
         Client clientCode;
         DateTime date;
         string deliveryAddress;
         List<OrderItem> orderItems;

        public Order(Client client, DateTime date, string deliveryAddress, List<OrderItem> orderItems)
        {
            this.clientCode = client;
            this.date = date;
            this.deliveryAddress = deliveryAddress;
            this.orderItems = orderItems;
        }

        public int Number { get => number; set => number = value; }
        public DateTime Date { get => date; set => date = value; }
        public string DeliveryAddress { get => deliveryAddress; set => deliveryAddress = value; }
        internal Client Client { get => clientCode; set => clientCode = value; }
        internal List<OrderItem> OrderItems { get => orderItems; set => orderItems = value; }
    }
}
