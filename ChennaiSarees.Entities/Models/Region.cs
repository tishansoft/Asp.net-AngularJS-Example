using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;

namespace ChennaiSarees.Entities.Models
{
    public partial class Region : Entity
    {
        public Region()
        {
            this.Territories = new List<Territory>();
        }

        public int RegionID { get; set; }
        public string RegionDescription { get; set; }
        public virtual ICollection<Territory> Territories { get; set; }
    }
}