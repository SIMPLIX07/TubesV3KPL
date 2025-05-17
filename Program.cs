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
        ConfigPelamar.InitializeDefaultPelamars();
        ConfigLowongan.InitializeDefaultLowongan();

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

            if (string.IsNullOrWhiteSpace(pilihan))
            {
                Console.WriteLine("Input tidak boleh kosong!");
                continue;
            }

            if (mainMenu.ContainsKey(pilihan))
            {
                mainMenu[pilihan]();
            }
            else if (pilihan != "0")
            {
                Console.WriteLine("Menu tidak ada");
            }
        }

        Console.WriteLine("Terima kasih telah menggunakan sistem rekrutmen!");
    }

    static string GetNonEmptyInput(string prompt)
    {
        string input;
        do
        {
            Console.Write(prompt);
            input = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Input tidak boleh kosong!");
            }
        } while (string.IsNullOrWhiteSpace(input));

        return input;
    }

    static void RegisterPerusahaan()
    {
        string usernamePerusahaan;
        bool usernameExists;
        do
        {
            usernamePerusahaan = GetNonEmptyInput("Masukkan Username: ");
            usernameExists = Database.Context.Perusahaans.Any(pr => pr.username == usernamePerusahaan);

            if (usernameExists)
            {
                Console.WriteLine("Username sudah digunakan. Silakan coba username lain.");
            }
        }
        while (usernameExists);

        string passwordPerusahaan = GetNonEmptyInput("Masukkan Password: ");
        string namaPerusahaan = GetNonEmptyInput("Masukkan Nama Perusahaan: ");
        string nomorPerusahaan = GetNonEmptyInput("Masukkan Nomor Perusahaan: ");

        Perusahaan newPerusahaan = new Perusahaan(usernamePerusahaan, passwordPerusahaan, namaPerusahaan, nomorPerusahaan);
        Database.Context.Perusahaans.Add(newPerusahaan);
        Database.Context.SaveChanges();
        Console.WriteLine("Perusahaan berhasil didaftarkan.\n");
    }

    static void LoginPerusahaan(DaftarPerusahaanVerified daftarVerified)
    {
        string username = GetNonEmptyInput("Username: ");
        string password = GetNonEmptyInput("Password: ");

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
            pilihan = GetNonEmptyInput("Pilih: ");

            if (perusahaanMenu.ContainsKey(pilihan))
            {
                perusahaanMenu[pilihan]();
            }
            else if (pilihan != "0")
            {
                Console.WriteLine("Pilihan tidak ada");
            }
        }
    }

    static void PostLowongan(Perusahaan perusahaan)
    {
        string judul = GetNonEmptyInput("Posisi: ");
        string kriteria = GetNonEmptyInput("Kriteria: ");
        string deskripsi = GetNonEmptyInput("Deskripsi: ");
        string lokasi = GetNonEmptyInput("Lokasi: ");
        string gaji = GetNonEmptyInput("Gaji: ");

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
        bool usernameExists;
        string username;
        do
        {
            username = GetNonEmptyInput("Masukkan Username: ");
            usernameExists = Database.Context.Pelamars.Any(p => p.username == username);
            if (usernameExists)
            {
                Console.WriteLine("Username sudah digunakan. Silakan coba username lain.");
            }
        }
        while (usernameExists);

        string password = GetNonEmptyInput("Masukkan Password: ");
        string namaLengkap = GetNonEmptyInput("Masukkan Nama Lengkap: ");
        string skill = GetNonEmptyInput("Masukkan Skill: ");
        string pengalaman = GetNonEmptyInput("Masukkan Pengalaman: ");

        Pelamar pelamar = new Pelamar(username, password, namaLengkap, skill, pengalaman);
        if (pelamar != null)
        {
            Database.Context.Pelamars.Add(pelamar);
            Database.Context.SaveChanges();
            Console.WriteLine("Pelamar berhasil didaftarkan.\n");
        }
        else
        {
            Console.WriteLine("Pelamar Gagal didaftarkan.\n");
        }
    }

    static void LoginPelamar(DaftarSemuaPelamar semuaPelamar, DaftarPerusahaanVerified daftar)
    {
        string username = GetNonEmptyInput("Username: ");
        string password = GetNonEmptyInput("Password: ");

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
            { "2", () => LamarLowongan(pelamar, daftar, lowongan) },
            { "3", () => LowonganDiajukan(pelamar) }
        };

        string pilihan = "";
        while (pilihan != "0")
        {
            Menu.menuPelamar();
            pilihan = GetNonEmptyInput("Pilih: ");

            if (pelamarMenu.ContainsKey(pilihan))
            {
                pelamarMenu[pilihan]();
            }
            else if (pilihan != "0")
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

        string perusahaan = GetNonEmptyInput("Nama Perusahaan: ");
        string posisi = GetNonEmptyInput("Posisi: ");

        Lowongan lowonganDipilih = lowongans.getLowonganByPosisi(posisi, lowongan);
        if (lowonganDipilih == null)
        {
            Console.WriteLine("Lowongan tidak ditemukan. Pastikan posisi benar.\n");
            return;
        }

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

    static void LowonganDiajukan(Pelamar pelamar)
    {
        LowonganPelamar.getLowonganPelamarById(pelamar.Id);
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
            pilihan = GetNonEmptyInput("Pilih: ");

            if (adminMenu.ContainsKey(pilihan))
            {
                adminMenu[pilihan]();
            }
            else if (pilihan != "0")
            {
                Console.WriteLine("Pilihan tidak ada");
            }
        }
    }
}