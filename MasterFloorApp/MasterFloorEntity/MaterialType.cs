namespace MasterFloorApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MaterialType")]
    public partial class MaterialType
    {
        public int id { get; set; }

        [StringLength(50)]
        public string typeMaterial { get; set; }

        public double? defectRate { get; set; }
    }
}
