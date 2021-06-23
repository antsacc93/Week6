using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6.AgenziaViaggiEF.Models
{
    public class Partecipante
    {
        public int ID { get; set; }
        public String Nome { get; set; }
        public String Cognome { get; set; }
        public DateTime DataNascita { get; set; }
        public String Citta { get; set; }
        public String Indirizzo { get; set; }
        public String Email { get; set; }

        //Relazione molti a molti tra Partecipante e Gita
        public ICollection<Gita> Gite { get; set; } = new List<Gita>();
    }
}
