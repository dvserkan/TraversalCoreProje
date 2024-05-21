using Microsoft.EntityFrameworkCore;
using TraversalApiProject.DAL.Entities;

namespace TraversalApiProject.DAL.Context
{
	public class VisitorContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=.\\POSSQL;initial Catalog=TraversalDbApi;user=sa;Password=sql123_;TrustServerCertificate=True");
		}

		public DbSet<Visitor> Visitors { get; set; }
	}
}
