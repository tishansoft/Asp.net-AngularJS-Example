using ChennaiSarees.BusinessObjects.OrderDetail;
using ChennaiSarees.BusinessObjects.Shipper;
using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ChennaiSarees.BusinessObjects.Order
{
    public class AddOrderDto
    {

        public AddOrderDto()
        {
            OrderItems = new List<AddOrderDetailDto>();
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The {0} should be greater than 0.")]
        [StringLength(5, ErrorMessage = "The {0} can not exceed {1} characters long.")]
        public string CustomerID { get; set; }

        [Min(1, ErrorMessage = "{0} should be minimum of {1}.")]
        public int EmployeeID { get; set; }
        public System.DateTime OrderDate { get; set; }
        public System.DateTime? RequiredDate { get; set; }
        public System.DateTime? ShippedDate { get; set; }

        [Min(1, ErrorMessage = "{0} should be minimum of {1}.")]
        public int ShipVia { get; set; }
        [Min(1, ErrorMessage = "{0} should be minimum of {1}.")]
        public decimal? Freight { get; set; }
        [StringLength(40, ErrorMessage = "The {0} can not exceed {1} characters long.")]
        public string ShipName { get; set; }
        [StringLength(60, ErrorMessage = "The {0} can not exceed {1} characters long.")]
        public string ShipAddress { get; set; }
        [StringLength(15, ErrorMessage = "The {0} can not exceed {1} characters long.")]
        public string ShipCity { get; set; }
        [StringLength(15, ErrorMessage = "The {0} can not exceed {1} characters long.")]
        public string ShipRegion { get; set; }
        [StringLength(10, ErrorMessage = "The {0} can not exceed {1} characters long.")]
        public string ShipPostalCode { get; set; }
        [StringLength(15, ErrorMessage = "The {0} can not exceed {1} characters long.")]
        public string ShipCountry { get; set; }

        public List<AddOrderDetailDto> OrderItems { get; private set; }

        public void AddOrderItems(AddOrderDetailDto orderItem) {
            OrderItems.Add(orderItem);
        }

        public IEnumerable<ValidationResult> Validate()
        {
            var result = new List<ValidationResult>();

            result.AddRange(Validate(new ValidationContext(this)));

            if (OrderItems != null && OrderItems.Count() > 0)
            {
                foreach (var item in OrderItems)
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
