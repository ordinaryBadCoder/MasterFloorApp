namespace MasterFloorApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            PartnerProduct = new HashSet<PartnerProduct>();
        }

        public int id { get; set; }

        public int? idTypeProduct { get; set; }

        [StringLength(255)]
        public string nameProduct { get; set; }

        [StringLength(20)]
        public string articleNumber { get; set; }

        public double? minCost { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartnerProduct> PartnerProduct { get; set; }

        public virtual ProductType ProductType { get; set; }
    }
}
