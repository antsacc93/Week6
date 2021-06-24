using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6.SupermercatoEF.Models;

namespace Week6.SupermercatoEF.Repository
{
    public interface IRepositoryVendita : IRepository<Vendita>
    {
        public Vendita GetByNumero(int numero);
        public Vendita Update(int numero, Vendita venditaToUpdate);
        public bool Delete(int numero);
    }
}
