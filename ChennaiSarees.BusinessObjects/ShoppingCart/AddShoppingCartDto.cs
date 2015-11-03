using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using DataAnnotationsExtensions;

namespace ChennaiSarees.BusinessObjects.ShoppingCart
{
    public class AddShoppingCartDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "The {0} should be greater than 0.")]
        [StringLength(5, ErrorMessage = "The {0} can not exceed {1} characters long.")]
        public string CustomerID { get; set; }

        [Min(1, ErrorMessage = "{0} should be minimum of {1}.")]
        public int EmployeeID { get; set; }
        public System.DateTime OrderDate { get; set; }

        public int ProductID { get; set; }
        public int Quantity { get; set; }

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
