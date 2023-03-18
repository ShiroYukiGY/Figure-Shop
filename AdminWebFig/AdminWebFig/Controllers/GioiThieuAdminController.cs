using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminWebFig.Models;
namespace AdminWebFig.Controllers
{
    public class GioiThieuAdminController : Controller
    {
        AdminData data = new AdminData();
        // GET: GioiThieuAdmin
        public ActionResult Gioithieu(int idBaiviet = 1)
        {
            var D_fig = data.Gioithieux.Where(m => m.idBaiviet == idBaiviet).First();
            ViewBag.idBaiviet = idBaiviet;
            return View(D_fig);
        }

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
    }
}