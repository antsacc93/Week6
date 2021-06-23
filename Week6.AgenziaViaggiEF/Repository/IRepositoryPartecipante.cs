using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6.AgenziaViaggiEF.Models;

namespace Week6.AgenziaViaggiEF.Repository
{
    public interface IRepositoryPartecipante : IRepository<Partecipante>
    {
        public bool AdesioneGita(Gita gita, Partecipante partecipante);
    }
}
