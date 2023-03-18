namespace AdminWebFig.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class Account
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Account()
        {
            Carts = new HashSet<Cart>();
            Orders = new HashSet<Order>();
        }

        [Key]
        public int idAccount { get; set; }

        [StringLength(100)]
        public string username { get; set; }

        [StringLength(100)]
        public string password { get; set; }

        [StringLength(100)]
        public string Hoten { get; set; }

        [StringLength(50)]
        public string SoDT { get; set; }

        [StringLength(100)]
        public string Diachi { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public bool IsValid1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cart> Carts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
