using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quillia.Models
{
    public class Company
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        [StringLength(100, ErrorMessage = "The Name field cannot exceed 100 characters.")]
        public string Name { get; set; }
        [Required]
        [StringLength(200, ErrorMessage = "The Street Address field cannot exceed 200 characters.")]
        public string? StreetAddress { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The City field cannot exceed 50 characters.")]
        public string? City { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The State field cannot exceed 50 characters.")]
        public string? State { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "The Postal Code field cannot exceed 20 characters.")]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "The Postal Code is not valid. It should be in the format 12345 or 12345-6789.")]
        public string? PostalCode { get; set; }
        [Required]
        [Phone(ErrorMessage = "The Phone Number is not valid.")]
        [StringLength(15, ErrorMessage = "The Phone Number field cannot exceed 15 characters.")]
        public string? PhoneNumber { get; set; }
    }
}