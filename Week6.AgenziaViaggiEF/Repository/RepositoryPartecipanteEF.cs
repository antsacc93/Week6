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
    public class RepositoryPartecipanteEF : IRepositoryPartecipante
    {
        public bool Create(Partecipante item)
        {
            //bool esito = false;
            using (var ctx = new AgenziaViaggiContext())
            {
                try
                {
                    if(item == null)
                    {
                        //return esito;
                        return false;
                    }
                    ctx.Entry<Partecipante>(item).State = EntityState.Added;
                    ctx.SaveChanges();
                    //esito = true;
                }
                catch(SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    //return esito;
                    return false;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    //return esito;
                    return false;
                }                
            }
            //return esito;
            return true;
        }

        public bool Delete(int id)
        {
            Partecipante partToDelete;
            //Ricerco il record da cancellare
            try
            {
                using (var ctx = new AgenziaViaggiContext())
                {
                    if (id < 0)
                    {
                        return false;
                    }
                    partToDelete = ctx.Partecipanti.Find(id);
                }
                //Cancellazione effettiva
                using (var ctx = new AgenziaViaggiContext())
                {
                    if (partToDelete == null)
                    {
                        return false;
                    }
                    ctx.Entry<Partecipante>(partToDelete).State = EntityState.Deleted;
                    ctx.SaveChanges();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        public bool Update(int id, Partecipante modifiedItem)
        {
            Partecipante partToUpdate;
            try
            {
                using (var ctx = new AgenziaViaggiContext())
                {
                    if (id < 0)
                    {
                        return false;
                    }
                    partToUpdate = ctx.Partecipanti.Find(id);
                }

                using (var ctx = new AgenziaViaggiContext())
                {
                    if (modifiedItem == null || partToUpdate == null)
                    {
                        return false;
                    }
                    partToUpdate.Nome = modifiedItem.Nome;
                    partToUpdate.Cognome = modifiedItem.Cognome;
                    partToUpdate.DataNascita = modifiedItem.DataNascita;
                    partToUpdate.Citta = modifiedItem.Citta;
                    partToUpdate.Indirizzo = modifiedItem.Indirizzo;

                    ctx.Entry<Partecipante>(partToUpdate).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
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
            return true;
        }
    }
}
