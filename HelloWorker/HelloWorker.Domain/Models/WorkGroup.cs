using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelloWorker.Domain.Models {
    
    [Table("WorkGroup")]
    public class WorkGroup {

        public WorkGroup() {

            Work = new HashSet<Work>();
        }

        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Work> Work { get; set; }
    }
}
