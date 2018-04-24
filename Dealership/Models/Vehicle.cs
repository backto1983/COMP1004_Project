namespace Dealership.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Vehicle")]
    public partial class Vehicle
    {
        public int vehicleID { get; set; }

        public int makeID { get; set; }

        public int modelID { get; set; }

        [Display(Name ="Year")]
        public int? year { get; set; }

        [Display(Name = "Price")]
        [Column(TypeName = "numeric")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        [Range(1000.00, 1000000.00)]
        public decimal price { get; set; }

        [Display(Name = "Cost")]
        [Column(TypeName = "numeric")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        [Range(1000.00, 1000000.00)]
        public decimal cost { get; set; }

        [Display(Name = "Sold Date")]
        [Column(TypeName = "date")]
        public DateTime? soldDate { get; set; }

        public virtual Make Make { get; set; }

        public virtual Model Model { get; set; }
    }
}
