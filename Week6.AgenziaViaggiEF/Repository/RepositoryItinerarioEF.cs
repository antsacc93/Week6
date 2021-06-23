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
    public class RepositoryItinerarioEF : IRepositoryItinerario
    {
        public bool Create(Itinerario item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Itinerario GetById(int id)
        {
            using (var ctx = new AgenziaViaggiContext())
            {
                if(id < 0)
                {
                    return null;
                }

                var itinerario = ctx.Itinerari.Include(g => g.Gite)
                                              .FirstOrDefault(i => i.ID == id);
                return itinerario;
            }
        }

        public bool Update(int id, Itinerario modifiedItem)
        {
            throw new NotImplementedException();
        }
    }
}
