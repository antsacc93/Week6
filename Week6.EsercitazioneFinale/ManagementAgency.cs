using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6.EsercitazioneFinale.Models;
using Week6.EsercitazioneFinale.Repositories;

namespace Week6.EsercitazioneFinale
{
    public static class ManagementAgency
    {
        private static IRepositoryCustomer repoCustomer = new RepositoryCustomer();
        private static IRepositoryPolicy repoPolicy = new RepositoryPolicy();

        internal static bool Menu()
        {
            Console.WriteLine("Benvenuto");
            Console.WriteLine("1. Inserisci un nuovo cliente");
            Console.WriteLine("2. Inserisci una polizza per un cliente");
            Console.WriteLine("3. Visualizza tutte le policy");
            Console.WriteLine("4. Esci");
            int scelta = Helper.VerificaInput(4);
            GestisciScelta(scelta);
            return scelta > 0 && scelta < 4;
        }

        private static void GestisciScelta(int scelta)
        {
            switch (scelta)
            {
                case 1:
                    AggiungiCliente();
                    break;
                case 2:
                    AggiungiPolizza();
                    break;
                case 3:
                    Helper.VisualizzaDati<InsurancePolicy>(repoPolicy.GetAll());
                    Console.WriteLine("Premi un tasto per tornare indietro");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Arrivederci");
                    break;
            }
        }

        private static void AggiungiPolizza()
        {
            Console.Clear();
            Helper.VisualizzaDati<Customer>(repoCustomer.GetAll());
            Console.WriteLine("Inserisci il codice fiscale del cliente");
            string code = Console.ReadLine();
            InsurancePolicy policyToCreate;
            Console.WriteLine("Che tipo di polizza vuoi inserire? ");
            Console.WriteLine("1. Per RC-AUTO ");
            Console.WriteLine("2. Per Furto");
            Console.WriteLine("3. Per Polizza vita");
            int tipoPolizza = Helper.VerificaInput(3);
            
            Console.WriteLine("Inserisci data di stipula (dd/mm/yyyy)");
            DateTime insuranceDate = Helper.VerificaData();
            Console.WriteLine("Inserisci massimale");
            var massimale = Helper.VerificaInput(100000);
            Console.WriteLine("Inserisci la rata mensile");
            var prezzo = Helper.VerificaInput();
            if (tipoPolizza == 1)
            {
                Console.Write("Inserisci cilindrata ");
                var displacement = Helper.VerificaInput(10000);
                Console.Write("Inserisci targa ");
                string plate = Console.ReadLine();
                policyToCreate = new CarInsurance()
                {
                    
                    InsuredAmount = massimale,
                    StipulationDate = insuranceDate,
                    Displacement = displacement,
                    MonthlyRate = prezzo,
                    Plate = plate
                };
            }
            else if (tipoPolizza == 2)
            {
                Console.WriteLine("Inserisci percentuale assiucarata");
                int percentage = Helper.VerificaInput(100);
                policyToCreate = new TheftInsurance()
                {
                    
                    InsuredAmount = massimale,
                    StipulationDate = insuranceDate,
                    Percentage = percentage,
                    MonthlyRate = prezzo
                };
            }
            else
            {
                Console.WriteLine("Inserisci l'età del cliente");
                var age = Helper.VerificaInput(110);
                policyToCreate = new LifeInsurance()
                {
                    
                    InsuredAmount = massimale,
                    StipulationDate = insuranceDate,
                    InsuredAge = age,
                    MonthlyRate = prezzo
                };
            }

            if (repoPolicy.Create(policyToCreate, code))
            {
                Console.WriteLine("Operazione completata con successo!");
            }
            else
            {
                Console.WriteLine("Ops, c'è stato qualche problema");
            };


        }

        private static void AggiungiCliente()
        {
            Console.Clear();
            Console.WriteLine("Inserisci i dati del nuovo cliente");
            Console.Write("Nome -> ");
            string nome = Console.ReadLine();
            Console.Write("Cognome -> ");
            string cognome = Console.ReadLine();
            Console.Write("Codice fiscale -> ");
            string code = Console.ReadLine();
            Console.Write("Indirizzo -> ");
            string indirizzo = Console.ReadLine();
            var customer = new Customer()
            {
                FirstName = nome,
                LastName = cognome,
                Address = indirizzo,
                TaxCode = code
            };

            if (repoCustomer.Create(customer))
            {
                Console.WriteLine("Operazione completata con successo!");
            }
            else
            {
                Console.WriteLine("Ops, c'è stato qualche problema");
            };
        }
    }
}
