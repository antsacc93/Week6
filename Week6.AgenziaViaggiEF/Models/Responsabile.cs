using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6.AgenziaViaggiEF.Models
{
    public class Responsabile
    {
        public int ID { get; set; }
        public String Nome { get; set; }
        public String Cognome { get; set; }
        public String Telefono { get; set; }

        //Relazione 1 a molti tra Gita e Responsabile
        public ICollection<Gita> Gite = new List<Gita>();
    }
}
