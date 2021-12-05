using Microsoft.EntityFrameworkCore;
using UserDemo.Entities;

namespace UserDemo.DataAccess.Concrete.EfCore
{
	public class EntityContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
			optionsBuilder.UseSqlServer("server=AYTUNC-PC\\SQLEXPRESS;database=UserDemo;integrated security=true;");
		}

		public DbSet<User> Users { get; set; }

	}
}
