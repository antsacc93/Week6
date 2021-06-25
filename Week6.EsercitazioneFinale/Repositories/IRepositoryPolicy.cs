using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6.EsercitazioneFinale.Models;

namespace Week6.EsercitazioneFinale.Repositories
{
    public interface IRepositoryPolicy : IRepository<InsurancePolicy>
    {
        public bool Create(InsurancePolicy policy, string code);
    }
}
