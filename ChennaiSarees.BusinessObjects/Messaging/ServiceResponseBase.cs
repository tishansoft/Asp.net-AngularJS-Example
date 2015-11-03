using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChennaiSarees.BusinessObjects.Messaging
{
    public abstract class ServiceResponseBase
    {
        public ServiceResponseBase()
        {
            this.ValidationResults = new List<ValidationResult>();
        }

        /// <summary>
        /// Save the exception thrown so that consumers can read it
        /// </summary>
        public List<ValidationResult> ValidationResults { get; set; }
    }
}
