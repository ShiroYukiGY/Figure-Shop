using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WebFig.Models;
using WebFig.Models.Momo;

namespace WebFig.Controllers
{
    public class UserHomeController : Controller
    {
        // GET: UserHome
        UserData data = new UserData();
        // GET: UserHome


        public ActionResult Index(string SearchString, int idCategory = 0, int idNSX = 0)
        {
            ViewBag.Find = SearchString;
            var all_sach = (from ele in data.Products select ele).OrderBy(p => p.idProduct);
            if (!String.IsNullOrEmpty(SearchString))
            {
                all_sach = (IOrderedQueryable<Product>)all_sach.Where(a => a.ten.Contains(SearchString));
                return View(all_sach.ToList());
            }
            else if (idCategory == 0 && idNSX == 0)
            {
                var sanPhams = data.Products.ToList();
                return View(sanPhams.ToList());
            }
            else if (idCategory != 0)
            {
                var sanPhams = data.Products.Where(x => x.idCategory == idCategory);
                return View(sanPhams.ToList());

            }
            else if (idNSX != 0)
            {
                var sanPhams = data.Products.Where(x => x.idNSX == idNSX);
                return View(sanPhams.ToList());
            }
            return View();

        }

        public ActionResult Detail(int id)
        {
            var D_fig = data.Products.Where(m => m.idProduct == id).FirstOrDefault();
            ViewBag.ProductId = id;
            ViewBag.SoLgTon = D_fig.soluongton;
            return View(D_fig);
        }

 

        //Khi thanh toán xong ở cổng thanh toán Momo, Momo sẽ trả về một số thông tin, trong đó có errorCode để check thông tin thanh toán
        //errorCode = 0 : thanh toán thành công (Request.QueryString["errorCode"])
        //Tham khảo bảng mã lỗi tại: https://developers.momo.vn/#/docs/aio/?id=b%e1%ba%a3ng-m%c3%a3-l%e1%bb%97i
        public ActionResult ConfirmPaymentClient()
        {
            //hiển thị thông báo cho người dùng
            return View();
        }

     

    }
}
    