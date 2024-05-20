using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class OrderItem
    {
        int code;
        Order orderCode;
        Article articleCode;
        int quantity;

        public OrderItem(int code, Order orderCode, Article articleCode, int quantity)
        {
            this.code = code;
            this.orderCode = orderCode;
            this.articleCode = articleCode;
            this.quantity = quantity;
        }

        public int Code { get => code; set => code = value; }
        public Article ArticleCode { get => articleCode; set => articleCode = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        internal Order OrderCode { get => orderCode; set => orderCode = value; }
    }
}
