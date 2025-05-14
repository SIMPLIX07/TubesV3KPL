using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TubesV3;

namespace TubesV3
{
    public class Pelamar
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string namaLengkap { get; set; }
        public bool status { get; set; }
        public PelamarState state { get; private set; }
        public string skill { get; set; }
        public string pengalaman { get; set; }
        
        public Pelamar(){}
        public Pelamar(string username, string password, string namaLengkap, string skill, string pengalaman)
        {
            this.username = username;
            this.password = password;
            this.namaLengkap = namaLengkap;
            this.skill = skill;
            this.pengalaman = pengalaman;
            this.status = false;
        }


        public static void getAllLowongan()
        {
            ListLowonganPerusahaan.getAllLowongan();
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

