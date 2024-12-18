using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoManagementDataAccess.Entity.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string CityName { get; set; }

        // Use Range instead of MaxLength for integer values
        [Required]
        [Range(100000, 9999999, ErrorMessage = "Pincode must be between 100000 and 9999999.")]
        public int Pincode { get; set; }

        [Required]
        [StringLength(50)]
        public string Country { get; set; }
    }
}
