using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TubesV3;

namespace TubesV3
{
    public class Pelamar
    {
        public string username { get; set; }
        public string password { get; set; }
        public string namaLengkap { get; set; }
        public bool status { get; set; }
        public PelamarState state { get; private set; }
        public  List<Keahlian> keahlian { get; set; }
        

        public Pelamar(string username, string password, string namaLengkap, Keahlian k)
        {
            this.username = username;
            this.password = password;
            this.namaLengkap = namaLengkap;
            this.keahlian = new List<Keahlian>();
            this.keahlian.Add(k);
            this.status = false;
        }


        public static void getAllLowongan()
        {
            ListLowonganPerusahaan.getAllLowongan();
        }

        

        public  void getAllKeahlian()
        {
            foreach(Keahlian k in keahlian)
            {
                Console.WriteLine("Skill: " + k.skill + "Pengalaman: " + k.pengalaman);
            }
        }
        public void Hire()
        {
            if (state == PelamarState.Registered)
            {
                state = PelamarState.Hired;
                Console.WriteLine($"{namaLengkap} diterima bekerja.");
            }
            else
            {
                Console.WriteLine($"{namaLengkap} sudah berstatus Hired.");
            }
        }

        public void PrintStatus()
        {
            Console.WriteLine($"Status {namaLengkap}: {state}");
        }
    }
}

