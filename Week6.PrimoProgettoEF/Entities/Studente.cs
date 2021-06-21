using System;
using System.Collections.Generic;

#nullable disable

namespace Week6.PrimoProgettoEF.Entities
{
    public partial class Studente
    {
        public Studente()
        {
            Esames = new HashSet<Esame>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime? DataNascita { get; set; }

        public virtual ICollection<Esame> Esames { get; set; }
    }
}
