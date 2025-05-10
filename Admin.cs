using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TubesV3
{
    public class Admin
    {
        private string username { get; set; }
        private string password { get; set; }
        public List<Perusahaan> queuePerusahaan { get; set; }
        public List<Perusahaan> daftarPerusahaanVerified { get; set; }

        public Admin(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public void menuAdmin()
        {
            Menu.menuAdmin();
        }
        public void Verifikasi()
        {
            if(QueuePerusahaan.isiList() == 0)
            {
                Console.WriteLine("Tidak ada perusahaan yang mendaftar");
            }else
            {
                queuePerusahaan = QueuePerusahaan.returnPerusahaan();
                QueuePerusahaan.hapusIsilist();

                for (int i = queuePerusahaan.Count - 1; i >= 0; i--)
                {
                    Console.WriteLine("Nama Perusahaan: " + queuePerusahaan[i].namaPerusahaan + "\n Nomor Perusahaan: " + queuePerusahaan[i].nomorPerusahaan + "\nApakah anda ACC?");
                    string input = Console.ReadLine();
                    if (input == "Y" || input == "y")
                    {
                        DaftarPerusahaanVerified.addPerusahaan(queuePerusahaan[i]);
                        queuePerusahaan.RemoveAt(i);

                    }
                    else if (input == "N" || input == "n")
                    {
                        queuePerusahaan.RemoveAt(i);
                    }
                    
                }
            }
        }
    }
}
