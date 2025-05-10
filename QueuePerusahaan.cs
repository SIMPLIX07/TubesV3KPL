using System;
using System.Collections.Generic;

namespace TubesV3
{
    public class QueuePerusahaan
    {
        public static List<Perusahaan> queuePerusahaan { get; set; } = new List<Perusahaan>();

        public static int isiList()
        {
            return queuePerusahaan.Count;
        }

        public static List<Perusahaan> returnPerusahaan()
        {
            return queuePerusahaan;
        }

        public static void hapusIsilist()
        {
            queuePerusahaan.Clear();
        }

    }
}
