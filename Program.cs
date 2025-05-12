using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using TubesV3;

class Program
{
    static void Main(string[] args)
{
    Admin admin = new Admin("admin", "admin123");
    Perusahaan p1 = new Perusahaan("telkom", "123", "PT Maju Terus", "001");
    Keahlian k = new Keahlian("IT Developer", "2 Tahun");
    Pelamar p2 = new Pelamar("Budi", "Budios", "Budisantoso", k);
    QueuePerusahaan queue = new QueuePerusahaan();
    DaftarSemuaPelamar semuaPelamar = new DaftarSemuaPelamar();
    
    queue.addPerusahaan(p1);
    semuaPelamar.AddPelamar(p2);

    string pilihan = "";
    while (pilihan != "0")
    {
        Menu.menuLogin();
        Console.Write("Pilih menu: ");
        pilihan = Console.ReadLine();

        switch (pilihan)
        {
            case "1":
                // Daftar Perusahaan
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
                break;

            case "2":
                // Daftar Pelamar
                Console.WriteLine("Masukkan Username: ");
                string usernamePelamar = Console.ReadLine();
                Console.WriteLine("Masukkan Password: ");
                string passwordPelamar = Console.ReadLine();
                Console.WriteLine("Masukkan Nama Lengkap: ");
                string namaPelamar = Console.ReadLine();
                Console.WriteLine("Masukkan Skill: ");
                string skillPelamar = Console.ReadLine();
                Console.WriteLine("Masukkan Pengalaman: ");
                string pengalamanPelamar = Console.ReadLine();

                Keahlian keahlianBaru = new Keahlian(skillPelamar, pengalamanPelamar);
                Pelamar pelamarBaru = new Pelamar(usernamePelamar, passwordPelamar, namaPelamar, keahlianBaru);
                semuaPelamar.AddPelamar(pelamarBaru);
                break;

            case "3":
                // Login Admin
                string menuAdmin = "";
                while (menuAdmin != "0")
                {
                    Menu.menuAdmin();
                    Console.Write("Pilih: ");
                    menuAdmin = Console.ReadLine();


                    if (menuAdmin == "1")
                    {
                        admin.Verifikasi(queue);
                    }
                }
                break;

            case "4":
                // Login Perusahaan
                string menuPerusahaan = "";
                while (menuPerusahaan != "0")
                {
                    Menu.menuPerusahaan();
                    Console.Write("Pilih: ");
                    menuPerusahaan = Console.ReadLine();

                    switch (menuPerusahaan)
                    {
                        case "1":
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

                            Lowongan lowongan = new Lowongan(judul, kriteria, deskripsi, lokasi, gaji);
                            Perusahaan.addLowongan(lowongan);
                            ListLowonganPerusahaan.addLowongan(lowongan);
                            Console.WriteLine("Lowongan berhasil di-upload!");
                            break;

                        case "2":
                            ListLowonganPelamar.getPelamarByPerusahaan(p1.namaPerusahaan);
                            break;

                        case "3":
                            Perusahaan.getAllKaryawan();
                            break;
                    }
                }
                break;

            case "5":
                // Login Pelamar
                string menuPelamar = "";
                while (menuPelamar != "0")
                {
                    Menu.menuPelamar();
                    Console.Write("Pilih: ");
                    menuPelamar = Console.ReadLine();

                    switch (menuPelamar)
                    {
                        case "1":
                            Pelamar.getAllLowongan();
                            break;

                        case "2":
                            Pelamar.getAllLowongan();
                            Console.Write("Masukkan Nama Perusahaan: ");
                            string perusahaan = Console.ReadLine();
                            Console.Write("Masukkan Posisi: ");
                            string posisi = Console.ReadLine();
                            LowonganPelamar lp = new LowonganPelamar(p2.namaLengkap, perusahaan, posisi, p2.keahlian);
                            ListLowonganPelamar.addLowongan(lp);
                            Console.WriteLine("Lowongan berhasil diajukan!");
                            break;
                    }
                }
                break;
        }
    }

    Console.WriteLine("Terima kasih telah menggunakan sistem rekrutmen!");
}

}