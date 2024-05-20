using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class Article
    {
        int code;
        string designation;
        decimal price;
        Category category;
        public Article()
        {
        }
        public Article(string designation, decimal price, Category categoryCode)
        {
            this.Designation = designation;
            this.Price = price;
            this.Category = categoryCode;
        }

        public int Code { get => code; set => code = value; }
        public string Designation { get => designation; set => designation = value; }
        public decimal Price { get => price; set => price = value; }
        public Category Category { get => category; set => category = value; }
    }
}
