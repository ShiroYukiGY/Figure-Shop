using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebFig.Models;
namespace WebFig.Controllers
{
    public class DonHangController : Controller
    {
        // GET: DonHang
        UserData data = new UserData();
        public ActionResult DSDonHang()
        {
            if(Session["TaiKhoan"]!= null)
            {
                Account kh = (Account)Session["TaiKhoan"];
                var list_donhang = data.Orders.Where(n => n.idAccount == kh.idAccount).ToList();
                return View(list_donhang);
            }
            else
            {
                return View("DangNhap","NguoiDung");
            }
        }
        public ActionResult ChiTietDonHang(int id)
        {
             var chitietdonhang = data.OrderDetails.Where(n=>n.IdOrder == id).ToList();
            return View(chitietdonhang);
        }
    }
}