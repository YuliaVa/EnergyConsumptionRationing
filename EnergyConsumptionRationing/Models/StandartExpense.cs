namespace EnergyConsumptionRationing.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StandartExpense")]
    public partial class StandartExpense
    {
        [Key]
        public int ExpenseID { get; set; }

        [Range(1, 10000000000, ErrorMessage = "The data is incorrect")]
        public int? QuarterlyNormEnergyUnit { get; set; }

        public int? ProductionID { get; set; }

        [Range(1800,2016,ErrorMessage ="The data is incorrect")]
        public int? Year { get; set; }

        [Range(1, 4, ErrorMessage = "The data is incorrect")]
        public int? Quarter { get; set; }

        public int? OrganizationID { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual TypesProduction TypesProduction { get; set; }
    }
}
