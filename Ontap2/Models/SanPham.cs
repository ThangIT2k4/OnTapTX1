using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ontap2.Models
{
    public class SanPham
    {
        public string masp;
        public string tensanpham;
        public int soluong;
        public double giatien;
        public int giamgia;

        public SanPham() { }
        public SanPham(string masp, string tensanpham, int soluong, double giatien, int giamgia)
        {
            this.masp = masp;
            this.tensanpham = tensanpham;
            this.soluong = soluong;
            this.giatien = giatien;
            this.giamgia = giamgia;
        }

        public double thanhtien {
            get {
                double money = soluong * giatien;
                if (giamgia == 1) return money * 0.9;
                return money;
            }
        }
    }
}