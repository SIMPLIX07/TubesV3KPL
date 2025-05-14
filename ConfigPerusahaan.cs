using System.Text.Json;
using System.IO;
using TubesV3;

namespace TubesV3
{
    public static class ConfigPerusahaan
    {
        public static List<Perusahaan> LoadPerusahaan()
        {
            string path = Path.Combine(AppContext.BaseDirectory, "perusahaan.json");


            if (!File.Exists(path))
            {
                return new List<Perusahaan>();
            }

            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<Perusahaan>>(json);
        }

        public static void LoadToVerified(DaftarPerusahaanVerified daftarVerified)
        {
            List<Perusahaan> configData = LoadPerusahaan();
            foreach (var perusahaan in configData)
            {
                daftarVerified.AddPerusahaan(perusahaan);
            }
        }

    }
}
