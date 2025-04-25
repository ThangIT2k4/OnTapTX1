using Ontap3.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Mvc;

namespace Ontap3.Controllers
{
    public class QuanLyNhanVienController : Controller
    {
        // GET: QuanLyNhanVien
        private List<NhanVien> nhanviens;
        
        public QuanLyNhanVienController()
        {
            nhanviens = new List<NhanVien>
            {
                new NhanVien("Nv01", "Nguyễn Vân Anh", "Hà Nội", 15, 200000),
                new NhanVien("Nv02", "Lê Thu Hà", "Hải Phòng", 27, 250000),
                new NhanVien("Nv03", "Nguyễn Văn Hoàng", "Hà Nội", 18, 250000),
                new NhanVien("Nv04", "Trần Thu Hương", "Hải phòng", 25, 190000),
                new NhanVien("Nv05", "Ngô Phương Thảo", "Quảng Ninh", 20, 180000),
            };
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HienThiDanhSach()
        {
            var list1 = nhanviens.Where(nv => nv.songaylam < 20).ToList();
            var list2 = nhanviens.Where(nv => nv.luongngay > 190000).ToList();

            string path1 = "~/App_Data/list1.txt";
            string path2 = "~/App_Data/list2.txt";

            string fullPath1 = Server.MapPath(path1);
            string fullPath2 = Server.MapPath(path2);

            System.IO.File.WriteAllLines(
                fullPath1,
                list1.Select(nv => $"{nv.manv}, {nv.hoten}, {nv.diachi}, {nv.songaylam}, {nv.luongngay}, {nv.tienluong}")
            );

            System.IO.File.WriteAllLines(
                fullPath2,
                list2.Select(nv => $"{nv.manv}, {nv.hoten}, {nv.diachi}, {nv.songaylam}, {nv.luongngay}, {nv.tienluong}")
            );

            ViewBag.list1 = list1;
            ViewBag.list2 = list2;

            return View();
            //return Content(path);
        }

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
            try
            {
                string manv = form["manv"];
                string hoten = form["hoten"];
                string diachi = form["diachi"];
                int songaylam = int.Parse(form["songaylam"]);
                double luongngay = double.Parse(form["luongngay"]);
                var file = Request.Files[0];
                string path = Server.MapPath("~/App_Data/" + file.FileName);
                file.SaveAs(path);
                ViewBag.path = file.FileName;

                var nv = new NhanVien(manv, hoten, diachi, songaylam, luongngay);

                return View("Output", nv);

            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
    }
}

/*
 * 'C:\Program Files\IIS Express\~\App_Data\list1.txt'.'
 * E:\ASP\OnTapTX1\Ontap3\App_Data\list1.txt
 */