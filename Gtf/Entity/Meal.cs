using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gtf.Entity
{
    [Table("Meal")]
    public partial class Meal
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        public int TypeId { get; set; }

        public int PeriodId { get; set; }

        public virtual Period Period { get; set; }

        public virtual Type Type { get; set; }
    }
}
