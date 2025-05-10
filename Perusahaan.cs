using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TubesV3
{
    public class Perusahaan
    {
        public string username { get; set; }
        public string password { get; set; }
        public string namaPerusahaan { get; set; }
        public string nomorPerusahaan { get; set; }
        public static List<Pelamar> daftarKaryawan { get; set; } = new List<Pelamar>();
        public static List<Lowongan> daftarLowongan { get; set; } = new List<Lowongan>();

        public Perusahaan(string username, string password, string namaPerusahaan, string nomorPerusahaan)
        {
            this.username = username;
            this.password = password;
            this.namaPerusahaan = namaPerusahaan;
            this.nomorPerusahaan = nomorPerusahaan;
        }

        public static void addKaryawan(Pelamar karyawan)
        {
            daftarKaryawan.Add(karyawan);
        }
        public static void addLowongan(Lowongan lowongan)
        {
            daftarLowongan.Add(lowongan);
        }
    }
}
