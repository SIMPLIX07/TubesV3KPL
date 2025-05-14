namespace TubesV3
{
    public class KaryawanPerusahaan
    {
        public int Id { get; set; }

        public int PelamarId { get; set; }
        public Pelamar Pelamar { get; set; }

        public int PerusahaanId { get; set; }
        public Perusahaan Perusahaan { get; set; }

        public KaryawanPerusahaan(int pelamarId, int perusahaanId)
        {
            PelamarId = pelamarId;
            PerusahaanId = perusahaanId;
        }

        
    }
}