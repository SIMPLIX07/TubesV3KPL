using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace TubesV3
{
    public static class ConfigPelamar
    {
        private const string ConfigFile = "Data/pelamarCfg.json";
        
        public static void InitializeDefaultPelamars()
        {
            try
            {
                if (!File.Exists(ConfigFile))
                {
                    Console.WriteLine("File konfigurasi pelamar tidak ditemukan.");
                    return;
                }

                var jsonOptions = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = true
                };

                var jsonData = File.ReadAllText(ConfigFile);
                var pelamarDefaults = JsonSerializer.Deserialize<List<Pelamar>>(jsonData, jsonOptions);

                foreach (var pelamar in pelamarDefaults)
                {
                    var existingPelamar = Database.Context.Pelamars
                        .FirstOrDefault(p => p.username == pelamar.username || 
                                           p.namaLengkap == pelamar.namaLengkap);
                    
                    if (existingPelamar == null)
                    {
                        // Pastikan state dan status diinisialisasi dengan benar
                        pelamar.state = "Registered"; // Default state
                        pelamar.status = false;       // Default status
                        
                        Database.Context.Pelamars.Add(pelamar);
                        Console.WriteLine($"Pelamar default: {pelamar.namaLengkap}");
                    }
                }
                
                Database.Context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Gagal memuat konfigurasi pelamar: {ex.Message}");
            }
        }
    }
}