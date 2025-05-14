using Microsoft.EntityFrameworkCore;

namespace TubesV3
{
    public class DaftarPerusahaanVerified
    {
        public static List<Perusahaan> legalCompany { get; set; } = new List<Perusahaan>();

        public void initializeDataPerusahaanVerified(List<Perusahaan> verified){
            foreach(Perusahaan perusahaan in verified){
               if(perusahaan.IsVerified){
                    legalCompany.Add(perusahaan);
               }
            }
        }

        public bool cekPerusahaan(string username, string password) {
            bool confirmasi = false;
            foreach (Perusahaan p in legalCompany)
            {
                if (p.username == username && p.password == password) {
                    confirmasi = true;
                }
            }
            return confirmasi;
        }

        public Perusahaan cekIdPerusahaan(string nama) {
            return legalCompany.FirstOrDefault(p => p.namaPerusahaan == nama);
        }

        public Perusahaan verifPerusahaan(string username, string password) {
            foreach (Perusahaan p in legalCompany)
            {
                if (p.username == username && p.password == password) {
                    return p;
                }
            }
            return null;
        }
    }
}
