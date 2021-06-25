using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6.EsercitazioneFinale.Context;
using Week6.EsercitazioneFinale.Models;

namespace Week6.EsercitazioneFinale.Repositories
{
    public class RepositoryPolicy : IRepositoryPolicy
    {
        public bool Create(InsurancePolicy policy, string code)
        {
            bool esito = false;
            using (var ctx = new InsuranceAgencyContext())
            {
                if (!String.IsNullOrEmpty(code) || policy != null)
                {
                    var customer = ctx.Customers.Find(code);
                    if(customer != null)
                    {
                        try
                        {
                            policy.Customer = customer;
                            customer.Policies.Add(policy);
                            ctx.Policies.Add(policy);
                            ctx.SaveChanges();
                            esito = true;
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    
                }
            }
            return esito;
        }

        public ICollection<InsurancePolicy> GetAll()
        {
            using(var ctx = new InsuranceAgencyContext())
            {
                return ctx.Policies.Include(p => p.Customer).ToList();
            }
        }
    }
}
