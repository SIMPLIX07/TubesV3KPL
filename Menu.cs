using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TubesV3
{
    public class Menu
    {
        public static void menuLogin() {
        Console.WriteLine("\n==== MENU UTAMA ====");
        Console.WriteLine("1. Daftar Perusahaan");
        Console.WriteLine("2. Daftar Pelamar");
        Console.WriteLine("3. Login sebagai Admin");
        Console.WriteLine("4. Login sebagai Perusahaan");
        Console.WriteLine("5. Login sebagai Pelamar");
        Console.WriteLine("0. Keluar");

        }
        public static void menuAdmin()
        {
            Console.WriteLine("1. Verifikasi Perusahaan \n0. Keluar");
        }

        public static void menuPerusahaan()
        {
            Console.WriteLine("1. Upload Lowongan \n2. Lihat Pelamar Pada Lowongan \n3. Lihat Karyawan \n0. Keluar");
        }

        public static void menuPelamar()
        {
            Console.WriteLine("1. Lihat Lowongan \n2. Ajukan Lowongan \n3. Lowongan Yang di Ajukan  \n0. Keluar");
        }
    }
}
