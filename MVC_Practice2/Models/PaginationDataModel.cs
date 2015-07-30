using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Practice2.Models
{
    public class PaginationDataModel<T>
    {
        public List<T> Data { get; set; }
        public int PageAmount { get; set; }
        public int PageIndex { get; set; }
    }
}