using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A.Blog.Entity
{
    public partial class Customer
    {
        public override string ToString()
        {
            return CompanyName;
        }
    }
}
