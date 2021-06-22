using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6.AgenziaViaggiEF.Models
{
    public class Itinerario
    {
        public int ID { get; set; }
        public String Descrizione { get; set; }
        public int Durata { get; set; }
        public float Prezzo { get; set; }

        //Relazione 1 a molti con le gite
        public ICollection<Gita> Gite = new List<Gita>();
    }
}
