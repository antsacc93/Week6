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
    public class RepositoryProdotto : IRepositoryEntityCode, IRepository<Prodotto>
    {
        public Prodotto Create(Prodotto item)
        {
            using (var ctx = new SupermercatoContext())
            {
                if (item != null)
                {
                    try
                    {
                        ctx.Entry<Prodotto>(item).State = EntityState.Added;
                        //ctx.Prodotti.Add(item);
                        ctx.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }

                }
            }
            return item;
        }

        public bool Delete(string codice)
        {
            Prodotto prodottoToDelete = null;
            bool esito = false;
            using (var ctx = new SupermercatoContext())
            {
                if (codice != null || codice.Length != 0)
                {
                    ctx.Prodotti.Find(codice);
                }
            }
            using (var ctx = new SupermercatoContext())
            {
                if (prodottoToDelete != null)
                {
                    try
                    {
                        ctx.Entry<Prodotto>(prodottoToDelete).State = EntityState.Deleted;
                        //ctx.Prodotti.Remove(prodottoToDelete);
                        ctx.SaveChanges();
                        esito = true;
                    }
                    catch (Exception ex)
                    {
                        return esito;
                    }
                }
            }
            return esito;
        }

        public ICollection<Prodotto> GetAll()
        {
            using (var ctx = new SupermercatoContext())
            {
                return ctx.Prodotti.ToList();
            }
        }

        public IEntityCode GetByCode(string codice)
        {
            using (var ctx = new SupermercatoContext())
            {
                if (codice == null || codice.Length == 0)
                {
                    return null;
                }
                return ctx.Prodotti.Find(codice);
            }
        }

        public IEntityCode Update(string codice, IEntityCode item)
        {
            throw new NotImplementedException();
        }
    }
}
