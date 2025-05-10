using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TubesV3
{
    public class ListLowonganPerusahaan
    {
        private static List<Lowongan> listLowongan { get; set; } = new List<Lowongan>();

        public static void addLowongan(Lowongan lowongan)
        {
            listLowongan.Add(lowongan);
        }

        public static void getAllLowongan(){
            for (int i=0; i<listLowongan.Count(); i++)
            {
                Console.WriteLine("Posisi: " + listLowongan[i].GetTitle() + " \nKriteria: " + listLowongan[i].GetKriteria() + " \nDeskripsi: " + listLowongan[i].GetDeskripsi() +
                    " \nLokasi: " + listLowongan[i].GetLokasi() + " \nGaji: " + listLowongan[i].GetGaji() + "\n");
            }
        }
    }
}
