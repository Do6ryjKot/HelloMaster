using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelloWorker.Domain.Models {

    [Table("Workplace")]
    public class Workplace {

        public Workplace() {
            Acts = new HashSet<Act>();
        }

        public long Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Address { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime LastActivity { get; set; }

        public decimal? Cost { get; set; }
        public decimal? MasterCost { get; set; }

        public bool? IsDeleted { get; set; }
                
        public virtual ICollection<Act> Acts { get; set; }

        public virtual ICollection<WorkplaceWork> WorkplaceWorks { get; set; }
    }
}
