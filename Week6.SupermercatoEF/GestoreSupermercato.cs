using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6.SupermercatoEF
{
    public static class GestoreSupermercato
    {
        internal static bool SchermoMenu()
        {
            Console.WriteLine("Benvenuto");
            Console.WriteLine("1. Aggiungi reparti");
            Console.WriteLine("2. Aggiungi dipendenti");
            Console.WriteLine("3. Aggiungi prodotti");
            Console.WriteLine("4. Visualizza dati");
            Console.WriteLine("0. Per uscire");
            int scelta = VerificaInput(4);
            return GestireScelta(scelta);
        }

        private static bool GestireScelta(int scelta)
        {
            bool continua = true;
            switch (scelta)
            {
                case 1:
                    //Aggiungi reparto
                    break;
                case 2:
                    //Aggiungi dipendenti
                    break;
                case 3:
                    //Aggiungi prodotti
                    break;
                case 4:
                    //Visualizza dati
                    
                    break;
                default:
                    continua = false;
                    Console.WriteLine("Arrivederci");
                    break;
            }
            return continua;
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
