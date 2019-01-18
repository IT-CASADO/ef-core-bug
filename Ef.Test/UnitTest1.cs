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

		private void GenerateData(PlanningEngineDbContext context)
		{
			context.Attributes.AddRange(TestData.AllAttributes);
			context.SaveChanges();
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
			TestData.RoadmapIdAsGuid.Should().Be(TestData.RoadmapIdAsIdentityObject);
		}

		[Fact()]
		public void Read_All_Formulas()
		{
			// act
			var formulaAttributes = context.Attributes
				.Include(e => e.FormulaVariableAttributes)
				.ToList();

			// assert
			formulaAttributes.SelectMany(e => e.FormulaVariableAttributes).Count().Should().Be(8);
		}

		[Fact()]
		public void Read_by_Guid()
		{
			Guid filter = TestData.RoadmapIdAsGuid;

			// act
			var formulaAttributes = context.Attributes
				.Include(e => e.FormulaVariableAttributes)
				.Where(e => e.RoadmapId == filter)
				.ToList();

			// assert
			formulaAttributes.SelectMany(e => e.FormulaVariableAttributes).Count().Should().Be(8);
		}

		[Fact()]
		public void Read_by_IdentityObject()
		{
			RoadmapId filter = TestData.RoadmapIdAsIdentityObject;

			// act
			var formulaAttributes = context.Attributes
				.Include(e => e.FormulaVariableAttributes)
				.Where(e => e.RoadmapId == filter)
				.ToList();

			// assert
			formulaAttributes.SelectMany(e => e.FormulaVariableAttributes).Count().Should().Be(8);
		}

		[Fact()]
		public void Single_by_PrimaryKey_with_IdentityObject()
		{
			// act formula1
			var formula1 = context.Attributes
				.Include(e => e.FormulaVariableAttributes)
				.Single(e => e.Id == TestData.Formula1_Id && e.RoadmapId == TestData.RoadmapIdAsIdentityObject);

			// assert
			formula1.FormulaVariableAttributes.Count().Should().Be(2);

			// act formula2
			var formula2 = context.Attributes
				.Include(e => e.FormulaVariableAttributes)
				.Single(e => e.Id == TestData.Formula2_Id && e.RoadmapId == TestData.RoadmapIdAsIdentityObject);

			// assert
			formula2.FormulaVariableAttributes.Count().Should().Be(2);

			// act formula3
			var formula3 = context.Attributes
				.Include(e => e.FormulaVariableAttributes)
				.Single(e => e.Id == TestData.Formula3_Id && e.RoadmapId == TestData.RoadmapIdAsIdentityObject);

			// assert
			formula3.FormulaVariableAttributes.Count().Should().Be(2);

			// act formula4
			var formula4 = context.Attributes
				.Include(e => e.FormulaVariableAttributes)
				.Single(e => e.Id == TestData.Formula4_Id && e.RoadmapId == TestData.RoadmapIdAsIdentityObject);

			// assert
			formula4.FormulaVariableAttributes.Count().Should().Be(2);
		}
	}
}
