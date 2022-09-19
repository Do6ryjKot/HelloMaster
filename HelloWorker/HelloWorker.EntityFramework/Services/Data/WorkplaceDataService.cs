using HelloWorker.Domain.Models;
using HelloWorker.Domain.Services.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace HelloWorker.EntityFramework.Services.Data {

	public class WorkplaceDataService : IWorkplaceDataService {

		private readonly Func<HelloWorkerDbContext> _createDbContext;

		public WorkplaceDataService(Func<HelloWorkerDbContext> createDbContext) {
			_createDbContext = createDbContext;
		}		

		public IEnumerable<Workplace> GetAll() {
			
			using (HelloWorkerDbContext db = _createDbContext()) {

				return db.Workplace
					.AsNoTracking()
					.Where(wp => wp.IsDeleted != true)
					.OrderByDescending(wp => wp.LastActivity)
					.ToList();
			}
		}

		public Workplace GetWithPositions(long id) {
			
			using (HelloWorkerDbContext db = _createDbContext()) {

				return db.Workplace
					.Include("WorkplaceWorks")
					.Include("WorkplaceWorks.Work")
					.Include("WorkplaceWorks.Work.WorkGroup")
					.AsNoTracking()
					.FirstOrDefault(wp => wp.Id == id);
			}
		}

		public Workplace Get(long id) {

			using (HelloWorkerDbContext db = _createDbContext()) {

				return db.Workplace
					// .Include("Acts")
					.AsNoTracking()
					.FirstOrDefault(wp => wp.Id == id);
			}
		}

		public Workplace GetWithActs(long id) {

			using (HelloWorkerDbContext db = _createDbContext()) {

				return db.Workplace
					.Include("Acts")
					.AsNoTracking()
					.FirstOrDefault(wp => wp.Id == id);
			}
		}

		public Workplace Add(Workplace workplace) {

			using (HelloWorkerDbContext db = _createDbContext()) {

				Workplace result = db.Workplace.Add(workplace);
				db.SaveChanges();

				return result;
			}
		}

		public Workplace Update(Workplace workplace) {

			using (HelloWorkerDbContext db = _createDbContext()) {

				db.Workplace.AddOrUpdate(workplace);
				db.SaveChanges();

				return db.Workplace.Find(workplace.Id);
			}
		}

		public long GetCount() {

			using (HelloWorkerDbContext db = _createDbContext()) {

				return db.Workplace.Where(wp => wp.IsDeleted != true).Count();
			}
		}

		public void Delete(Workplace workplace) {

			using (HelloWorkerDbContext db = _createDbContext()) {

				workplace.IsDeleted = true;

				db.Workplace.AddOrUpdate(workplace);
				db.SaveChanges();
			}
		}		
	}
}
