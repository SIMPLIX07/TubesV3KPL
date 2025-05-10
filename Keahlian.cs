using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TubesV3
{
    public class Keahlian
    {
        public string skill { get; set; }
        public string pengalaman { get; set; }

        public Keahlian(string skill, string pengalaman)
        {
            this.skill = skill;
            this.pengalaman = pengalaman;
        }

        public string getSkill()
        {
            return skill+pengalaman+ " Tahun";
        }

        
    }
}

