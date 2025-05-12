using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TubesV3
{
    public class LowonganPelamar
    {
        private string namaPelamar { get; set; }
        private string perusahaanTertarik { get; set; }
        private string posisi { get; set; }
        public List<Keahlian> keahlian { get; set; }

        public LowonganPelamar(string namaPelamar, string perusahaanTertarik, string posisi, List<Keahlian> keahlian)
        {
            this.namaPelamar = namaPelamar;
            this.perusahaanTertarik = perusahaanTertarik;
            this.posisi = posisi;
            this.keahlian = keahlian;
        }

        public string GetPerusahaanTertarik()
        {
            return perusahaanTertarik;
        }

        public string GetNamaPelamar()
        {
            return namaPelamar;
        }

        public string GetPosisi()
        {
            return posisi;
        }

        public  void GetKeahlian()
        {
            foreach(Keahlian k in keahlian)
            {
                Console.WriteLine("Skill: " + k.skill + "Pengalaman: " + k.pengalaman);
            }
        }

    }
}
