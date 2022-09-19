
using System.ComponentModel.DataAnnotations.Schema;

namespace HelloWorker.Domain.Models {

    [Table("WorkplaceWorks")]
    public class WorkplaceWork {

        public long Id { get; set; }

        public long WorkId { get; set; }

        public long? ActId { get; set; }
        public long WorkplaceId { get; set; }

        public decimal? Quadrature { get; set; }

        public decimal? Cost { get; set; }

        public decimal? MasterCost { get; set; }

        public virtual Work Work { get; set; }
        public virtual Act Act { get; set; }
        public virtual Workplace Workplace { get; set; }
    }
}
