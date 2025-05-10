using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TubesV3
{
    public class Menu
    {
        public static void menuAdmin()
        {
            Console.WriteLine("1. Verifikasi Perusahaan");
        }

        public static void menuPerusahaan()
        {
            Console.WriteLine("1. Upload Lowongan \n2. Lihat Pelamar Pada Lowongan \n3.Lihat Karyawan");
        }

        public static void menuPelamar()
        {
            Console.WriteLine("1. Lihat Lowongan");
        }
    }
}
