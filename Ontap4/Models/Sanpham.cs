using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ontap4.Models
{
    public class Sanpham
    {
        public string masp;
        public string tensanpham;
        public int soluong;
        public double giatien;
        public int giamgia;

        public Sanpham() { }
        public Sanpham(string masp, string tensanpham, int soluong, double giatien, int giamgia)
        {
            this.masp = masp;
            this.tensanpham = tensanpham;
            this.soluong = soluong;
            this.giatien = giatien;
            this.giamgia = giamgia;
        }

        public double thanhtien
        {
            get
            {
                if (giamgia > 0) 
                    return soluong * giatien * 0.9;
                return soluong * giatien;
            }
        }
    }
}