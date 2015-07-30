using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Practice2.Models.DTO_Models
{
    public class OrderDTO
    {
        public int OrderId { get;set;}
        public DateTime OrderTime { get; set; }
        public String Status{get;set;}
        public String CustomerName { get; set; }

    }
}