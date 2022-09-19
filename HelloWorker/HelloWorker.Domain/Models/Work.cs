using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelloWorker.Domain.Models {

	[Table("Work")]
    public class Work {
        
        public Work() {
            WorkplaceWorks = new HashSet<WorkplaceWork>();
        }

        public long Id { get; set; }
        public long SortOrder { get; set; }

        public long WorkGroupId { get; set; }
        public long WorkCategoryId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(15)]
        public string MeasureUnit { get; set; }

        public decimal Price { get; set; }
        public decimal PriceWinter { get; set; }

        public virtual WorkGroup WorkGroup { get; set; }

        public virtual WorkCategory WorkCategory { get; set; }

        public virtual ICollection<WorkplaceWork> WorkplaceWorks { get; set; }
    }
}
