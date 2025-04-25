using Ontap2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ontap2.Controllers
{
    public class QuanLySanPhamController : Controller
    {
        private List<SanPham> sanPhams;

        public QuanLySanPhamController()
        {
            sanPhams = new List<SanPham>
            {
                new SanPham("S01", "Sản phẩm 1", 10, 100, 0),
                new SanPham("S02", "Sản phẩm 2", 20, 120, 1),
                new SanPham("S03", "Sản phẩm 3", 15, 200, 1),
                new SanPham("S04", "Sản phẩm 4", 30, 150, 0),
                new SanPham("S05", "Sản phẩm 5", 20, 50, 1),
            };
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HienThiDanhSach()
        {
            var list1 = sanPhams.Where(sp => sp.giatien > 100).ToList();
            var list2 = sanPhams.Where(sp => sp.giamgia == 1).ToList();

            ViewBag.list1 = list1;
            ViewBag.list2 = list2;

            return View();
        }

        [HttpGet]
        public ActionResult Input()
        {
            return View();
        }

        public ActionResult Output()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateProduct(FormCollection form)
        {
            try
            {
                string masp = form["masp"];
                string tensanpham = form["tensp"];
                int soluong = int.Parse(form["soluong"]);
                double giatien = double.Parse(form["giatien"]);
                int giamgia = int.Parse(form["giamgia"]);

                var sp = new SanPham(masp, tensanpham, soluong, giatien, giamgia);
                return View("Output", sp);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        public ActionResult Test()
        {
            return View();
        }
    }
}