using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtvecklingsUppgift2
{
    class Tävling
    {
        public int ID { get; set; }
        public string Namn { get; set; }
        public List<Deltagare> Alladeltagarna { get; set; }
    }
}
