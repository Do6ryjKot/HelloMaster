using HelloWorker.Domain.Models;
using HelloWorker.Domain.Services.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace HelloWorker.EntityFramework.Services.Data {

	public class ActDataService : IActDataService {

		private readonly Func<HelloWorkerDbContext> _createDbContext;

		public ActDataService(Func<HelloWorkerDbContext> createDbContext) {
			_createDbContext = createDbContext;
		}

		public IEnumerable<Act> GetByWorkplaceId(long workplaceId) {

			using (HelloWorkerDbContext db = _createDbContext()) {

				return db.Acts
					.AsNoTracking()
					.Where(a => a.Workplace.Id == workplaceId && a.IsDeleted != true)
					.ToList();
			}
		}

		public long GetLastActNum(long workplaceId) {

			using (HelloWorkerDbContext db = _createDbContext()) {

				Act act = db.Acts.AsNoTracking()
					.Where(a => a.WorkplaceId == workplaceId)
					.OrderByDescending(a => a.NumOrder)
					.FirstOrDefault();

				if (act == null)
					return 0;

				return act.NumOrder;
			}
		}

		public Act Add(Act act) {

			using (HelloWorkerDbContext db = _createDbContext()) {

				Act result = db.Acts.Add(act);
				db.SaveChanges();

				return result;
			}
		}

		public Act Update(Act act) {

			using (HelloWorkerDbContext db = _createDbContext()) {

				db.Acts.AddOrUpdate(act);
				db.SaveChanges();

				return db.Acts.Find(act.Id);
			}
		}

		public void Delete(Act act) {

			using (HelloWorkerDbContext db = _createDbContext()) {

				act.IsDeleted = true;

				db.Acts.AddOrUpdate(act);
				db.SaveChanges();
			}
		}

		public Act Get(long actId) {

			using (HelloWorkerDbContext db = _createDbContext()) {

				return db.Acts.AsNoTracking().FirstOrDefault(a => a.Id == actId);
			}
		}

		public Act GetWithPositions(long actId) {

			using (HelloWorkerDbContext db = _createDbContext()) {

				return db.Acts.Include("WorkplaceWork").AsNoTracking().FirstOrDefault(a => a.Id == actId);
			}
		}
	}
}
