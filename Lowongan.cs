using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TubesV3
{
    public class Lowongan
    {
        public string title { get; set; }
        public string kriteria { get; set; }
        public string deskripsi { get; set; }
        public string lokasi { get; set; }
        public string gaji { get; set; }

        public Lowongan(string title, string kriteria, string deskripsi, string lokasi, string gaji)
        {
            this.title = title;
            this.kriteria = kriteria;
            this.deskripsi = deskripsi;
            this.lokasi = lokasi;
            this.gaji = gaji;
        }
        public string GetTitle()
        {
            return title;
        }

        public string GetKriteria()
        {
            return kriteria;
        }

        public string GetDeskripsi()
        {
            return deskripsi;
        }

        public string GetLokasi()
        {
            return lokasi;
        }

        public string GetGaji()
        {
            return gaji;
        }
    }
}
