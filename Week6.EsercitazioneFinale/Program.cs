using System;

namespace Week6.EsercitazioneFinale
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continua = true;
            while (continua)
            {
                continua = ManagementAgency.Menu();
            }
        }
    }
}
