using HelloWorker.Domain.Models;
using HelloWorker.Domain.Services.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace HelloWorker.EntityFramework.Services.Data {

	public class WorkDataService : IWorkDataService {

		private readonly Func<HelloWorkerDbContext> _createDbContext;

		public WorkDataService(Func<HelloWorkerDbContext> createDbContext) {
			_createDbContext = createDbContext;
		}

		public string SearchFilter { get; set; } = null;
		public WorkGroup WorkGroupFilter { get; set; } = null;
		public WorkCategory WorkCategoryFilter { get; set; } = null;

		public IEnumerable<Work> GetAll() {

			using (HelloWorkerDbContext db = _createDbContext()) {

				IQueryable<Work> query = db.Set<Work>().Include("WorkGroup").AsNoTracking();

				if (!string.IsNullOrEmpty(SearchFilter))
					query = query.Where(w => DbFunctions.Like(w.Name, "%" + SearchFilter + "%"));

				if (WorkGroupFilter != null && WorkGroupFilter.Id != -1)
					query = query.Where(w => w.WorkGroupId == WorkGroupFilter.Id);
				
				if (WorkCategoryFilter != null && WorkCategoryFilter.Id != -1)
					query = query.Where(w => w.WorkCategoryId == WorkCategoryFilter.Id);

				return query.ToList();
			}
		}
	}
}
