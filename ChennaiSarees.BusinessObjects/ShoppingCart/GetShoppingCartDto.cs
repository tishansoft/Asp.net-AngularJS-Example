using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChennaiSarees.BusinessObjects.ShoppingCart
{
    public class GetShoppingCartDto
    {
        [StringLength(5, ErrorMessage = "{0} should be minimum of {1}.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "The {0} should be greater than 0.")]
        public string CustomerID { get; set; }

        public IEnumerable<ValidationResult> Validate()
        {
            var result = new List<ValidationResult>();
            result.AddRange(Validate(new ValidationContext(this)));
            return result;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext ValidationContext)
        {
            var result = new List<ValidationResult>();
            Validator.TryValidateObject(this, ValidationContext, result, true);
            return result;
        }
    }
}
