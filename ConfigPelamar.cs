// using System;
// using System.Collections.Generic;
// using System.IO;
// using System.Text.Json;

// namespace TubesV3
// {
//     public class ConfigPelamar
//     {
//         public static void LoadToDaftar(DaftarSemuaPelamar daftar)
//         {
//             string path = Path.Combine(AppContext.BaseDirectory, "pelamar.json");

//             if (!File.Exists(path))
//             {
//                 Console.WriteLine("[DEBUG] File pelamar.json tidak ditemukan.");
//                 return;
//             }

//             string json = File.ReadAllText(path);
//             List<PelamarDTO> pelamarDTOs = JsonSerializer.Deserialize<List<PelamarDTO>>(json);

//             foreach (var dto in pelamarDTOs)
//             {
//                 Pelamar p = new Pelamar(dto.username, dto.password, dto.namaLengkap, dto.keahlian[0]);

//                 // Tambah semua keahlian lainnya
//                 for (int i = 1; i < dto.keahlian.Count; i++)
//                 {
//                     Add(dto.keahlian[i]);
//                 }

//                 daftar.AddPelamar(p);
//             }
//         }
//     }

//     // DTO (Data Transfer Object) buat deserialisasi
//     public class PelamarDTO
//     {
//         public string username { get; set; }
//         public string password { get; set; }
//         public string namaLengkap { get; set; }
//         public bool status { get; set; }
//         public List<Keahlian> keahlian { get; set; }
//     }
// }
