using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6.AgenziaViaggiEF.Models;
using Week6.AgenziaViaggiEF.Context;
using Microsoft.EntityFrameworkCore;

namespace Week6.AgenziaViaggiEF.Repository
{
    public class RepositoryResponsabileEF : IRepositoryResponsabile
    {
        public bool Create(Responsabile item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Responsabile GetById(int id)
        {
            using (var ctx = new AgenziaViaggiContext())
            {
                if(id < 0)
                {
                    return null;
                }
                var responsabile = ctx.Responsabili
                                      .Include(g => g.Gite)
                                      .FirstOrDefault(x => x.ID == id);
                return responsabile;
            }
        }

        public bool Update(int id, Responsabile modifiedItem)
        {
            throw new NotImplementedException();
        }
    }
}
