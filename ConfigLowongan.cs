using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace TubesV3
{
    public static class ConfigLowongan
    {
        private const string ConfigFile = "Data/lowonganCfg.json";
        
        public static void InitializeDefaultLowongan()
        {
            try
            {
                if (!File.Exists(ConfigFile))
                {
                    Console.WriteLine("File konfigurasi lowongan tidak ditemukan.");
                    return;
                }

                var jsonData = File.ReadAllText(ConfigFile);
                var lowonganDefaults = JsonSerializer.Deserialize<List<Lowongan>>(jsonData);

                foreach (var lowongan in lowonganDefaults)
                {
                    // Cari perusahaan pemilik lowongan
                    var perusahaan = Database.Context.Perusahaans
                        .FirstOrDefault(p => p.namaPerusahaan == lowongan.namaPerusahaan);
                    
                    if (perusahaan != null)
                    {
                        // Set ID perusahaan ke lowongan
                        lowongan.Id = 0; // Reset ID agar dibuat baru
                        
                        var existingLowongan = Database.Context.Lowongans
                            .FirstOrDefault(l => l.title == lowongan.title && 
                                               l.namaPerusahaan == lowongan.namaPerusahaan);
                        
                        if (existingLowongan == null)
                        {
                            Database.Context.Lowongans.Add(lowongan);
                            Console.WriteLine($"Menambahkan lowongan default: {lowongan.title} di {lowongan.namaPerusahaan}");
                        }
                    }
                }
                
                Database.Context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Gagal memuat konfigurasi lowongan: {ex.Message}");
            }
        }
    }
}