using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6.AgenziaViaggiEF.Context;
using Week6.AgenziaViaggiEF.Models;

namespace Week6.AgenziaViaggiEF.Repository
{
    public class RepositoryGitaEF : IRepositoryGita
    {
        public bool Create(Gita item)
        {
            using(var ctx = new AgenziaViaggiContext())
            {
                try
                {


                    if (item == null)
                    {
                        return false;
                    }
                    ctx.Entry<Gita>(item).State = EntityState.Added;
                    ctx.SaveChanges();
                }
                catch(SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
             }

            return true;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Gita GetById(int id)
        {
            using(var ctx = new AgenziaViaggiContext())
            {
                if(id < 0)
                {
                    return null;
                }
                return ctx.Gite.Include(p => p.Partecipanti).FirstOrDefault(i => i.ID == id);
            }
        }

        public bool Update(int id, Gita modifiedItem)
        {
            throw new NotImplementedException();
        }
    }
}
