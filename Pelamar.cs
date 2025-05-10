using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TubesV3;

namespace TubesV3
{
    public class Pelamar
    {
        public string username { get; set; }
        public string password { get; set; }
        public string namaLengkap { get; set; }
        public List<Keahlian> keahlian { get; set; }
        

        public Pelamar(string username, string password, string namaLengkap)
        {
            this.username = username;
            this.password = password;
            this.namaLengkap = namaLengkap;
            keahlian = new List<Keahlian>();
        }


        public static void getAllLowongan()
        {
            ListLowonganPerusahaan.getAllLowongan();
        }

        public List<Keahlian> getKeahlian()
        {
            return keahlian;
        }

    }
}

