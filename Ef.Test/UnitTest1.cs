using Ef.Infrastructure;
using Ef.Model;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace Ef.Test
{
	public class UnitTest1
	{
		PlanningEngineDbContext context;

		public UnitTest1()
		{
			context = new PlanningEngineDbContext();

			if (context.Database.GetDbConnection().Database != "")
			{
				context.Database.EnsureDeleted();
				context.Database.EnsureCreated();
				GenerateData(context);
			}

			ResetContext();
		}

		private void ResetContext()
		{
			context = new PlanningEngineDbContext();

		}

		[Fact()]
		public void Test()
		{
		}

		[Fact()]
		public void Compare_RoadmapId()
		{
			TestData.RoadmapIdAsGuid.Should().Be(TestData.RoadmapIdAsIdentiyObject);
		}

		[Fact()]
		public void Read_by_Guid()
		{
			// act
			var formulaAttributes = context.Attributes
				.Include(e => e.FormulaVariableAttributes)
				.Where(e => !string.IsNullOrWhiteSpace(e.Formula))
				.Where(e => e.RoadmapId == TestData.RoadmapIdAsGuid)
				//.Where(e => e.RoadmapIdAsGuid == TestData.RoadmapIdAsGuid)
				.ToList();

			// assert
			formulaAttributes.Count().Should().Be(4);
			formulaAttributes.SelectMany(e => e.FormulaVariableAttributes).Count().Should().Be(8);
		}

		[Fact()]
		public void Read_by_IdentityObject()
		{
			// act
			var formulaAttributes = context.Attributes
				.Include(e => e.FormulaVariableAttributes)
				.Where(e => !string.IsNullOrWhiteSpace(e.Formula))
				.Where(e => e.RoadmapId == TestData.RoadmapIdAsIdentiyObject)
				//.Where(e => e.RoadmapIdAsIdentiyObject == TestData.RoadmapIdAsIdentiyObject)
				.ToList();

			// assert
			formulaAttributes.Count().Should().Be(4);
			formulaAttributes.SelectMany(e => e.FormulaVariableAttributes).Count().Should().Be(8);
		}


		private void GenerateData(PlanningEngineDbContext context)
		{
			context.Attributes.AddRange(TestData.AllAttributes);
			context.SaveChanges();
		}
	}
}
