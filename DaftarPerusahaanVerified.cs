using Microsoft.EntityFrameworkCore;

namespace TubesV3
{
    public class DaftarPerusahaanVerified
    {
        public static List<Perusahaan> legalCompany { get; set; } = new List<Perusahaan>();

        public void initializeDataPerusahaanVerified(List<Perusahaan> verified)
        {
            legalCompany.Clear(); // penting agar data tidak dobel saat dipanggil ulang
            foreach (Perusahaan perusahaan in verified)
            {
                if (perusahaan.IsVerified)
                {
                    legalCompany.Add(perusahaan);
                }
            }
        }

        public bool cekPerusahaan(string username, string password)
        {
            foreach (Perusahaan p in legalCompany)
            {
                if (p.username == username && p.password == password)
                {
                    return true;
                }
            }
            return false;
        }

        public Perusahaan verifPerusahaan(string username, string password)
        {
            return legalCompany.FirstOrDefault(p => p.username == username && p.password == password);
        }

        public Perusahaan cekIdPerusahaan(string namaPerusahaan)
        {
            return legalCompany.FirstOrDefault(p => p.namaPerusahaan.ToLower() == namaPerusahaan.ToLower());
        }
    }
}