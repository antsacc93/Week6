using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6.SupermercatoEF.Models
{
    public class Reparto
    {
        public int NumeroReparto { get; set; }
        public String Nome { get; set; }
        public ICollection<Dipendente> Dipendenti { get; set; } = new List<Dipendente>();
        public ICollection<Prodotto> Prodotti { get; set; } = new List<Prodotto>();
    }
}
