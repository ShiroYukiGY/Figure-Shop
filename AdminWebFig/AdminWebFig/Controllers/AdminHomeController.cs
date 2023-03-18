using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminWebFig.Models;
namespace AdminWebFig.Controllers
{


    public class AdminHomeController : Controller
    {
        // GET: AdminHome
        AdminData data = new AdminData();
       
        public ActionResult Index()
        {
            var all_figure = from f in data.Products select f;
            return View(all_figure);
        }
      /*  [Authorize]*/
        public ActionResult Create()
        {

            var listNSX = data.NSXes.ToList();
            ViewBag.NSX = new SelectList(listNSX, "idNSX", "tenNSX");

            var listloai = data.Categorys.ToList();
            ViewBag.loai = new SelectList(listloai, "idCategory", "tenCategory");


            var listsize = data.Sizes.ToList();
            ViewBag.size = new SelectList(listsize, "idSize", "tenSize");
            return View();
        }
       /* [Authorize]*/
        [HttpPost]
        public ActionResult Create(FormCollection collection, Product s)
        {


            var E_ten = collection["ten"];
            var E_gia = Convert.ToDecimal(collection["gia"]);
            var E_hinh = collection["hinh"];

            var E_mota = collection["mota"];
            var E_soluongton = Convert.ToInt32(collection["soluongton"]);
            var E_nsx = collection["idNSX"];
            var E_loai = collection["idCategory"];
            var E_HinhDetail1 = collection["hinhDetail1"];
            var E_HinhDetail2 = collection["hinhDetail2"];
            var E_HinhDetail3 = collection["hinhDetail3"];
            var E_size = collection["idSize"];
            if (string.IsNullOrEmpty(E_ten))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                /*ViewBag.tenloai = int.Parse(E_loai);*/
                /* s.maloai = int.Parse(E_loai);*/
                s.ten = E_ten.ToString();
                s.gia = E_gia;
                s.hinh = E_hinh.ToString();

                s.mota = E_mota.ToString();

                s.soluongton = E_soluongton;


                s.idNSX = int.Parse(E_nsx);


                s.idCategory = int.Parse(E_loai);

                s.hinhDetail1 = E_HinhDetail1.ToString();
                s.hinhDetail2 = E_HinhDetail2.ToString();
                s.hinhDetail3 = E_HinhDetail3.ToString();
                s.idSize = int.Parse(E_size);



                data.Products.Add(s);
                data.SaveChanges();
                return RedirectToAction("Index");
            }
            return this.Create();
        }


        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Content/img/" + file.FileName));
            return "/Content/img/" + file.FileName;
        }

   /*     [Authorize]*/
        public ActionResult Detail(int idProduct)
        {
            var D_fig = data.Products.First(m => m.idProduct == idProduct);
            return View(D_fig);
        }

   /*     [Authorize]*/
        public ActionResult Delete(int idProduct)
        {
            var D_theloai = data.Products.First(m => m.idProduct == idProduct);


            return View(D_theloai);
        }
      /*  [Authorize]*/
        [HttpPost]
        public ActionResult Delete(int idProduct, FormCollection collection)
        {
            var D_fig = data.Products.Where(m => m.idProduct == idProduct).First();
            data.Products.Remove(D_fig);
            data.SaveChanges();
            return RedirectToAction("Index");
        }
      /*  [Authorize]*/
        public ActionResult Edit(int idProduct)
        {
            var E_fig = data.Products.First(m => m.idProduct == idProduct);

            var listNSX = data.NSXes.ToList();
            ViewBag.NSX = new SelectList(listNSX, "idNSX", "tenNSX");

            var listloai = data.Categorys.ToList();
            ViewBag.loai = new SelectList(listloai, "idCategory", "tenCategory");


            var listsize = data.Sizes.ToList();
            ViewBag.size = new SelectList(listsize, "idSize", "tenSize");
            return View(E_fig);
        }
    /*    [Authorize]*/
        [HttpPost]
        public ActionResult Edit(int idProduct, FormCollection collection)
        {
            var E_fig = data.Products.First(m => m.idProduct == idProduct);
            var E_ten = collection["ten"];
            var E_gia = Convert.ToDecimal(collection["gia"]);
            var E_hinh = collection["hinh"];

            var E_mota = collection["mota"];
            var E_soluongton = Convert.ToInt32(collection["soluongton"]);
            var E_nsx = collection["idNSX"];
            var E_loai = collection["idCategory"];
            var E_HinhDetail1 = collection["hinhDetail1"];
            var E_HinhDetail2 = collection["hinhDetail2"];
            var E_HinhDetail3 = collection["hinhDetail3"];
            var E_size = collection["idSize"];
            E_fig.idProduct = idProduct;
            if (string.IsNullOrEmpty(E_ten))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                E_fig.ten = E_ten;
                E_fig.gia = E_gia;
                E_fig.hinh = E_hinh;
                E_fig.mota = E_mota;
                E_fig.soluongton = E_soluongton;
                E_fig.idNSX = int.Parse(E_nsx);
                E_fig.idCategory = int.Parse(E_loai);
                E_fig.hinhDetail1 = E_HinhDetail1;
                E_fig.hinhDetail2 = E_HinhDetail2;
                E_fig.hinhDetail3 = E_HinhDetail3;
                E_fig.idSize = int.Parse(E_size);





                UpdateModel(E_fig);
                data.SaveChanges();
                return RedirectToAction("Index");
            }
            return this.Edit(idProduct);
        }


        /*        /-----------------------------------------------them sua xoa danh muc-----------------------------/*/



        public ActionResult Indexdanhmuc()
        {
            var all_category = from f in data.Categorys select f;
            return View(all_category);
        }
        [Authorize]
        public ActionResult Createdanhmuc()
        {
            return View();
        }
       /* [Authorize]*/
        [HttpPost]
        public ActionResult Createdanhmuc(FormCollection collection, Category s)
        {

            var E_tenloai = collection["tenCategory"];
            var E_hinhCategory = collection["hinhCategory"];

            var E_motaCategory = collection["motaCategory"];
            if (string.IsNullOrEmpty(E_tenloai))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                s.tenCategory = E_tenloai.ToString();
                s.hinhCategory = E_hinhCategory.ToString();

                s.motaCategory = E_motaCategory.ToString();
                data.Categorys.Add(s);
                data.SaveChanges();
                return RedirectToAction("Indexdanhmuc");
            }
            return this.Createdanhmuc();
        }
  /*      [Authorize]*/
        public ActionResult Editdanhmuc(int id)
        {
            var E_fig = data.Categorys.First(m => m.idCategory == id);
            return View(E_fig);
        }

  /*      [Authorize]*/
        [HttpPost]
        public ActionResult Editdanhmuc(int id, FormCollection collection)
        {
            var E_fig = data.Categorys.First(m => m.idCategory == id);
            var E_ten = collection["tenCategory"];
            var E_hinh = collection["hinhCategory"];
            E_fig.idCategory = id;

            if (string.IsNullOrEmpty(E_ten))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                E_fig.tenCategory = E_ten;
                E_fig.hinhCategory = E_hinh;

                UpdateModel(E_fig);
                data.SaveChanges();
                return RedirectToAction("Indexdanhmuc");
            }
            return this.Editdanhmuc(id);



        }
  /*      [Authorize]*/
        public ActionResult Deletedanhmuc(int id)
        {

            var D_theloai = data.Categorys.First(m => m.idCategory == id);


            return View(D_theloai);
        }
    /*    [Authorize]*/
        [HttpPost]
        public ActionResult Deletedanhmuc(int id, FormCollection collection)

        {

            var D_fig = data.Categorys.Where(m => m.idCategory == id).First();
            var sanpham = data.Products.Where(x => x.idProduct == id).ToList();
            if (sanpham == null)
            {
                
                data.Categorys.Remove(D_fig);
                data.SaveChanges();
            }
            else
            {
                ViewBag.thongbao = "Phải xoá hết sản phẩm trong danh mục này trước";
            }
           
            return RedirectToAction("Indexdanhmuc");
        }
        /* /-----------------them sua xoa NSX ----------/*/

        public ActionResult IndexNSX()
        {
            var all_NSX = from f in data.NSXes select f;
            return View(all_NSX);
        }
/*        [Authorize]*/
        public ActionResult CreateNSX()
        {
            return View();
        }
     /*   [Authorize]*/
        [HttpPost]
        public ActionResult CreateNSX(FormCollection collection, NSX s)
        {

            var E_tenNSX = collection["tenNSX"];
            var E_hinhNSX = collection["hinhNSX"];

            var E_motaNSX = collection["motaNSX"];
            if (string.IsNullOrEmpty(E_tenNSX))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                s.tenNSX = E_tenNSX.ToString();
                s.hinhNSX = E_hinhNSX.ToString();
                s.motaNSX = E_motaNSX.ToString();
                data.NSXes.Add(s);
                data.SaveChanges();
                return RedirectToAction("IndexNSX");
            }
            return this.CreateNSX();
        }
 /*       [Authorize]*/
        public ActionResult EditNSX(int id)
        {
            var E_NSX = data.NSXes.First(m => m.idNSX == id);
            return View(E_NSX);
        }
/*
        [Authorize]*/
        [HttpPost]
        public ActionResult EditNSX(int id, FormCollection a)
        {
            var E_NSX = data.NSXes.First(m => m.idNSX == id);
            var E_ten = a["tenNSX"];
            var E_hinh = a["hinhNSX"];
            E_NSX.idNSX = id;

            if (string.IsNullOrEmpty(E_ten))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                E_NSX.tenNSX = E_ten;
                E_NSX.hinhNSX = E_hinh;

                UpdateModel(E_NSX);
                data.SaveChanges();
                return RedirectToAction("IndexNSX");
            }
            return this.EditNSX(id);
        }
/*        [Authorize]*/
        public ActionResult DeleteNSX(int id)
        {
            var D_NSX = data.NSXes.First(m => m.idNSX == id);


            return View(D_NSX);
        }
     /*   [Authorize]*/
        [HttpPost]
        public ActionResult DeleteNSX(int id, FormCollection collection)
        {
            var D_NSX = data.NSXes.Where(m => m.idNSX == id).First();
            var sanpham = data.Products.Where(x => x.idProduct == id).ToList();
            if (sanpham == null)
            {
                
                data.NSXes.Remove(D_NSX);
                data.SaveChanges();
                return RedirectToAction("IndexNSX");
            }
            else
            {
                ViewBag.thongbao1 = "Phải xoá hết sản phẩm của nhà sản xuất này trước";
                return View(D_NSX);
            }


          
           
        }


        /*/-------------------giothieu---------/*/

        public ActionResult Gioithieu(int idBaiviet = 1)
        {
            var D_fig = data.Gioithieux.Where(m => m.idBaiviet == idBaiviet).First();
            ViewBag.idBaiviet = idBaiviet;
            return View(D_fig);
        }

/*        [Authorize]*/
        public ActionResult EditGioithieu(int idBaiviet = 1)
        {
            var E_fig = data.Gioithieux.First(m => m.idBaiviet == idBaiviet);


            return View(E_fig);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditGioithieu(FormCollection s, int idBaiviet = 1)
        {
            var E_fig = data.Gioithieux.First(m => m.idBaiviet == idBaiviet);
            var E_topic1 = s["Topic1"];
            var E_topic2 = s["Topic2"];
            var E_topic3 = s["Topic3"];
            var E_topic4 = s["Topic4"];
            var E_topic5 = s["Topic5"];
            var E_topic6 = s["Topic6"];
            var E_topic7 = s["Topic7"];
            var E_topic8 = s["Topic8"];
            var E_topic9 = s["Topic9"];
            var E_topic10 = s["Topic10"];

            var E_para = s["Para"];
            var E_para2 = s["Para2"];
            var E_para3 = s["Para3"];
            var E_para4 = s["Para4"];
            var E_para5 = s["Para5"];
            var E_para6 = s["Para6"];
            var E_para7 = s["Para7"];
            var E_para8 = s["Para8"];

            /*var E_hinh = collection["hinh"];*/








            E_fig.idBaiviet = idBaiviet;
            if (string.IsNullOrEmpty(E_topic1))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                E_fig.Topic1 = E_topic1;
                E_fig.Topic2 = E_topic2;
                E_fig.Topic3 = E_topic3;
                E_fig.Topic4 = E_topic4;
                E_fig.Topic5 = E_topic5;
                E_fig.Topic6 = E_topic6;
                E_fig.Topic7 = E_topic7;
                E_fig.Topic8 = E_topic8;
                E_fig.Topic9 = E_topic9;
                E_fig.Topic10 = E_topic10;

                /* E_fig.hinh = E_hinh;*/

                E_fig.Para = E_para;
                E_fig.Para2 = E_para2;
                E_fig.Para3 = E_para3;
                E_fig.Para4 = E_para4;
                E_fig.Para5 = E_para5;
                E_fig.Para6 = E_para6;
                E_fig.Para7 = E_para7;
                E_fig.Para8 = E_para8;





                UpdateModel(E_fig);
                data.SaveChanges();
                return RedirectToAction("Gioithieu");
            }
            return this.EditGioithieu(idBaiviet);
        }

  /*      [Authorize]*/
        public ActionResult DSDonHang()
        {
            var ds_donhang = data.Orders.ToList();         
            return View(ds_donhang);
        }

        public ActionResult ChiTietDonHang(int id)
        {
            var chitietdonhang = data.OrderDetails.Where(n=>n.IdOrder==id).ToList();          
            return View(chitietdonhang);
        }
        [HttpPost]
        public ActionResult XacNhanDonHang(int id)
        {
            var donhang = data.Orders.Where(n => n.IdOrder == id).FirstOrDefault();
            if (donhang != null)
            {
                donhang.IdStatus = 1;
            data.SaveChanges();
            }
            return RedirectToAction("DSDonHang");
        }
        public ActionResult GiaoHang(int id)
        {
            var donhang = data.Orders.Where(n => n.IdOrder == id).FirstOrDefault();
            if (donhang != null)
            {
                donhang.IdStatus = 2;
                data.SaveChanges();
            }
            return RedirectToAction("DSDonHang");
        }
    }
}