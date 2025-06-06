using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TubesV3
{
    public class Admin: IObserver
    {
        public int Id { get; set; }
        public string username { get; private set; }
        public string password { get; private set; }
        public List<Perusahaan> queuePerusahaan { get; set; }
        public List<Perusahaan> daftarPerusahaanVerified { get; set; }

        public Admin() { }
        public Admin(string username, string password)
        {
            this.username = username;
            this.password = password;
            this.queuePerusahaan = new List<Perusahaan>();
            this.daftarPerusahaanVerified = new List<Perusahaan>(); // ini penting!
        }


        public void menuAdmin()
        {
            Menu.menuAdmin();
        }
        public void Verifikasi(List<Perusahaan> daftar)
        {
            List<Perusahaan> belumVerifikasi = daftar.Where(p => !p.IsVerified).ToList();

            if (belumVerifikasi == null || belumVerifikasi.Count == 0)
            {
                Console.WriteLine("Tidak ada perusahaan yang mendaftar (semua sudah diverifikasi)");
                return;
            }

            List<Perusahaan> notVerified = new List<Perusahaan>();

            foreach (Perusahaan perusahaan in daftar)
            {
                if (!perusahaan.IsVerified)
                {
                    Console.WriteLine("Nama Perusahaan: " + perusahaan.namaPerusahaan +
                                      "\nNomor Perusahaan: " + perusahaan.nomorPerusahaan +
                                      "\nApakah anda ACC? (Y/N)");
                    string input = Console.ReadLine();

                    if (input == "Y" || input == "y")
                    {
                        perusahaan.IsVerified = true;

                    }
                    else if (input == "N" || input == "n")
                    {
                        notVerified.Add(perusahaan);
                    }
                }
            }

            Database.Context.Perusahaans.UpdateRange(daftar.Where(p => p.IsVerified));

            if (notVerified.Count > 0)
            {
                Database.Context.Perusahaans.RemoveRange(notVerified);
            }
            Database.Context.SaveChanges();
        }
        // Implementation of Update method from IObserver
        public void Update(Pelamar pelamar)
        {
            Console.WriteLine($"Admin diberitahu: Pelamar {pelamar.namaLengkap} statusnya telah berubah menjadi {pelamar.state}.");
        }

    }
}