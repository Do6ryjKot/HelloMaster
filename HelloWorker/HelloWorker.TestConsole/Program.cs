using HelloWorker.Domain.Models;
using HelloWorker.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorker.TestConsole {
	class Program {
		static void Main(string[] args) {

			HelloWorkerDbContext db = new HelloWorkerDbContext();

			IEnumerable<WorkGroup> groups = db.WorkGroup.ToList();

			foreach (WorkGroup group in groups)
				Console.WriteLine(String.Join(" - ", group.Id, group.Name));

			Console.ReadLine();
		}
	}
}
