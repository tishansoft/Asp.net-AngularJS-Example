using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChennaiSarees.BusinessObjects.Company
{
    public class InsertCustomerDto
    {
        [Key]
        [Required(ErrorMessage = "The {0} is required.")]
        [StringLength(5, ErrorMessage = "The {0} must be 5 characters long.")]
        public string CustomerID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The {0} is required.")]
        [StringLength(40, ErrorMessage = "The {0} can not exceed {1} characters long.")]
        public string CompanyName { get; set; }

        [StringLength(30, ErrorMessage = "The {0} can not exceed {1} characters long.")]
        public string ContactName { get; set; }

        [StringLength(30, ErrorMessage = "The {0} can not exceed {1} characters long.")]
        public string ContactTitle { get; set; }

        [StringLength(60, ErrorMessage = "The {0} can not exceed {1} characters long.")]
        public string Address { get; set; }

        [StringLength(15, ErrorMessage = "The {0} can not exceed {1} characters long.")]
        public string City { get; set; }

        [StringLength(15, ErrorMessage = "The {0} can not exceed {1} characters long.")]
        public string Region { get; set; }

        [StringLength(10, ErrorMessage = "The {0} can not exceed {1} characters long.")]
        public string PostalCode { get; set; }

        [StringLength(10, ErrorMessage = "The {0} can not exceed {1} characters long.")]
        public string Country { get; set; }

        [StringLength(24, ErrorMessage = "The {0} can not exceed {1} characters long.")]
        public string Phone { get; set; }

        [StringLength(24, ErrorMessage = "The {0} can not exceed {1} characters long.")]
        public string Fax { get; set; }

        public IEnumerable<ValidationResult> Validate()
        {
            return Validate(new ValidationContext(this));
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext ValidationContext)
        {
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(this, ValidationContext, results, true);

            return results;
        }
    }
}