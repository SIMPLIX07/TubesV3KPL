using System;
using System.Collections.Generic;

namespace TubesV3
{
    public class QueuePerusahaan
    {
        public List<Perusahaan> queuePerusahaan { get; set; } = new List<Perusahaan>();

        public int isiList()
        {
            return queuePerusahaan.Count;
        }

        public List<Perusahaan> returnPerusahaan()
        {
            return queuePerusahaan;
        }

        public void hapusIsilist()
        {
            queuePerusahaan.Clear();
        }

        public void addPerusahaan(Perusahaan p) {
            queuePerusahaan.Add(p);
        }


    }
}
