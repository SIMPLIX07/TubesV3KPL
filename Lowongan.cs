using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TubesV3
{
    public class Lowongan
    {
        public int Id { get; set; }
        public string namaPerusahaan { get; set; }
        public string title { get; set; }
        public string kriteria { get; set; }
        public string deskripsi { get; set; }
        public string lokasi { get; set; }
        public string gaji { get; set; }

        public Lowongan() { }
        public Lowongan(string namaPerusahaan, string title, string kriteria, string deskripsi, string lokasi, string gaji)
        {
            this.namaPerusahaan = namaPerusahaan;
            this.title = title;
            this.kriteria = kriteria;
            this.deskripsi = deskripsi;
            this.lokasi = lokasi;
            this.gaji = gaji;
        }
        public string GetNamaPerusahaan()
        {
            return namaPerusahaan;
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

        public Lowongan getLowonganByPosisi(string posisi, List<Lowongan> lowongan){
            return lowongan.FirstOrDefault(l => l.title == posisi);
        }

        public void getAllLowongan(List<Lowongan> listlowongan)
        {
            foreach (Lowongan listLowongan in listlowongan)
            {
                Console.WriteLine("Perusahaan: " + listLowongan.namaPerusahaan + "\nPosisi: " + listLowongan.title + " \nKriteria: " + listLowongan.kriteria + " \nDeskripsi: " + listLowongan.deskripsi +
                                    " \nLokasi: " + listLowongan.lokasi + " \nGaji: " + listLowongan.gaji + "\n");
            }
            
        }
    }
}
