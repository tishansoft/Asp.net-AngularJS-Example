using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChennaiSarees.BusinessObjects.ShoppingCart
{
    public class UpdateShoppingCartListDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "The {0} should be greater than 0.")]
        [StringLength(5, ErrorMessage = "The {0} can not exceed {1} characters long.")]
        public string CustomerID { get; set; }
        public List<UpdateShoppingCartDto> UpdateShoppingCartList { get; set; }

        public IEnumerable<ValidationResult> Validate()
        {
            var result = new List<ValidationResult>();

            result.AddRange(Validate(new ValidationContext(this)));

            if (UpdateShoppingCartList != null && UpdateShoppingCartList.Count() > 0)
            {
                foreach (var item in UpdateShoppingCartList)
                {
                    result.AddRange(item.Validate());
                }
            }
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
