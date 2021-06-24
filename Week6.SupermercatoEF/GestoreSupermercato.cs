using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6.SupermercatoEF.Models;
using Week6.SupermercatoEF.Repository;

namespace Week6.SupermercatoEF
{
    public static class GestoreSupermercato
    {

        static IRepository<Dipendente> repoDipendente = new RepositoryDipendente();
        static IRepository<Prodotto> repoProdotto = new RepositoryProdotto();
        static IRepositoryReparto repoReparto = new RepositoryReparto();
        static IRepositoryVendita repoVendita = new RepositoryVendita();

        internal static bool SchermoMenu()
        {
            Console.WriteLine("Benvenuto");
            Console.WriteLine("1. Aggiungi reparti");
            Console.WriteLine("2. Aggiungi dipendenti");
            Console.WriteLine("3. Aggiungi prodotti");
            Console.WriteLine("4. Visualizza dati");
            Console.WriteLine("5. Per uscire");
            int scelta = VerificaInput(5);
            Console.Clear();
            return GestireScelta(scelta);
        }

        private static bool GestireScelta(int scelta)
        {
            bool continua = true;
            switch (scelta)
            {
                case 1:
                    AggiungiReparto();
                    break;
                case 2:
                    AggiungiDipendente();
                    break;
                case 3:
                    AggiungiProdotti();
                    break;
                case 4:
                    Stampa();
                    break;
                default:
                    continua = false;
                    Console.WriteLine("Arrivederci");
                    break;
            }
            return continua;
        }

        private static void Stampa()
        {
            Console.WriteLine("Quale entità vuoi stampare?");
            Console.WriteLine("1. Reparti - 2. Dipendenti - 3. Prodotti");
            int scelta = VerificaInput(3);
            if(scelta == 1)
            {
                var reparti = repoReparto.GetAll();
                Helper.StampaCollection<Reparto>(reparti);
            } else if(scelta == 2)
            {
                var dipendenti = repoDipendente.GetAll();
                Helper.StampaCollection<Dipendente>(dipendenti);
            } else
            {
                Helper.StampaCollection<Prodotto>(repoProdotto.GetAll());
            }
        }

        private static void AggiungiProdotti()
        {
            Prodotto prodottoDaAggiungere;
            Console.WriteLine("Che tipo di prodotto vuoi inserire?");
            int tipoProdotto = VerificaInput(3);
            Console.WriteLine("Inserisci il codice");
            string codice = Console.ReadLine();
            Console.WriteLine("Inserisci descrizione");
            string descrizione = Console.ReadLine();
            Console.WriteLine("Inserisci il prezzo");    
            var prezzo = VerificaInput();
            if(tipoProdotto == 2)
            {
                Console.WriteLine("Inserisci data scadenza");
                DateTime scadenza = VerificaData();
                prodottoDaAggiungere = new ProdottoAlimentare()
                {
                    Codice = codice,
                    Descrizione = descrizione,
                    Prezzo = prezzo,
                    DataScadenza = scadenza,
                };
            } else if(tipoProdotto == 3)
            {
                Console.WriteLine("Inserisci marchio");
                string marchio = Console.ReadLine();
                prodottoDaAggiungere = new ProdottoCasalingo()
                {
                    Codice = codice,
                    Descrizione = descrizione,
                    Prezzo = prezzo,
                    Marchio = marchio
                };
            } else
            {
                prodottoDaAggiungere = new Prodotto()
                {
                    Codice = codice,
                    Descrizione = descrizione,
                    Prezzo = prezzo
                };
            }
            var numeroReparto = ScegliNumeroReparto();
            if(numeroReparto > 0)
            {
                repoReparto.AggiungiProdotto(numeroReparto, prodottoDaAggiungere);
            }
            
        }

        private static decimal VerificaInput()
        {
            bool verifica = Decimal.TryParse(Console.ReadLine(), out decimal prezzo);
            while(!verifica || prezzo < 0)
            {
                verifica = Decimal.TryParse(Console.ReadLine(), out prezzo);
            }
            return prezzo;
        }

        private static int ScegliNumeroReparto()
        {
            var reparti = repoReparto.GetAll();
            int numeroReparto;
            if (reparti.Count == 0)
            {
                Console.WriteLine("Non ci sono reparti");
                numeroReparto = -1;
            }
            else
            {
                Helper.StampaCollection(reparti);
                var numMax = reparti.Max(r => r.NumeroReparto);
                numeroReparto = VerificaInput(numMax);
            }
            return numeroReparto;
        }

        private static void AggiungiDipendente()
        {
            Console.Write("Codice dipendente: ");
            string codice = Console.ReadLine();
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Cognome: ");
            string cognome = Console.ReadLine();
            Console.Write("Data di nascita (dd/mm/yyyy)");
            DateTime dataNascita = VerificaData();
            var reparti = repoReparto.GetAll();
            Dipendente dipendente = new Dipendente()
            {
                Codice = codice,
                Nome = nome,
                Cognome = cognome,
                DataNascita = dataNascita,
            };
            int numeroReparto = ScegliNumeroReparto();
            if(numeroReparto > 0)
            {
                repoReparto.AggiungiDipendente(numeroReparto, dipendente);
            }
        }

        private static DateTime VerificaData()
        {
            bool verifica = DateTime.TryParse(Console.ReadLine(), out DateTime dataNascita);
            while (!verifica)
            {
                verifica = DateTime.TryParse(Console.ReadLine(), out dataNascita);
            }
            return dataNascita;
        }

        private static void AggiungiReparto()
        {
            Console.WriteLine("Inserire nome reparto");
            string nomeReparto = Console.ReadLine();

            var repartoCreato = repoReparto.Create(new Reparto()
            {
                Nome = nomeReparto
            });

            if(repartoCreato != null)
            {
                Console.WriteLine(repartoCreato);
            } else
            {
                Console.WriteLine("Operazione non riuscita");
            }
        }

        public static int VerificaInput(int sceltaMax)
        {
            Console.Write("Scelta ->");
            bool verifica = Int32.TryParse(Console.ReadLine(), out int scelta);
            while (scelta > sceltaMax || scelta < 0 || verifica == false)
            {
                Console.WriteLine("Inserisci un valore corretto");
                verifica = Int32.TryParse(Console.ReadLine(), out scelta);
            }
            return scelta;
        }
    }
}
