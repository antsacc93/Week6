using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6.EsercitazioneFinale
{
    public static class Helper
    {
        public static int VerificaInput(int max)
        {
            bool verifica = Int32.TryParse(Console.ReadLine(), out int scelta);
            while (!verifica || scelta < 0 || scelta > max)
            {
                verifica = Int32.TryParse(Console.ReadLine(), out scelta);
            }
            return scelta;
        }

        public static void VisualizzaDati<T> (ICollection<T> data) where T : class
        {
            if(data.Count == 0)
            {
                Console.WriteLine("Non ci sono dati da visualizzare");
            }
            foreach(var item in data)
            {
                Console.WriteLine(item);
            }
            
        }
        public static float VerificaInput()
        {
            bool verifica = float.TryParse(Console.ReadLine(), out float prezzo);
            while (!verifica || prezzo < 0)
            {
                Console.WriteLine("Inserisci valore corretto");
                verifica = float.TryParse(Console.ReadLine(), out prezzo);
            }
            return prezzo;
        }

        public static DateTime VerificaData()
        {
            bool verifica = DateTime.TryParse(Console.ReadLine(), out DateTime date);
            while (!verifica)
            {
                Console.WriteLine("Inserisci valore corretto (dd/mm/yyyy)");
                verifica = DateTime.TryParse(Console.ReadLine(), out date);
            }
            return date;
        }

    }
}
