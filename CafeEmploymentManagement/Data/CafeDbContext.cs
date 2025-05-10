using CafeEmploymentManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CafeEmploymentManagement.Data
{
	public class CafeDbContext : DbContext
	{
		public virtual DbSet<Cafe> Cafes { get; set; }
		public virtual DbSet<Employee> Employees { get; set; }


		public CafeDbContext(DbContextOptions<CafeDbContext> options) : base(options)
		{

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Employee>(entity =>
			{
				entity.HasKey(e => e.Id);

				entity.Property(e => e.Id)
					.ValueGeneratedOnAdd();
			});
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}

	}
}
