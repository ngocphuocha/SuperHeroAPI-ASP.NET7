using System;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
	public class DataContext: DbContext
	{
		public DataContext(DbContextOptions<DataContext> options): base(options) 
		{ 
			 
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=superherodb;Trusted_Connection=true;TrustServerCertificate=true;");
		}

		public DbSet<SuperHero> SuperHeros { get; set; }

    } 
}

