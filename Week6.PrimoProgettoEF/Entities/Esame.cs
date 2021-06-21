using System;
using System.Collections.Generic;

#nullable disable

namespace Week6.PrimoProgettoEF.Entities
{
    public partial class Esame
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int? Cfu { get; set; }
        public int? Votazione { get; set; }
        public bool? Passato { get; set; }
        public int? StudenteId { get; set; }

        public virtual Studente Studente { get; set; }
    }
}
