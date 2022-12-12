using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apptiemchung
{
    internal class Vacxin
    {
        private string Tenvacxin;
        private string Chungloai;
        private string Quocgia;
        private string Giatiennhapkhau;
        private string Thanhtien;
        public Vacxin()
        {

        }
        public Vacxin(string tenvacxin, string chungloai, string quocgia, string giatiennhapkhau, string thanhtien)
        {
            Tenvacxin1 = tenvacxin;
            Chungloai1 = chungloai;
            Quocgia1 = quocgia;
            Giatiennhapkhau1 = giatiennhapkhau;
            Thanhtien1 = thanhtien;
        }

        public string Tenvacxin1 { get => Tenvacxin; set => Tenvacxin = value; }
        public string Chungloai1 { get => Chungloai; set => Chungloai = value; }
        public string Quocgia1 { get => Quocgia; set => Quocgia = value; }
        public string Giatiennhapkhau1 { get => Giatiennhapkhau; set => Giatiennhapkhau = value; }
        public string Thanhtien1 { get => Thanhtien; set => Thanhtien = value; }
    }
}
