using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TubesV3;

class Program
{
    delegate void MenuAction();

    static void Main(string[] args)
    {
        string connectionString = "server=localhost;port=3306;database=pencari_kerja;user=root;password=";
        Database.Init(connectionString);
        // Menerapkan Pemanggilan Api
        ConfigPerusahaan.InitializeDefaultPerusahaan();
        ConfigLowongan.InitializeDefaultLowongan();
        ConfigPelamar.InitializeDefaultPelamars();


        List<Lowongan> semuaLowongan = Database.Context.Lowongans.ToList();

        Admin admin = new Admin("admin", "admin123");
        QueuePerusahaan queue = new QueuePerusahaan();

        

        DaftarSemuaPelamar semuaPelamar = new DaftarSemuaPelamar();
        DaftarPerusahaanVerified daftarVerified = new DaftarPerusahaanVerified();

        Dictionary<string, MenuAction> mainMenu = new Dictionary<string, MenuAction>
        {
            { "1", () => RegisterPerusahaan() },
            { "2", () => RegisterPelamar() },
            { "3", () => AdminMenu(admin) },
            { "4", () => LoginPerusahaan(daftarVerified) },
            { "5", () => LoginPelamar(semuaPelamar, daftarVerified) }
        };

        string pilihan = "";
        while (pilihan != "0")
        {
            Menu.menuLogin();
            Console.Write("Pilih menu: ");
            pilihan = Console.ReadLine();

            if (mainMenu.ContainsKey(pilihan))
            {
                mainMenu[pilihan]();
            }
            else
            {
                Console.WriteLine("Menu tidak ada");
            }
        }

        Console.WriteLine("Terima kasih telah menggunakan sistem rekrutmen!");
    }

    static void RegisterPerusahaan()
    {
        Console.WriteLine("Masukkan Username: ");
        string usernamePerusahaan = Console.ReadLine();
        Console.WriteLine("Masukkan Password: ");
        string passwordPerusahaan = Console.ReadLine();
        Console.WriteLine("Masukkan Nama Perusahaan: ");
        string namaPerusahaan = Console.ReadLine();
        Console.WriteLine("Masukkan Nomor Perusahaan: ");
        string nomorPerusahaan = Console.ReadLine();

        Perusahaan newPerusahaan = new Perusahaan(usernamePerusahaan, passwordPerusahaan, namaPerusahaan, nomorPerusahaan);
        Database.Context.Perusahaans.Add(newPerusahaan);
        Database.Context.SaveChanges();
        Console.WriteLine("berhasil didaftarkan.\n");
    }

    static void LoginPerusahaan(DaftarPerusahaanVerified daftarVerified)
    {
        Console.Write("Username: ");
        string username = Console.ReadLine();
        Console.Write("Password: ");
        string password = Console.ReadLine();


        daftarVerified.initializeDataPerusahaanVerified(Database.Context.Perusahaans.ToList());

        if (daftarVerified.cekPerusahaan(username, password))
        {
            Perusahaan perusahaanLogin = daftarVerified.verifPerusahaan(username, password);
            PerusahaanMenu(perusahaanLogin);
        }
        else
        {
            Console.WriteLine("Perusahaan tidak terdaftar Atau Perusahaan tidak Verified\n");
        }
    }

    static void PerusahaanMenu(Perusahaan perusahaan)
    {
        Dictionary<string, MenuAction> perusahaanMenu = new Dictionary<string, MenuAction>
        {
            { "1", () => PostLowongan(perusahaan) },
            { "2", () => ReviewPelamar(perusahaan) },
            { "3", () => LihatKaryawan(perusahaan) }
        };

        string pilihan = "";
        while (pilihan != "0")
        {
            Menu.menuPerusahaan();
            Console.Write("Pilih: ");
            pilihan = Console.ReadLine();

            if (perusahaanMenu.ContainsKey(pilihan))
            {
                perusahaanMenu[pilihan]();
            }
            else
            {
                Console.WriteLine("Pilihan tidak ada");
            }
        }
    }

    static void PostLowongan(Perusahaan perusahaan)
    {
        Console.Write("Judul: ");
        string judul = Console.ReadLine();
        Console.Write("Kriteria: ");
        string kriteria = Console.ReadLine();
        Console.Write("Deskripsi: ");
        string deskripsi = Console.ReadLine();
        Console.Write("Lokasi: ");
        string lokasi = Console.ReadLine();
        Console.Write("Gaji: ");
        string gaji = Console.ReadLine();

        Lowongan lowongan = new Lowongan(perusahaan.namaPerusahaan, judul, kriteria, deskripsi, lokasi, gaji);
        Database.Context.Lowongans.Add(lowongan);
        Database.Context.SaveChanges();
        Console.WriteLine("Lowongan berhasil diposting!\n");
    }

    static void ReviewPelamar(Perusahaan perusahaan)
    {
        Console.WriteLine("Review pelamar untuk perusahaan: " + perusahaan.namaPerusahaan);
        perusahaan.accPelamar(perusahaan);
    }

    static void LihatKaryawan(Perusahaan perusahaan)
    {
        Perusahaan.getAllKaryawan(perusahaan);
    }

    static void RegisterPelamar()
    {
        Console.WriteLine("Masukkan Username: ");
        string username = Console.ReadLine();
        Console.WriteLine("Masukkan Password: ");
        string password = Console.ReadLine();
        Console.WriteLine("Masukkan Nama Lengkap: ");
        string namaLengkap = Console.ReadLine();
        Console.WriteLine("Masukkan Skill: ");
        string skill = Console.ReadLine();
        Console.WriteLine("Masukkan Pengalaman: ");
        string pengalaman = Console.ReadLine();

        Pelamar pelamar = new Pelamar(username, password, namaLengkap, skill, pengalaman);

        Database.Context.Pelamars.Add(pelamar);
        Database.Context.SaveChanges();

        Console.WriteLine("Pelamar berhasil didaftarkan.\n");
    }

    static void LoginPelamar(DaftarSemuaPelamar semuaPelamar, DaftarPerusahaanVerified daftar)
    {
        Console.Write("Username: ");
        string username = Console.ReadLine();
        Console.Write("Password: ");
        string password = Console.ReadLine();

        if (semuaPelamar.verfikasiPelamar(username, password))
        {
            Pelamar pelamar = semuaPelamar.cariPelamar(username, password);
            PelamarMenu(pelamar, daftar);
        }
        else
        {
            Console.WriteLine("Pelamar tidak terdaftar\n");
        }
    }

    static void PelamarMenu(Pelamar pelamar, DaftarPerusahaanVerified daftar)
    {
        List<Lowongan> lowongan = Database.Context.Lowongans.ToList();
        daftar.initializeDataPerusahaanVerified(Database.Context.Perusahaans.ToList());

        Dictionary<string, MenuAction> pelamarMenu = new Dictionary<string, MenuAction>
        {
            { "1", () => LihatLowongan(lowongan) },
            { "2", () => LamarLowongan(pelamar, daftar, lowongan) }
        };

        string pilihan = "";
        while (pilihan != "0")
        {
            Menu.menuPelamar();
            Console.Write("Pilih: ");
            pilihan = Console.ReadLine();

            if (pelamarMenu.ContainsKey(pilihan))
            {
                pelamarMenu[pilihan]();
            }
            else
            {
                Console.WriteLine("Pilihan tidak ada");
            }
        }
    }

    static void LihatLowongan(List<Lowongan> lowongan)
    {
        Lowongan lowongans = new Lowongan();
        lowongans.getAllLowongan(lowongan);
    }

    static void LamarLowongan(Pelamar pelamar, DaftarPerusahaanVerified daftar, List<Lowongan> lowongan)
    {
        Lowongan lowongans = new Lowongan();
        lowongans.getAllLowongan(lowongan);

        Console.Write("Nama Perusahaan: ");
        string perusahaan = Console.ReadLine();
        Console.Write("Posisi: ");
        string posisi = Console.ReadLine();

        Lowongan lowonganDipilih = lowongans.getLowonganByPosisi(posisi, lowongan);
        if (lowonganDipilih == null)
        {
            Console.WriteLine("Lowongan tidak ditemukan. Pastikan posisi benar.\n");
            return;
        }

        // Ambil ID perusahaan yang sudah terverifikasi
        Perusahaan perusahaanId = daftar.cekIdPerusahaan(perusahaan);
        if (perusahaanId == null)
        {
            Console.WriteLine("Perusahaan tidak terverifikasi atau tidak ditemukan.\n");
            return;
        }

        LowonganPelamar lp = new LowonganPelamar(pelamar.Id, perusahaanId.Id, lowonganDipilih.Id);
        Database.Context.Lamarans.Add(lp);
        Database.Context.SaveChanges();

        Console.WriteLine("Lamaran berhasil diajukan!\n");
    }

    static void AdminMenu(Admin admin)
    {
        List<Perusahaan> daftarVerified = Database.Context.Perusahaans.ToList();
        Dictionary<string, MenuAction> adminMenu = new Dictionary<string, MenuAction>
        {
            { "1", () => admin.Verifikasi(daftarVerified) }
        };

        string pilihan = "";
        while (pilihan != "0")
        {
            Menu.menuAdmin();
            Console.Write("Pilih: ");
            pilihan = Console.ReadLine();

            if (adminMenu.ContainsKey(pilihan))
            {
                adminMenu[pilihan]();
            }
            else
            {
                Console.WriteLine("Pilihan tidak ada");
            }
        }
    }
}
