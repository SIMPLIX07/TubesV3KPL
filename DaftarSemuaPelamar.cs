using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TubesV3
{
    public class DaftarSemuaPelamar
    {
        public static List<Pelamar> semuaPelamar = new List<Pelamar>();

        public static Pelamar CocokanPelamar(string nama)
        {
            for (int i = 0; i < semuaPelamar.Count; i++)
            {
                if (semuaPelamar[i].namaLengkap == nama)
                {
                    return semuaPelamar[i];
                }
            }
            return null;
        }

        public void AddPelamar(Pelamar newPelamar)
        {
            semuaPelamar.Add(newPelamar);
        }

        public bool verfikasiPelamar(string username, string password) {
            bool confirmasi = false;
            foreach (Pelamar p in semuaPelamar)
            {
                if (p.username == username && p.password == password) {
                    confirmasi = true;
                }
            }
            return confirmasi;
        }

        public Pelamar cariPelamar(string username, string password) {
            
            foreach (Pelamar p in semuaPelamar)
            {
                if (p.username == username && p.password == password){
                    return p;
                }
            }

            return null;
        }
    }
}
