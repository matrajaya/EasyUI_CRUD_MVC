using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Infrastructure;
using MVC_Practice2.Models;
using MVC_Practice2.Models.DTO_Models;
namespace MVC_Practice2.Controllers
{
    public class OrderController : Controller
    {
        public VideosEntities db = new VideosEntities();
        // GET: Order
        public ActionResult Index()
        {
            return View("EasyUI_Index");
        }

        public ActionResult GetPageList()
        {
            int page = Convert.ToInt32(Request.Params["page"]);//EasyUI请求的是第几页
            int rows = Convert.ToInt32(Request.Params["rows"]);//请求的每页有多少行
            
            //List<OrderDTO> order_list = (from x in db.MyOrders.Include("MyCustomer")
            //                             select new OrderDTO()
            //                             {
            //                                 OrderId = x.Id,
            //                                 Status = x.Status,
            //                                 CustomerName = x.MyCustomer.Name
            //                             }).ToList();
            List<OrderDTO> order_list = (from x in db.MyOrders.Include("MyCustomer") orderby x.Id select x).Skip((page-1) * rows).Take(rows).
                Select(y => new OrderDTO()
                {
                    OrderId = y.Id,
                    OrderTime = y.OrderDate,
                    Status = y.Status,
                    CustomerName = y.MyCustomer.Name
                }).ToList();                                          
                                          
            //获取总行数
            int count = db.MyOrders.Count();
            //计算总页数
            int pageAmount =Convert.ToInt32(Math.Ceiling((count * 1.0) / rows));
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("total", count);
            d.Add("rows", order_list);
            return Json(d, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Del(int id)
        {
            MyOrder target = new MyOrder() 
            { 
                Id=id
            
            };
            DbEntityEntry entry=db.Entry(target);
            entry.State = System.Data.Entity.EntityState.Deleted;
            
            db.SaveChanges();
            return Json("OK");
        }
        public ActionResult Retrieve_Single_Order(int id)
        {
            return View();
        }

    }
}