using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json;

namespace TubesV3
{
    
    public class DaftarSemuaPelamar
    {
        public static List<Pelamar> semuaPelamar => Database.Context.Pelamars.ToList();

        public static Pelamar CocokanPelamar(string nama)
        {
            for (int i = 0; i < semuaPelamar.Count; i++)
            {
                if (semuaPelamar[i].namaLengkap == nama)
                {
                    return semuaPelamar[i];
                }
            }
            return null;
        }

        
        public static void TampilkanSemuaPelamar()
        {
            Console.WriteLine("Daftar Pelamar yang Tersedia:");
            foreach (var pelamar in semuaPelamar)
            {
                Console.WriteLine($"- Username: {pelamar.username}, Nama: {pelamar.namaLengkap}");
            }
            Console.WriteLine();
        }

        public static int findPelamarByNama(string nama)
        {
            foreach (Pelamar pelamar in semuaPelamar)
            {
                if (pelamar.namaLengkap == nama)
                {
                    return pelamar.Id;
                }
            }
            return -1;
        }


        public bool verfikasiPelamar(string username, string password)
        {
            bool confirmasi = false;
            foreach (Pelamar p in semuaPelamar)
            {
                if (p.username == username && p.password == password)
                {
                    confirmasi = true;
                }
            }
            return confirmasi;
        }

        public Pelamar cariPelamar(string username, string password)
        {

            foreach (Pelamar p in semuaPelamar)
            {
                if (p.username == username && p.password == password)
                {
                    return p;
                }
            }

            return null;
        }
    }
}