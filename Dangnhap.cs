using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apptiemchung
{
    internal class Dangnhap
    {
        private string Tendangnhap;
        private string Matkhau;
        public Dangnhap()
        {

        }
        public Dangnhap(string Tendangnhap, string Matkhau)
        {
            this.Tendangnhap = Tendangnhap;
            this.Matkhau = Matkhau;
        }

        public string Tendangnhap1 { get => this.Tendangnhap; set => this.Tendangnhap = value; }
        public string Matkhau1 { get => Matkhau; set => Matkhau = value; }

    }
   
}
