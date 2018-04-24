namespace Dealership.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Model")]
    public partial class Model
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Model()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        public int modelID { get; set; }

        [Display(Name = "Engine Size")]
        [DisplayFormat(DataFormatString = "{0:0.0}")]
        public decimal? engineSize { get; set; }

        [Display(Name = "Number of Doors")]
        public int? doors { get; set; }

        [Display(Name = "Colour")]
        [StringLength(20)]
        public string colour { get; set; }

        [Display(Name = "Type")]
        public int vehicleTypeID { get; set; }

        public virtual Type Type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
