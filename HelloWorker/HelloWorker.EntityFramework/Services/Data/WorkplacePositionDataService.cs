using HelloWorker.Domain.Models;
using HelloWorker.Domain.Services.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace HelloWorker.EntityFramework.Services.Data {

	public class WorkplacePositionDataService : IWorkplacePositionDataService {

		private readonly Func<HelloWorkerDbContext> _createDbContext;

		public WorkplacePositionDataService(Func<HelloWorkerDbContext> createDbContext) {
			_createDbContext = createDbContext;
		}

		public WorkplaceWork Add(WorkplaceWork workplaceWork) {

			using (HelloWorkerDbContext db = _createDbContext()) {

				WorkplaceWork result = db.WorkplaceWorks.Add(workplaceWork);
				db.SaveChanges();

				return db.WorkplaceWorks
					.Include("Work")
					.Include("Work.WorkGroup")
					.AsNoTracking()
					.First(ww => ww.Id == result.Id);
			}
		}

		public WorkplaceWork Update(WorkplaceWork workplaceWork) {

			using (HelloWorkerDbContext db = _createDbContext()) {

				db.WorkplaceWorks.AddOrUpdate(workplaceWork);
				// db.Entry(workplaceWork).State = EntityState.Modified;

				db.SaveChanges();

				return db.WorkplaceWorks
					.Include("Work")
					.Include("Work.WorkGroup")
					.AsNoTracking()
					.First(ww => ww.Id == workplaceWork.Id);
			}
		}

		public void Delete(WorkplaceWork workplaceWork) {

			using (HelloWorkerDbContext db = _createDbContext()) {

				WorkplaceWork obj = db.WorkplaceWorks.Find(workplaceWork.Id);
				
				db.WorkplaceWorks.Remove(obj);
				db.SaveChanges();
			}
		}

		public IEnumerable<WorkplaceWork> GetFromAct(long actId) {

			using (HelloWorkerDbContext db = _createDbContext()) {

				return db.WorkplaceWorks
					.Include("Work")
					.Include("Work.WorkGroup")
					.AsNoTracking()
					.Where(ww => ww.ActId == actId)
					.OrderBy(ww => ww.Work.SortOrder)
					.ToList();
			}
		}

		public IEnumerable<WorkplaceWork> GetFromWorkplace(long workplaceId) {

			using (HelloWorkerDbContext db = _createDbContext()) {
				/*
				return db.WorkplaceWorks
					.Include("Work")
					.Include("Work.WorkGroup")
					.AsNoTracking()
					.Where(ww => ww.WorkplaceId == workplaceId)
					.ToList();
				*/
				
				return (from workplaceWork in db.WorkplaceWorks
						join act in db.Acts on workplaceWork.ActId equals act.Id into result
						from act in result.DefaultIfEmpty()
						where workplaceWork.WorkplaceId == workplaceId && act.IsDeleted != true
						select workplaceWork)
					   .Include("Work")
					   .Include("Work.WorkGroup")
					   .AsNoTracking()
					   .OrderBy(ww => ww.Work.SortOrder)					   
					   .ToList();
			}
		}
	}
}
