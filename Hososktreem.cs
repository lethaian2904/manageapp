using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apptiemchung
{
    internal class Hososktreem
    {
        private string Madinhdanh;
        private string CCCD;
        private string Hovaten;
        private DateTime Ngaysinh;
        private string Gioitinh;
        private string Chieucao;
        private string Cannang;

        public Hososktreem(string madinhdanh, string cCCD, string hovaten, DateTime ngaysinh, string gioitinh, string chieucao, string cannang)
        {
            Madinhdanh1 = madinhdanh;
            CCCD1 = cCCD;
            Hovaten1 = hovaten;
            Ngaysinh1 = ngaysinh;
            Gioitinh1 = gioitinh;
            Chieucao1 = chieucao;
            Cannang1 = cannang;
        }

        public string Madinhdanh1 { get => Madinhdanh; set => Madinhdanh = value; }
        public string CCCD1 { get => CCCD; set => CCCD = value; }
        public string Hovaten1 { get => Hovaten; set => Hovaten = value; }
        public DateTime Ngaysinh1 { get => Ngaysinh; set => Ngaysinh = value; }
        public string Gioitinh1 { get => Gioitinh; set => Gioitinh = value; }
        public string Chieucao1 { get => Chieucao; set => Chieucao = value; }
        public string Cannang1 { get => Cannang; set => Cannang = value; }
    }
}
