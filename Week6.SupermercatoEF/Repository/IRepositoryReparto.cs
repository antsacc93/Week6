using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6.SupermercatoEF.Models;

namespace Week6.SupermercatoEF.Repository
{
    public interface IRepositoryReparto : IRepository<Reparto>
    {
        public Reparto GetByNumero(int numero);
        public Reparto Update(int numero, Reparto repartoToUpdate);
        public bool Delete(int numero);

        public bool AggiungiDipendente(int numero, Dipendente dipendente);
        public bool AggiungiProdotto(int numero, Prodotto prodotto);

    }
}
