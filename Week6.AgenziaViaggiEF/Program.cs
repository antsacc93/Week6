using System;
using Week6.AgenziaViaggiEF.Context;
using Week6.AgenziaViaggiEF.Models;
using Week6.AgenziaViaggiEF.Repository;

namespace Week6.AgenziaViaggiEF
{
    class Program
    {
        private static IRepositoryPartecipante repoPartecipante = new RepositoryPartecipanteEF();

        static void Main(string[] args)
        {
            Partecipante nuovoPartecipante = new Partecipante()
            {
                //ID = 3,
                Nome = "Federica",
                Cognome = "Pellegrini",
                Citta = "Firenze",
                Indirizzo = "Via Roma 7",
                DataNascita = new DateTime(1988, 4, 5)
            };

            repoPartecipante.Create(nuovoPartecipante);
            nuovoPartecipante.Cognome = "Pellegri";
            repoPartecipante.Update(3, nuovoPartecipante);
        }
    }
}
