using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ontap1.Models
{
    public class NhanVien
    {
        public string manv;
        public string hoten;
        public string diachi;
        public int songaylam;
        public double luongngay;

        public NhanVien() { }
        public NhanVien(string manv, string hoten, string diachi, int songaylam, double luongngay)
        {
            this.manv = manv;
            this.hoten = hoten;
            this.diachi = diachi;
            this.songaylam = songaylam;
            this.luongngay = luongngay;
        }

        public double tienluong {
            get => songaylam * luongngay;
        }
    }
}