namespace EnergyConsumptionRationing.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TypesProduction")]
    public partial class TypesProduction
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TypesProduction()
        {
            ConsumedRelease = new HashSet<ConsumedRelease>();
            ReleaseProducts = new HashSet<ReleaseProducts>();
            StandartExpense = new HashSet<StandartExpense>();
        }

        [Key]
        public int ProductionID { get; set; }

        [StringLength(30)]
        public string ProductionName { get; set; }

        [StringLength(15)]
        public string MeasureUnit { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConsumedRelease> ConsumedRelease { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReleaseProducts> ReleaseProducts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StandartExpense> StandartExpense { get; set; }
    }
}
