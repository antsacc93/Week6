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
    public class RepositoryDipendente : IRepositoryEntityCode, IRepository<Dipendente>
    {
        public Dipendente Create(Dipendente item)
        {
            using (var ctx = new SupermercatoContext())
            {
                if (item != null)
                {
                    try
                    {
                        ctx.Entry<Dipendente>(item).State = EntityState.Added;
                        //ctx.Dipendenti.Add(item);
                        ctx.SaveChanges();
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                }
            }
            return item;
        }

        public bool Delete(string codice)
        {
            Dipendente dipToDelete = null;
            bool esito = false;
            using (var ctx = new SupermercatoContext())
            {

                if (codice != null || codice.Length != 0)
                {
                    dipToDelete = ctx.Dipendenti.Find(codice);
                }
            }
            using (var ctx = new SupermercatoContext())
            {
                if (dipToDelete != null)
                {
                    try
                    {
                        ctx.Entry<Dipendente>(dipToDelete).State = EntityState.Deleted;
                        //ctx.Dipendenti.Remove(dipToDelete);
                        ctx.SaveChanges();
                        esito = true;
                    }
                    catch(Exception ex)
                    {
                        return esito;
                    }
                }
            }
            return esito;
        }

        public ICollection<Dipendente> GetAll()
        {
            using (var ctx = new SupermercatoContext())
            {
                return ctx.Dipendenti.ToList();
            }
        }

        public IEntityCode GetByCode(string codice)
        {
            using (var ctx = new SupermercatoContext())
            {
                return ctx.Dipendenti.Find(codice);
            }
        }

        public IEntityCode Update(string codice, IEntityCode item)
        {
            throw new NotImplementedException();
        }
    }
}
