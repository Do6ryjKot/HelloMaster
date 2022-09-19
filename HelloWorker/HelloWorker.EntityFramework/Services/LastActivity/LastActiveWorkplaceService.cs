using HelloWorker.Domain.Models;
using HelloWorker.Domain.Services.LastActivity;
using System;
using System.Data.Entity.Migrations;
using System.Linq;

namespace HelloWorker.EntityFramework.Services.LastActivity {

	public class LastActiveWorkplaceService : ILastActiveWorkplaceService {

		private readonly Func<HelloWorkerDbContext> _createDbContext;

		public LastActiveWorkplaceService(Func<HelloWorkerDbContext> createDbContext) {
			_createDbContext = createDbContext;
		}

		public long GetLastActiveWorkplaceId() {

			using (HelloWorkerDbContext db = _createDbContext()) {

				return db.Workplace
					.AsNoTracking()
					.Where(wp => wp.IsDeleted != true)
					.OrderByDescending(wp => wp.LastActivity)
					.First()
					.Id;
				// return db.Workplace.AsNoTracking().OrderBy(wp => wp.LastActivity).First().Id;
			}
		}

		public void UpdateLastActivity(Workplace workplace) {

			using (HelloWorkerDbContext db = _createDbContext()) {

				workplace.LastActivity = DateTime.Now;

				db.Workplace.AddOrUpdate(workplace);

				db.SaveChanges();
			}
		}
	}
}
