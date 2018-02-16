using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trendy.Entities;

namespace Trendy.Models
{
    public class IndexViewModel
    {
        public List<ProductViewModel> Products { get; set; }

        public int PageIndex { get; set; }
    }
}
