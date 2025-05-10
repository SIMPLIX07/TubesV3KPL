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
                    Console.WriteLine("Nama Pelamar: " + listLowongan[i].GetNamaPelamar()+ " \nPosisi yang diinginkan: " + listLowongan[i].GetPosisi() + "\nKeahlian: " + listLowongan[i].getKeahlian());
                }
            }
        }

        public static void accPelamar(int idxm, string perusahaan)
        {
            getPelamarByPerusahaan(perusahaan);
            Console.WriteLine("1. Rekrut \n2. Delete \n3. Keluar");
            string input = Console.ReadLine();
            int hasilInput = int.Parse(input);
            while (hasilInput != 3)
            {
                if (hasilInput == 1)
                {
                    Console.WriteLine("Masukan index pelamar yang ingin direkrut");
                    string input2 = Console.ReadLine();
                    int hasilInput2 = int.Parse(input2);
                    Pelamar newKaryawan;
                    Perusahaan.addKaryawan(newKaryawan);
                } else if (hasilInput == 2)
                {
                    Console.WriteLine("Masukan index pelamar yang ingin dihapus");
                    string input3 = Console.ReadLine();
                    int hasilInput3 = int.Parse(input3);
                    listLowongan.RemoveAt(hasilInput3);
                    

                }
                input = Console.ReadLine();
                hasilInput = int.Parse(input);
            }
            
        }
        public static void deletePelamar(int idx)
        {

        }
    }
}
