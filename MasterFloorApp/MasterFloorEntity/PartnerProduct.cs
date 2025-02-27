namespace MasterFloorApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PartnerProduct")]
    public partial class PartnerProduct
    {
        public int id { get; set; }

        public int? idProduct { get; set; }

        public int? idPartner { get; set; }

        public int? quantity { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateSale { get; set; }

        public virtual Partners Partners { get; set; }

        public virtual Product Product { get; set; }
    }
}
