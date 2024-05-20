using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class Category
    {

        int codecateg;
        string descateg;

        public Category(string descateg)
        {
            this.descateg = descateg;
        }
        public Category()
        {
        }

        public int Codecateg { get => codecateg; set => codecateg = value; }
        public string Descateg { get => descateg; set => descateg = value; }
    }
}
