using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TubesV3
{
    public class ListLowonganPelamar
    {
        public static List<LowonganPelamar> listLowongan { get; set; } = new List<LowonganPelamar>();

        public static void addLowongan(LowonganPelamar lowongan)
        {
            listLowongan.Add(lowongan);
        }

        public static void getPelamarByPerusahaan(string perusahaan)
        {
            for (int i = 0; i < listLowongan.Count; i++)
            {
                if (listLowongan[i].GetPerusahaanTertarik() == perusahaan)
                {
                    Console.WriteLine("Nama Pelamar: " + listLowongan[i].GetNamaPelamar()+ " \nPosisi yang diinginkan: " + listLowongan[i].GetPosisi() + "\nKeahlian: " );
                    listLowongan[i].GetKeahlian();
                    Console.WriteLine("\n");
                }
            }
        }

        public static void accPelamar(string perusahaan)
        {
            getPelamarByPerusahaan(perusahaan);
            Console.WriteLine("1. Rekrut \n2. Delete \n0. Keluar");
            string input = Console.ReadLine();
            while (input != "0")
            {
                switch(input) {
                    case "1": 
                        Console.WriteLine("Masukan nama pelamar yang ingin direkrut");
                        string input2 = Console.ReadLine();
                        Pelamar newKaryawan = DaftarSemuaPelamar.CocokanPelamar(input2);
                        
                        if (newKaryawan != null)
                        {
                            Perusahaan.addKaryawan(newKaryawan);
                            listLowongan.RemoveAll(lowongan => lowongan.GetNamaPelamar() == input2);
                            newKaryawan.status = true;
                            newKaryawan.Hire();

                        }else {
                            Console.WriteLine("Karyawan tidak terdaftar");
                        }
                    break;

                    case "2": 
                        Console.WriteLine("Masukan nama pelamar yang ingin dihapus");
                    string input3 = Console.ReadLine();
                    listLowongan.RemoveAll(lowongan => lowongan.GetNamaPelamar() == input3);

                    break;

                    default:
                        Console.WriteLine("Menu tidak ada");
                    break;
                }
                
                Console.WriteLine("1. Rekrut \n2. Delete \n0. Keluar");
                input = Console.ReadLine();
            }
            
        }
    }
}
