using HelloWorker.Domain.Models;
using HelloWorker.Domain.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HelloWorker.EntityFramework.Services.Data {

	public class WorkGroupDataService : IWorkGroupDataService {

		private readonly Func<HelloWorkerDbContext> _createDbContext;

		public WorkGroupDataService(Func<HelloWorkerDbContext> createDbContext) {
			_createDbContext = createDbContext;
		}

		public IEnumerable<WorkGroup> GetAll() {
			
			using (HelloWorkerDbContext db = _createDbContext()) {

				return db.WorkGroup.AsNoTracking().ToList();
			}
		}
	}
}
