using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6.AgenziaViaggiEF.Repository
{
    public interface IRepository<T>
    {
        public bool Create(T item);
        public bool Delete(int id);
        public bool Update(int id, T modifiedItem);
        public T GetById(int id);
    }
}
