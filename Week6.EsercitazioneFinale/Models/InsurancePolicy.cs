using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6.EsercitazioneFinale.Models
{
    public abstract class InsurancePolicy
    {
        public int Number { get; set; }
        public DateTime StipulationDate { get; set; }
        public float InsuredAmount { get; set; }
        public float MonthlyRate { get; set; }

        public string CustomerCode { get; set; }
        public Customer Customer { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Numero: {Number} - Data: {StipulationDate.ToShortDateString()} " +
                $"- Massimale: {InsuredAmount} - Rata: {MonthlyRate}");
            return sb.ToString();
        }
    }
}
