namespace web.Models
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
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        public int Product_ID { get; set; }

        [StringLength(50)]
        public string Product_name { get; set; }

        public int? Product_price { get; set; }

        [StringLength(50)]
        public string Product_Type { get; set; }

        [StringLength(50)]
        public string Product_images { get; set; }

        public int? CatelogyID { get; set; }

        public int? Product_priceD { get; set; }

        public virtual Catelogy Catelogy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
