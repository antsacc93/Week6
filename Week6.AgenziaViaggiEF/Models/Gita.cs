using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6.AgenziaViaggiEF.Models
{
    public class Gita
    {
        public int ID { get; set; }
        public DateTime DataPartenza { get; set; }

        //Relazione 1 a molti tra Gita e Responsabile
        public int ResponsabileID { get; set; }
        public Responsabile Responsabile { get; set; } //Navigation Property

        //Relazione 1 a molti tra Gita e Itinerario
        public int ItinerarioID { get; set; }
        public Itinerario Itinerario { get; set; } //Navigation Property

        //Relazione molti a molti con i partecipanti
        public ICollection<Partecipante> Partecipanti = new List<Partecipante>();
    }
}
