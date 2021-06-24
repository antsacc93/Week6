using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6.SupermercatoEF.Models;

namespace Week6.SupermercatoEF.Repository
{
    public interface IRepositoryEntityCode 
    {
        public IEntityCode GetByCode(string codice);
        public IEntityCode Update(string codice, IEntityCode item);
        public bool Delete(string codice);
    }
}
