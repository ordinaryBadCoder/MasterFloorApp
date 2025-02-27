namespace MasterFloorApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Partners
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Partners()
        {
            PartnerProduct = new HashSet<PartnerProduct>();
        }

        public int id { get; set; }

        public int? idPartnerType { get; set; }

        [StringLength(50)]
        public string namePartner { get; set; }

        [StringLength(255)]
        public string directorName { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        [StringLength(100)]
        public string phone { get; set; }

        [StringLength(255)]
        public string address { get; set; }

        [StringLength(20)]
        public string inn { get; set; }

        public int? rate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartnerProduct> PartnerProduct { get; set; }

        public virtual PartnerType PartnerType { get; set; }
    }
}
