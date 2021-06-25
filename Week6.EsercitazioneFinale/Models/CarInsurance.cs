using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6.EsercitazioneFinale.Models
{
    public class CarInsurance : InsurancePolicy
    {
        [MinLength(5), MaxLength(5)]
        public string Plate { get; set; }
        public int Displacement { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{base.ToString()} \n");
            sb.Append($"Targa: {Plate} - Cilindrata: {Displacement} \n");
            sb.Append($"Cliente: \n");
            sb.Append($"{Customer} \n\n");
            return sb.ToString();
        }
    }
}
