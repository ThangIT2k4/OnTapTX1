using Ontap1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Mvc;

namespace Ontap1.Controllers
{
    public class QuanlyNhanvienController : Controller
    {
        private List<NhanVien> nhanViens;

        public QuanlyNhanvienController()
        {
            nhanViens = new List<NhanVien>
            {
                new NhanVien("Nv01", "Nguyễn Vân Anh", "Hà Nội", 15, 200000),
                new NhanVien("Nv02", "Lê Thu Hà", "Hải Phòng", 27, 250000),
                new NhanVien("Nv03", "Nguyễn Văn Hoàng", "Hà Nội", 18, 250000),
                new NhanVien("Nv04", "Trần Thu Hương", "Hải phòng", 25, 190000),
                new NhanVien("Nv05", "Ngô Phương Thảo", "Quảng Ninh", 20, 180000)
            };
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ds1()
        {
            var list = nhanViens.Where(nv => nv.songaylam < 20).ToList();
            return View(list);
        }

        public ActionResult ds2()
        {
            var list = nhanViens.Where(nv => nv.luongngay > 190000).ToList();
            return View(list);
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
        public ActionResult CreateUser(FormCollection form)
        {
            string manv = form["id"];
            string hoten = form["name"];
            string diachi = form["address"];
            int songaylam = int.Parse(form["workday"]);
            double luongngay = double.Parse(form["salaryday"]);
            var nv = new NhanVien(manv, hoten, diachi, songaylam, luongngay);
            return View("Output", nv);
        }
    }
}