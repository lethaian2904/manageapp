using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apptiemchung
{
    internal class Hososk
    {
        private string CCCD;
        private string Hovaten;
        private DateTime Ngaysinh;
        private string Gioitinh;
        private string Nghenghiep;
        private string Dantoc;
        private string Quocgia;
        private string BHYT;
        private string Chieucao;
        private string Cannang;

        public Hososk(string cCCD, string hovaten, DateTime ngaysinh, string gioitinh, string nghenghiep, string dantoc, string quocgia, string bHYT, string chieucao, string cannang)
        {
            CCCD = cCCD;
            Hovaten = hovaten;
            Ngaysinh = ngaysinh;
            Gioitinh = gioitinh;
            Nghenghiep = nghenghiep;
            Dantoc = dantoc;
            Quocgia = quocgia;
            BHYT = bHYT;
            Chieucao = chieucao;
            Cannang = cannang;
        }

        public string CCCD1 { get => CCCD; set => CCCD = value; }
        public string Hovaten1 { get => Hovaten; set => Hovaten = value; }
        public DateTime Ngaysinh1 { get => Ngaysinh; set => Ngaysinh = value; }
        public string Gioitinh1 { get => Gioitinh; set => Gioitinh = value; }
        public string Nghenghiep1 { get => Nghenghiep; set => Nghenghiep = value; }
        public string Dantoc1 { get => Dantoc; set => Dantoc = value; }
        public string Quocgia1 { get => Quocgia; set => Quocgia = value; }
        public string BHYT1 { get => BHYT; set => BHYT = value; }
        public string Chieucao1 { get => Chieucao; set => Chieucao = value; }
        public string Cannang1 { get => Cannang; set => Cannang = value; }
    }
}
