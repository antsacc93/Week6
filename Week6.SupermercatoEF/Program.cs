using System;

namespace Week6.SupermercatoEF
{
    //CREO IL MODELLO E-R 
    //CREO IL MODELLO CON LE CLASSI
    //CREO IL CONTEXT 
    //ADATTO IL MODELLO AL DB DI ENTITY FRAMEWORK CON DATA ANNOTATION 
    //FLUENT API
    //CREO IL DATABASE (CON MIGRATION)
    //--
    // Add-Migration "NomeMigration"
    // Update-Database
    //--
    //CREO IL REPOSITORY --  
    //CREO L'INTERFACCIA CON L'UTENTE
    class Program
    {
        static void Main(string[] args)
        {
            bool continua = true;
            while (continua)
            {
                continua = GestoreSupermercato.SchermoMenu();
            }
        }
    }
}
