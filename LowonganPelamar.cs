using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TubesV3
{
    public class LowonganPelamar
    {
        public int Id { get; set; }
        public int PelamarId { get; set; }
        public Pelamar Pelamar { get; set; }

        public int PerusahaanId { get; set; }
        public Perusahaan Perusahaan { get; set; }

        public int LowonganId { get; set; }
        public Lowongan Lowongan { get; set; }

        public LowonganPelamar() { }
        public LowonganPelamar(int pelamarId, int perusahaanId, int lowonganId)
        {
            PelamarId = pelamarId;
            PerusahaanId = perusahaanId;
            LowonganId = lowonganId;
        }

        public static List<LowonganPelamar> semuaLowonganPelamar = Database.Context.Lamarans.ToList();

        public string GetPerusahaanTertarik()
        {
            return Perusahaan.namaPerusahaan;
        }

        public string GetNamaPelamar()
        {
            return Pelamar.namaLengkap;
        }

        public string GetPosisi()
        {
            return Lowongan.kriteria;
        }

        public void getAllPelamarByPerusahaanId(List<LowonganPelamar> listlowongan, int id)
        {
            foreach (LowonganPelamar list in listlowongan)
            {
                if(list.Perusahaan.Id == id){
                    Console.WriteLine("Nama: " + list.Pelamar.namaLengkap + "\nPosisi: " + list.Lowongan.title + " \nSkill: " + list.Pelamar.skill + " \nPengalaman: " + list.Pelamar.pengalaman);
                }
                
            }
            
        }
    }
}
