using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelloWorker.Domain.Models {
	
	[Table("Act")]
	public class Act {

		public long Id { get; set; }
		public long NumOrder { get; set; }

		[Required]
		[StringLength(255)]
		public string Name { get; set; }
		public DateTime CreationDate { get; set; }
		public long WorkplaceId { get; set; }
		public bool? IsDeleted { get; set; }

		public decimal? Cost { get; set; }
		public decimal? MasterCost { get; set; }

		public virtual Workplace Workplace { get; set; }

		public virtual ICollection<WorkplaceWork> WorkplaceWorks { get; set; }

		public Act() {
			WorkplaceWorks = new HashSet<WorkplaceWork>();
		}
	}
}
