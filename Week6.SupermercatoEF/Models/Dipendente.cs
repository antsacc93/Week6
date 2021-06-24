using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6.SupermercatoEF.Models
{
    public class Dipendente : IEntityCode
    {
        public String Codice { get; set; }
        public String Nome { get; set; }
        public String Cognome { get; set; }
        public DateTime DataNascita { get; set; }

        public int? RepartoNumero { get; set; }
        public Reparto Reparto { get; set; }

        public override string ToString()
        {
            return $"{Codice} - {Nome} {Cognome} - {DataNascita.ToShortDateString()}";
        }
    }
}
