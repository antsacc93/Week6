using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6.GestioneAutomobili.Models
{
    [Table("Car")]
    public class Car
    {
        [Key]
        public String Plate { get; set; }
        [Required]
        public int NumSeats { get; set; }
        [Required]
        public String Brand { get; set; }
        [Required]
        [Column("Registration")]
        public DateTime RegistrationDate { get; set; }       
        
        public String CFPerson { get; set; } //Foreign Key
        [ForeignKey(nameof(CFPerson))]
        public Person Person { get; set; } //Navigation Property

        public override string ToString()
        {
            return $"{Plate} - {Brand} Seats: {NumSeats} - {RegistrationDate.ToShortDateString()}";
        }
    }
}
