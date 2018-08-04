using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Gtf.Entity
{
    [Table("Period")]
    public partial class Period
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Period()
        {
            Meal = new HashSet<Meal>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Meal> Meal { get; set; }

        public static implicit operator DbSet<object>(Period v)
        {
            throw new NotImplementedException();
        }
    }
}
