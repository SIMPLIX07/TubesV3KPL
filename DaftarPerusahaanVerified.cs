namespace TubesV3
{
    public class DaftarPerusahaanVerified
    {
        public static List<Perusahaan> legalCompany { get; set; } = new List<Perusahaan>();

        public void addPerusahaan(Perusahaan masukan)
        {
            legalCompany.Add(masukan); // Menambahkan perusahaan ke dalam static list
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
