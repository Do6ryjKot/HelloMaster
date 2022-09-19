using HelloWorker.Domain.Models;
using System.Data.Entity;

namespace HelloWorker.EntityFramework {

	public partial class HelloWorkerDbContext : DbContext {

		public HelloWorkerDbContext() : base("name=HelloWorkerDb") { }

		// public HelloWorkerDbContext(string connectionString) : base(connectionString) { }

		public virtual DbSet<Work> Work { get; set; }
		public virtual DbSet<WorkGroup> WorkGroup { get; set; }
		public virtual DbSet<Workplace> Workplace { get; set; }
		public virtual DbSet<WorkplaceWork> WorkplaceWorks { get; set; }
		public virtual DbSet<WorkCategory> WorkCategories { get; set; }
		public virtual DbSet<Act> Acts { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder) {

			modelBuilder.Entity<Act>()
				.Property(e => e.Name)
				.IsUnicode(false);

			modelBuilder.Entity<Act>()
				.HasMany(e => e.WorkplaceWorks)
				.WithOptional(e => e.Act)
				.WillCascadeOnDelete(false);



			modelBuilder.Entity<Work>()
				.Property(e => e.Name)
				.IsUnicode(false);

			modelBuilder.Entity<Work>()
				.Property(e => e.MeasureUnit)
				.IsUnicode(false);

			modelBuilder.Entity<Work>()
				.Property(e => e.Price)
				.HasPrecision(9, 2);

			modelBuilder.Entity<Work>()
				.HasMany(e => e.WorkplaceWorks)
				.WithRequired(e => e.Work)
				.WillCascadeOnDelete(false);



			modelBuilder.Entity<WorkGroup>()
				.Property(e => e.Name)
				.IsUnicode(false);

			modelBuilder.Entity<WorkGroup>()
				.HasMany(e => e.Work)
				.WithRequired(e => e.WorkGroup)
				.WillCascadeOnDelete(false);



			modelBuilder.Entity<WorkCategory>()
				.Property(e => e.Name)
				.IsUnicode(false);

			modelBuilder.Entity<WorkCategory>()
				.HasMany(e => e.Work)
				.WithRequired(e => e.WorkCategory)
				.WillCascadeOnDelete(false);



			modelBuilder.Entity<Workplace>()
				.Property(e => e.Name)
				.IsUnicode(false);

			modelBuilder.Entity<Workplace>()
				.Property(e => e.Address)
				.IsUnicode(false);

			modelBuilder.Entity<Workplace>()
				.Property(e => e.Cost)
				.HasPrecision(9, 2);

			modelBuilder.Entity<Workplace>()
				.HasMany(e => e.Acts)
				.WithRequired(e => e.Workplace)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Workplace>()
				.HasMany(e => e.WorkplaceWorks)
				.WithRequired(e => e.Workplace)
				.WillCascadeOnDelete(false);



			modelBuilder.Entity<WorkplaceWork>()
				.Property(e => e.Quadrature)
				.HasPrecision(6, 2);

			modelBuilder.Entity<WorkplaceWork>()
				.Property(e => e.Cost)
				.HasPrecision(9, 2);
		}
	}
}
