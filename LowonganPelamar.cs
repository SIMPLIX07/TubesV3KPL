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
        public string state { get; set; }

        public LowonganPelamar() { }
        public LowonganPelamar(int pelamarId, int perusahaanId, int lowonganId)
        {
            PelamarId = pelamarId;
            PerusahaanId = perusahaanId;
            LowonganId = lowonganId;
            this.state = "Process";
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
                if (list.Perusahaan.Id == id)
                {
                    Console.WriteLine("Nama: " + list.Pelamar.namaLengkap + "\nPosisi: " + list.Lowongan.title + " \nSkill: " + list.Pelamar.skill + " \nPengalaman: " + list.Pelamar.pengalaman);
                }

            }

        }

        public void Hire()
        {
            if (state == "Process")
            {
                state = "Hired";
                Console.WriteLine("Pelamar diterima bekerja.");

                var context = Database.Context;
                context.Lamarans.Attach(this);
                context.Entry(this).Property(x => x.state).IsModified = true;
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Pelamar sudah berstatus Hired.");
            }
        }

        public void Reject()
        {
            if (state == "Process")
            {
                state = "Rejected";
                Console.WriteLine("Pelamar ditolak.");

                try
                {
                    var context = Database.Context;
                    context.Lamarans.Attach(this);
                    context.Entry(this).Property(x => x.state).IsModified = true;
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(" Gagal menyimpan status penolakan.");
                    if (ex.InnerException != null)
                    {
                        Console.WriteLine("Detail error: " + ex.InnerException.Message);
                    }
                    else
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }

                    
                    state = "Process";
                }
            }
        }

        public static void getLowonganPelamarById(int pelamarId)
        {
            List<LowonganPelamar> lowonganPelamar = Database.Context.Lamarans
                .Where(lp => lp.PelamarId == pelamarId)
                .ToList();

            if (lowonganPelamar.Count == 0)
            {
                Console.WriteLine("Belum ada lamaran yang diajukan.");
                return;
            }

            foreach (LowonganPelamar list in lowonganPelamar)
            {
                if (list.state == "Hired")
                {
                    Console.WriteLine($"Anda Diterima di Perusahaan: {list.Perusahaan.namaPerusahaan}\n");
                }
                else if (list.state == "Rejected")
                {
                    Console.WriteLine($"Anda Ditolak di Perusahaan: {list.Perusahaan.namaPerusahaan}\n");
                }
                else
                {
                    Console.WriteLine($"Lamaran Anda Masih Diproses di: {list.Perusahaan.namaPerusahaan}\n");
                }
            }
        }

    }
}
