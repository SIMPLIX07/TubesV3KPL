using System;
using System.Collections.Generic;
using TubesV3;

class Program
{
    delegate void MenuAction();

    static void Main(string[] args)
    {
        Admin admin = new Admin("admin", "admin123");
        QueuePerusahaan queue = new QueuePerusahaan();
        DaftarSemuaPelamar semuaPelamar = new DaftarSemuaPelamar();
        DaftarPerusahaanVerified daftarVerified = new DaftarPerusahaanVerified();

        Dictionary<string, MenuAction> mainMenu = new Dictionary<string, MenuAction>
        {
            { "1", () => RegisterPerusahaan(queue) },
            { "2", () => RegisterPelamar(semuaPelamar) },
            { "3", () => AdminMenu(admin, queue, daftarVerified) },
            { "4", () => LoginPerusahaan(daftarVerified) },
            { "5", () => LoginPelamar(semuaPelamar) }
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

    // ================== MENU PERUSAHAAN ====================
    static void RegisterPerusahaan(QueuePerusahaan queue)
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
        queue.addPerusahaan(newPerusahaan);
        Console.WriteLine("Perusahaan berhasil didaftarkan.\n");
    }

    static void LoginPerusahaan(DaftarPerusahaanVerified daftarVerified)
    {
        Console.Write("Username: ");
        string username = Console.ReadLine();
        Console.Write("Password: ");
        string password = Console.ReadLine();

        if (daftarVerified.cekPerusahaan(username, password))
        {
            Perusahaan perusahaanLogin = daftarVerified.verifPerusahaan(username, password);
            PerusahaanMenu(perusahaanLogin);
        }
        else
        {
            Console.WriteLine("Perusahaan tidak terdaftar\n");
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
        Perusahaan.addLowongan(lowongan);
        ListLowonganPerusahaan.addLowongan(lowongan);
        Console.WriteLine("Lowongan berhasil diposting!\n");
    }

    static void ReviewPelamar(Perusahaan perusahaan)
    {
        Console.WriteLine("Review pelamar untuk perusahaan: " + perusahaan.namaPerusahaan);
        ListLowonganPelamar.accPelamar(perusahaan.namaPerusahaan);
    }

    static void LihatKaryawan(Perusahaan perusahaan)
    {
        Perusahaan.getAllKaryawan();
    }

    // ================== MENU PELAMAR ====================
    static void RegisterPelamar(DaftarSemuaPelamar semuaPelamar)
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

        Keahlian keahlian = new Keahlian(skill, pengalaman);
        Pelamar pelamar = new Pelamar(username, password, namaLengkap, keahlian);
        semuaPelamar.AddPelamar(pelamar);
        Console.WriteLine("Pelamar berhasil didaftarkan.\n");
    }

    static void LoginPelamar(DaftarSemuaPelamar semuaPelamar)
    {
        Console.Write("Username: ");
        string username = Console.ReadLine();
        Console.Write("Password: ");
        string password = Console.ReadLine();

        if (semuaPelamar.verfikasiPelamar(username, password))
        {
            Pelamar pelamar = semuaPelamar.cariPelamar(username, password);
            PelamarMenu(pelamar);
        }
        else
        {
            Console.WriteLine("Pelamar tidak terdaftar\n");
        }
    }

    static void PelamarMenu(Pelamar pelamar)
    {
        Dictionary<string, MenuAction> pelamarMenu = new Dictionary<string, MenuAction>
        {
            { "1", () => LihatLowongan() },
            { "2", () => LamarLowongan(pelamar) }
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

    static void LihatLowongan()
    {
        Pelamar.getAllLowongan();
    }

    static void LamarLowongan(Pelamar pelamar)
    {
        Pelamar.getAllLowongan();
        Console.Write("Nama Perusahaan: ");
        string perusahaan = Console.ReadLine();
        Console.Write("Posisi: ");
        string posisi = Console.ReadLine();

        LowonganPelamar lp = new LowonganPelamar(pelamar.namaLengkap, perusahaan, posisi, pelamar.keahlian);
        ListLowonganPelamar.addLowongan(lp);
        Console.WriteLine("Lamaran berhasil diajukan!\n");
    }

    // ================== MENU ADMIN ====================
    static void AdminMenu(Admin admin, QueuePerusahaan queue, DaftarPerusahaanVerified daftarVerified)
    {
        Dictionary<string, MenuAction> adminMenu = new Dictionary<string, MenuAction>
        {
            { "1", () => admin.Verifikasi(queue, daftarVerified) }
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
