using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6.SupermercatoEF.Context;
using Week6.SupermercatoEF.Models;

namespace Week6.SupermercatoEF.Repository
{
    class RepositoryVendita : IRepositoryVendita
    {
        public Vendita Create(Vendita item)
        {
            using(var ctx = new SupermercatoContext())
            {
                ctx.Entry<Vendita>(item).State = EntityState.Added;
                //ctx.Vendite.Add(item);
                ctx.SaveChanges();
            }
            return item;
        }

        public bool Delete(int numero)
        {
            return false;
        }

        public ICollection<Vendita> GetAll()
        {
            using (var ctx = new SupermercatoContext())
            {
                return ctx.Vendite.ToList();
            }
        }

        public Vendita GetByNumero(int numero)
        {
            using (var ctx = new SupermercatoContext())
            {
                return ctx.Vendite.Find(numero);
            }
        }

        public Vendita Update(int numero, Vendita venditaToUpdate)
        {
            return null;
        }
    }
}
