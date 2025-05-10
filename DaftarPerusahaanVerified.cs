namespace TubesV3
{
    public class DaftarPerusahaanVerified
    {
        public static List<Perusahaan> legalCompany { get; set; } = new List<Perusahaan>();

        public static void addPerusahaan(Perusahaan masukan)
        {
            legalCompany.Add(masukan); // Menambahkan perusahaan ke dalam static list
        }
    }
}
