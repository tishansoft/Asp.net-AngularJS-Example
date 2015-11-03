using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChennaiSarees.BusinessObjects.ShoppingCart
{
    public class UpdateShoppingCartDto
    {
        [Min(1, ErrorMessage = "{0} should be minimum of {1}.")]
        public int ShoppingCartId { get; set; }
        [Min(1, ErrorMessage = "{0} should be minimum of {1}.")]
        public int Quantity { get; set; }

        public IEnumerable<ValidationResult> Validate()
        {
            return Validate(new ValidationContext(this));
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext ValidationContext)
        {
            var result = new List<ValidationResult>();
            Validator.TryValidateObject(this, ValidationContext, result, true);
            return result;
        }
    }
}
