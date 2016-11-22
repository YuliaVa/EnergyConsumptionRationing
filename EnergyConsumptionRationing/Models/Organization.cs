namespace EnergyConsumptionRationing.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Organization")]
    public partial class Organization
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Organization()
        {
            ConsumedRelease = new HashSet<ConsumedRelease>();
            ReleaseProducts = new HashSet<ReleaseProducts>();
            StandartExpense = new HashSet<StandartExpense>();
        }

        public int OrganizationID { get; set; }

        [StringLength(30)]
        public string OrganizationName { get; set; }

        [StringLength(30)]
        public string FormOwnership { get; set; }

        [StringLength(30)]
        public string Address { get; set; }

        [StringLength(30)]
        public string NameLeader { get; set; }

        [Range(1, 10000000000, ErrorMessage = "The data is incorrect")]
        public int? PhoneLeader { get; set; }

        [StringLength(30)]
        public string NameEngineer { get; set; }

        [Range(1, 10000000000, ErrorMessage = "The data is incorrect")]
        public int? PhoneEngineer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConsumedRelease> ConsumedRelease { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReleaseProducts> ReleaseProducts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StandartExpense> StandartExpense { get; set; }
    }
}
