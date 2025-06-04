using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TubesV3
{
    public class Perusahaan: IObserver
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string namaPerusahaan { get; set; }
        public string nomorPerusahaan { get; set; }
        public bool IsVerified { get; set; } = false;
        public static List<Pelamar> daftarKaryawan { get; set; } = new List<Pelamar>();
        public static List<Lowongan> daftarLowongan { get; set; } = new List<Lowongan>();

        public Perusahaan() { }
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

        public static void getAllKaryawan(Perusahaan perusahaan)
        {
            List<KaryawanPerusahaan> karyawan = Database.Context.KaryawanPerusahaans
                .Include(k => k.Pelamar)
                .Include(k => k.Perusahaan)
                .Where(k => k.Perusahaan.Id == perusahaan.Id)
                .ToList();

            foreach (KaryawanPerusahaan daftarKaryawan in karyawan)
            {
                if (daftarKaryawan.Pelamar != null && daftarKaryawan.Perusahaan != null)
                {
                    Console.WriteLine("Nama: " + daftarKaryawan.Pelamar.namaLengkap);
                    Console.WriteLine("Skill: " + daftarKaryawan.Pelamar.skill);
                    Console.WriteLine("Pengalaman: " + daftarKaryawan.Pelamar.pengalaman);
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Data pelamar atau perusahaan tidak lengkap (null).");
                }
            }
        }
        
        public void Update(Pelamar pelamar)
        {
            Console.WriteLine($"Perusahaan {namaPerusahaan} diberitahu: Pelamar {pelamar.namaLengkap} statusnya telah berubah menjadi {pelamar.state}.");
        }


        public void accPelamar(Perusahaan perusahaan)
        {
            List<LowonganPelamar> pelamars = Database.Context.Lamarans
                .Where(l => l.PerusahaanId == perusahaan.Id)
                .ToList();

            if (pelamars.Count == 0)
            {
                Console.WriteLine("Belum ada pelamar.");
                return;
            }

            LowonganPelamar showAllPelamar = new LowonganPelamar();
            showAllPelamar.getAllPelamarByPerusahaanId(pelamars, perusahaan.Id);

            Console.WriteLine("1. Rekrut \n2. Delete \n0. Keluar");
            string input = Console.ReadLine();

            while (input != "0")
            {
                switch (input)
                {
                    case "1":
                        Console.WriteLine("Masukan nama pelamar yang ingin direkrut:");
                        string input2 = Console.ReadLine();

                        Pelamar pelamar = Database.Context.Pelamars
                            .FirstOrDefault(p => p.namaLengkap.ToLower() == input2.ToLower());

                        if (pelamar != null)
                        {
                            var lamaran = Database.Context.Lamarans
                                .FirstOrDefault(l => l.PelamarId == pelamar.Id && l.PerusahaanId == perusahaan.Id);

                            if (lamaran != null)
                            {
                                pelamar.Hire();

                                lamaran.Hire();

                                KaryawanPerusahaan newKaryawan = new KaryawanPerusahaan(pelamar.Id, perusahaan.Id);
                                pelamar.status = true;

                                Database.Context.KaryawanPerusahaans.Add(newKaryawan);
                                Database.Context.SaveChanges();

                                Console.WriteLine("Pelamar berhasil direkrut.");
                            }
                            else
                            {
                                Console.WriteLine("Lamaran tidak ditemukan.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Pelamar tidak ditemukan.");
                        }
                        break;

                    case "2":
                        Console.WriteLine("Masukan nama pelamar yang ingin dihapus:");
                        string input3 = Console.ReadLine();

                        Pelamar pelamarDelete = Database.Context.Pelamars
                            .FirstOrDefault(p => p.namaLengkap.ToLower() == input3.ToLower());

                        if (pelamarDelete != null)
                        {
                            var lamaranToDelete = Database.Context.Lamarans
                                .FirstOrDefault(l => l.PelamarId == pelamarDelete.Id && l.PerusahaanId == perusahaan.Id);

                            if (lamaranToDelete != null)
                            {
                                lamaranToDelete.Reject();
                                Database.Context.SaveChanges();

                                Console.WriteLine("Lamaran berhasil ditolak dan dihapus.");
                            }
                            else
                            {
                                Console.WriteLine("Lamaran tidak ditemukan.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Pelamar tidak ditemukan.");
                        }
                        break;

                    default:
                        Console.WriteLine("Menu tidak ada.");
                        break;
                }

                Console.WriteLine("1. Rekrut \n2. Delete \n0. Keluar");
                input = Console.ReadLine();
            }
        }


    }
}