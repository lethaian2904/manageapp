using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apptiemchung
{
    internal class Lichtiemtreem
    {
        private string Madinhdanh;
        private string Tenvacxin;
        private string Hovaten;
        private DateTime Ngaysinh;
        private DateTime Ngaytiem;
        private string Noitiem;

        public Lichtiemtreem(string madinhdanh, string tenvacxin, string hovaten, DateTime ngaysinh, DateTime ngaytiem, string noitiem)
        {
            Madinhdanh1 = madinhdanh;
            Tenvacxin1 = tenvacxin;
            Hovaten1 = hovaten;
            Ngaysinh1 = ngaysinh;
            Ngaytiem1 = ngaytiem;
            Noitiem1 = noitiem;
        }

        public string Madinhdanh1 { get => Madinhdanh; set => Madinhdanh = value; }
        public string Tenvacxin1 { get => Tenvacxin; set => Tenvacxin = value; }
        public string Hovaten1 { get => Hovaten; set => Hovaten = value; }
        public DateTime Ngaysinh1 { get => Ngaysinh; set => Ngaysinh = value; }
        public DateTime Ngaytiem1 { get => Ngaytiem; set => Ngaytiem = value; }
        public string Noitiem1 { get => Noitiem; set => Noitiem = value; }
    }
}
