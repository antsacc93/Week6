using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6.GestioneAutomobili.Models
{
    [Table("Person")]
    public class Person
    {
        [Required]
        public String FirstName { get; set; }
        [Required]
        public String LastName { get; set; }
        [Key]
        [MaxLength(16), MinLength(16)]
        public String CF { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }

        public ICollection<Car> Cars = new List<Car>();

        public override string ToString()
        {
            return $"{FirstName} - {LastName} - {DateOfBirth.ToShortDateString()}";
        }
    }
}
