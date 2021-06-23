using System;
using Week6.AgenziaViaggiEF.Context;
using Week6.AgenziaViaggiEF.Models;
using Week6.AgenziaViaggiEF.Repository;

namespace Week6.AgenziaViaggiEF
{
    class Program
    {
        private static IRepositoryPartecipante repoPartecipante = new RepositoryPartecipanteEF();
        private static IRepositoryResponsabile repoResponsabile = new RepositoryResponsabileEF();
        private static IRepositoryItinerario repoItinerario = new RepositoryItinerarioEF();
        private static IRepositoryGita repoGita = new RepositoryGitaEF();

        //PRIMO STEP: AGGIUNTA MIGRATION
        //Add-Migration InitialMigration
        //SECONDO STEP: AGGIORNAMENTO DEL DATABASE (SE NON ESISTE LO CREA)
        //Update-Database
        //RIPETERE LE OPERAZIONI PER AGGIUNGERE NUOVE MIGRATION

        static void Main(string[] args)
        {
            //Ricerco il responsabile
            //var responsabile = repoResponsabile.GetById(1);
            //var itinerario = repoItinerario.GetById(1);
            ////Creazione nuova gita
            //Gita gita = new Gita()
            //{
            //    DataPartenza = new DateTime(2023, 4, 3),
            //};
            //responsabile.Gite.Add(gita);
            //itinerario.Gite.Add(gita);
            //gita.Responsabile = responsabile;
            //gita.Itinerario = itinerario;
            //repoGita.Create(gita);

            var gita = repoGita.GetById(1);
            var partecipante = repoPartecipante.GetById(1);
            repoPartecipante.AdesioneGita(gita, partecipante);
        }
    }
}
