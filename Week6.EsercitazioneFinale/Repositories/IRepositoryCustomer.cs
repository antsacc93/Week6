using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6.EsercitazioneFinale.Models;

namespace Week6.EsercitazioneFinale.Repositories
{
    public interface IRepositoryCustomer : IRepository<Customer>
    {
        public bool Create(Customer customer);
    }
}
