using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtvecklingsUppgift2
{
    class Deltagare
    {
        public int ID { get; set; }
        public string Namn { get; set; }
        public int TävlingsId { get; set; }
        public Tävling Tävling { get; set; }
    }
}
