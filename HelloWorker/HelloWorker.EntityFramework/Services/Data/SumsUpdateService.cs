using HelloWorker.Domain.Models;
using HelloWorker.Domain.Services.Data;
using System;
using System.Linq;

namespace HelloWorker.EntityFramework.Services.Data {

	public class SumsUpdateService : ISumsUpdateService {

		private readonly Func<HelloWorkerDbContext> _createDbContext;
		private readonly IWorkplaceDataService _workplaceDataService;
		private readonly IActDataService _actDataService;

		public SumsUpdateService(Func<HelloWorkerDbContext> createDbContext, 
			IWorkplaceDataService workplaceDataService, 
			IActDataService actDataService
		) {

			_createDbContext = createDbContext;
			_workplaceDataService = workplaceDataService;
			_actDataService = actDataService;
		}

		private void UpdateWorkplaceSum(Workplace workplace) {

			decimal newSum;

			using (HelloWorkerDbContext db = _createDbContext()) {

				newSum = db.WorkplaceWorks.AsNoTracking()
					.Where(ww => ww.WorkplaceId == workplace.Id && (ww.ActId == null || ww.Act.IsDeleted != true))
					.Sum(ww => ww.Cost) ?? 0;
			}

			workplace.Cost = newSum;
			workplace.MasterCost = newSum * 2;

			_workplaceDataService.Update(workplace);
		}

		private void UpdateActSum(Act act) {

			decimal newSum;

			using (HelloWorkerDbContext db = _createDbContext()) {

				newSum = db.WorkplaceWorks.AsNoTracking()
					.Where(ww => ww.Act.Id == act.Id)
					.Sum(ww => ww.Cost) ?? 0;
			}

			act.Cost = newSum;
			act.MasterCost = newSum * 2;

			_actDataService.Update(act);
		}


		public void UpdateSums(WorkplaceWork position) {

			Workplace workplace = _workplaceDataService.Get(position.WorkplaceId);
			Act act = position.ActId == null ? null : _actDataService.Get((long)position.ActId);

			UpdateWorkplaceSum(workplace);

			if (act == null)
				return;

			UpdateActSum(act);
		}
		
		public void UpdateSums(Act act) {

			Workplace workplace = _workplaceDataService.Get(act.WorkplaceId);

			UpdateWorkplaceSum(workplace);
		}
	}
}
