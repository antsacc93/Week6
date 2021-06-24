﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6.SupermercatoEF.Context;
using Week6.SupermercatoEF.Models;

namespace Week6.SupermercatoEF.Repository
{
    public class RepositoryReparto : IRepositoryReparto
    {
        public Reparto Create(Reparto item)
        {
            using (var ctx = new SupermercatoContext())
            {
                if (item != null)
                {
                    try
                    {
                        ctx.Entry<Reparto>(item).State = EntityState.Added;
                        ctx.Reparti.Add(item);
                        ctx.SaveChanges();
                    }catch(Exception ex)
                    {
                        return null;
                    }
                }
            }
            return item;
        }

        public bool Delete(int numero)
        {
            Reparto repartoToDelete = null;
            bool esito = false;
            using (var ctx = new SupermercatoContext())
            {
                if(numero > 0)
                {
                    repartoToDelete = ctx.Reparti.Find(numero);
                }
            }
            using (var ctx = new SupermercatoContext())
            {
                if(repartoToDelete != null)
                {
                    try
                    {
                        ctx.Entry<Reparto>(repartoToDelete).State = EntityState.Deleted;
                        ctx.Reparti.Remove(repartoToDelete);
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

        public ICollection<Reparto> GetAll()
        {
            using (var ctx = new SupermercatoContext())
            {
                return ctx.Reparti.ToList();
            }
        }

        public Reparto GetByNumero(int numero)
        {
            using (var ctx = new SupermercatoContext())
            {
                if (numero < 0)
                {
                    return null;
                }
                return ctx.Reparti.Find(numero);
            }
        }

        public Reparto Update(int numero, Reparto repartoToUpdate)
        {
            Reparto repartoToUpdateDb = null;
            using (var ctx = new SupermercatoContext())
            {
                if(numero != 0)
                {
                    repartoToUpdateDb = ctx.Reparti.Find(numero);
                }
            }

            using (var ctx = new SupermercatoContext())
            {
                if(repartoToUpdateDb != null && repartoToUpdate != null)
                {
                    try
                    {
                        repartoToUpdateDb.Nome = repartoToUpdate.Nome;
                        ctx.Entry<Reparto>(repartoToUpdateDb).State = EntityState.Modified;
                        ctx.Reparti.Update(repartoToUpdateDb);
                        ctx.SaveChanges();
                    }
                    catch(Exception ex)
                    {
                        return null;
                    }
                    
                }
            }
            return repartoToUpdateDb;
        }
    }
}
