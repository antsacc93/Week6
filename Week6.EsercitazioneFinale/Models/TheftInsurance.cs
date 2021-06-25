using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6.EsercitazioneFinale.Models
{
    public class TheftInsurance : InsurancePolicy
    {
        public int Percentage { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.Append($"Percentuale assicurata {Percentage} \n");
            sb.Append($"Dati cliente \n {Customer} \n\n");
            return sb.ToString();
        }

    }
}
