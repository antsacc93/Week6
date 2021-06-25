using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6.EsercitazioneFinale.Context;
using Week6.EsercitazioneFinale.Models;

namespace Week6.EsercitazioneFinale.Repositories
{
    public class RepositoryCustomer : IRepositoryCustomer
    {
        public bool Create(Customer customer)
        {
            bool esito = false;
            using (var ctx = new InsuranceAgencyContext())
            {
                if (customer != null)
                {
                    try
                    {
                        ctx.Customers.Add(customer);
                        ctx.SaveChanges();
                        esito = true;
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex);
                    }

                }
            }
            return esito;
        }

        public ICollection<Customer> GetAll()
        {
            using (var ctx = new InsuranceAgencyContext())
            {
                return ctx.Customers.ToList();
            }
        }
    }
}
