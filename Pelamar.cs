﻿using System;
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
        public string state { get; set; }
        public string skill { get; set; }
        public string pengalaman { get; set; }

        public Pelamar() { }
        public Pelamar(string username, string password, string namaLengkap, string skill, string pengalaman)
        {
            this.username = username;
            this.password = password;
            this.namaLengkap = namaLengkap;
            this.skill = skill;
            this.pengalaman = pengalaman;
            this.status = false;
            this.state = "Registered";
        }


        public static void getAllLowongan()
        {
            ListLowonganPerusahaan.getAllLowongan();
        }


        public void Hire()
        {
            if (state == "Registered")
            {
                state = "Hired";  
                Console.WriteLine($"{namaLengkap} diterima bekerja.");
            }
            else
            {
                Console.WriteLine($"{namaLengkap} sudah berstatus Hired.");
            }

            Database.Context.Entry(this).State = EntityState.Modified;
            Database.Context.SaveChanges();
        }


        public void PrintStatus()
        {
            Console.WriteLine($"Status {namaLengkap}: {state}");
        }


        

    }
}

