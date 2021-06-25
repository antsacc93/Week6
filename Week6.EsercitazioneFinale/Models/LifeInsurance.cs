using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6.EsercitazioneFinale.Models
{
    public class LifeInsurance : InsurancePolicy
    {
        public int InsuredAge { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.Append($"Età Assicurato {InsuredAge} \n");
            sb.Append($"Dati cliente \n {Customer} \n\n");
            return sb.ToString();
        }
    }
}
