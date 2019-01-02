using Ef.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using System;

namespace Ef.Infrastructure
{
	public class PlanningEngineDbContext : DbContext
	{
		public DbSet<Ef.Model.Attribute> Attributes { get; set; }

		public PlanningEngineDbContext() : base()
		{
			ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);

			if (!optionsBuilder.IsConfigured)
			{
				var connection = @"Server=(localdb)\mssqllocaldb;Database=EFCoreBug.NewDb;Trusted_Connection=True;ConnectRetryCount=0";
				//var connection = "Server=(local)\\SQL2016;Database=EVO.APP.PlanningEngine;Trusted_Connection=True;";

				optionsBuilder.UseSqlServer(connection, options =>
				{
					options.CommandTimeout(300);
				});
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			#region applying mapping configuration

			const string schema = "PlanningEngine";

			modelBuilder.HasDefaultSchema(schema);
			modelBuilder.ApplyConfiguration(new AttributeConfiguration());
			modelBuilder.ApplyConfiguration(new FormulaVariableAttributeConfiguration());

			#endregion
		}
	}
}


