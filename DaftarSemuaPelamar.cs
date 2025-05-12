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
    }
}
