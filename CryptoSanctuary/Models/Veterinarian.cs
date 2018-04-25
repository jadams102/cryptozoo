using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CryptoSanctuary.Models
{
    [Table("Veterinarians")]
    public class Veterinarian
    {
        [Key]
        public int VeterinarianId { get; set; }
        public string Name { get; set; }
        public string Specialty { get; set; }
    }
}
