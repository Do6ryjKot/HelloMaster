using HelloWorker.Domain.Models;
using HelloWorker.Domain.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HelloWorker.EntityFramework.Services.Data {

	public class WorkCategoryDataService : IWorkCategoryDataService {

		private readonly Func<HelloWorkerDbContext> _createDbContext;

		public WorkCategoryDataService(Func<HelloWorkerDbContext> createDbContext) {
			_createDbContext = createDbContext;
		}

		public IEnumerable<WorkCategory> GetAll() {

			using (HelloWorkerDbContext db = _createDbContext()) {

				return db.WorkCategories.ToList();
			}
		}
	}
}
