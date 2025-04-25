using OnTap5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnTap5.Controllers
{
    public class QuanlySanphamController : Controller
    {
        private List<Sanpham> sanphams;

        public QuanlySanphamController()
        {
            sanphams = new List<Sanpham> {
                new Sanpham("S01", "Sản phẩm 1", 10, 100, 0),
                new Sanpham("S02", "Sản phẩm 2", 20, 120, 1),
                new Sanpham("S03", "Sản phẩm 3", 15, 200, 1),
                new Sanpham("S04", "Sản phẩm 4", 30, 150, 0),
                new Sanpham("S05", "Sản phẩm 5", 20, 50, 1),
            };
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HienThiDanhSach()
        {
            ViewBag.list1 = sanphams.Where(sp => sp.giatien > 100).ToList();
            ViewBag.list2 = sanphams.Where(sp => sp.giamgia == 1).ToList();

            return View();
        }

        public ActionResult Input()
        {
            return View();
        }
    }
}