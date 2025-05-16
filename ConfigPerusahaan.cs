using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace TubesV3
{
    public static class ConfigPerusahaan
    {
        private const string ConfigFile = "Data/perusahaanCfg.json";
        
        public static void InitializeDefaultPerusahaan()
        {
            try
            {
                if (!File.Exists(ConfigFile))
                {
                    Console.WriteLine("File konfigurasi perusahaan tidak ditemukan.");
                    return;
                }

                var jsonData = File.ReadAllText(ConfigFile);
                var perusahaanDefaults = JsonSerializer.Deserialize<List<Perusahaan>>(jsonData);

                foreach (var perusahaan in perusahaanDefaults)
                {
                    var existingPerusahaan = Database.Context.Perusahaans.FirstOrDefault(p => 
                        p.username == perusahaan.username || 
                        p.namaPerusahaan == perusahaan.namaPerusahaan);
                    
                    if (existingPerusahaan == null)
                    {
                        Database.Context.Perusahaans.Add(perusahaan);
                    }
                }
                
                Database.Context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Gagal memuat konfigurasi perusahaan: {ex.Message}");
            }
        }
    }
}