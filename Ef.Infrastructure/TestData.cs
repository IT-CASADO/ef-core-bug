using Ef.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ef.Infrastructure
{
	public static class TestData
	{
		public static Guid RoadmapIdAsGuid = Guid.Parse("02f23226-427f-4a5f-a8fa-db138222af49");
		public static RoadmapId RoadmapIdAsIdentiyObject = new RoadmapId(RoadmapIdAsGuid);

		public static Guid Tenant_Id = Guid.Parse("AAAAAAAA-0000-0000-0000-000000000000");

		// Hint: This is working fine
		//public static Guid Formula1_Id = Guid.Parse("10000000-0000-0000-0000-0000000000F1");
		//public static Guid Formula2_Id = Guid.Parse("20000000-0000-0000-0000-0000000000F2");
		//public static Guid Formula3_Id = Guid.Parse("30000000-0000-0000-0000-0000000000F3");
		//public static Guid Formula4_Id = Guid.Parse("40000000-0000-0000-0000-0000000000F4");

		// Hint: This doesn't work
		public static Guid Formula1_Id = Guid.Parse("40000000-0000-0000-0000-0000000000F1");
		public static Guid Formula2_Id = Guid.Parse("20000000-0000-0000-0000-0000000000F2");
		public static Guid Formula3_Id = Guid.Parse("30000000-0000-0000-0000-0000000000F3");
		public static Guid Formula4_Id = Guid.Parse("10000000-0000-0000-0000-0000000000F4");


		public static Model.Attribute[] AllAttributes
		{
			get {
				return NormalAttributes.Union(FormulaAttributes).ToArray();
			}
		}

		public static Model.Attribute[] NormalAttributes
		{
			get {
				return new[] {
				new Model.Attribute {
					Id = Guid.Parse("00000000-0000-0000-0000-00000000F1A1"),
					Name = "Attribute 1",
					RoadmapId = RoadmapIdAsIdentiyObject,
					Formula = "",
				},
				new Model.Attribute {
					Id = Guid.Parse("00000000-0000-0000-0000-00000000F1A2"),
					Name = "Attribute 2",
					RoadmapId = RoadmapIdAsIdentiyObject,
					Formula = "",
				},
				new Model.Attribute {
					Id = Guid.Parse("00000000-0000-0000-0000-00000000F2A3"),
					Name = "Attribute 3",
					RoadmapId = RoadmapIdAsIdentiyObject,
					Formula = "",
				},
				new Model.Attribute {
					Id = Guid.Parse("00000000-0000-0000-0000-00000000F2A4"),
					Name = "Attribute 4",
					RoadmapId = RoadmapIdAsIdentiyObject,
					Formula = "",
				},
				new Model.Attribute {
					Id = Guid.Parse("00000000-0000-0000-0000-00000000F3A5"),
					Name = "Attribute 5",
					RoadmapId = RoadmapIdAsIdentiyObject,
					Formula = "",
				},
				new Model.Attribute {
					Id = Guid.Parse("00000000-0000-0000-0000-00000000F3A6"),
					Name = "Attribute 6",
					RoadmapId = RoadmapIdAsIdentiyObject,
					Formula = "",
				},
				new Model.Attribute {
					Id = Guid.Parse("00000000-0000-0000-0000-00000000F4A7"),
					Name = "Attribute 7",
					RoadmapId = RoadmapIdAsIdentiyObject,
					Formula = "",
				},
				new Model.Attribute {
					Id = Guid.Parse("00000000-0000-0000-0000-00000000F4A8"),
					Name = "Attribute 8",
					RoadmapId = RoadmapIdAsIdentiyObject,
					//RoadmapIdAsGuid = RoadmapIdAsGuid,
					//RoadmapIdAsIdentiyObject = RoadmapIdAsIdentiyObject,
					Formula = "",
				},
			};
			}
		}

		public static Model.Attribute[] FormulaAttributes
		{
			get {

				var formula1_variableAttributes = FormulaVariableAttributes.Where(e => e.AttributeId == Formula1_Id);
				var formula2_variableAttributes = FormulaVariableAttributes.Where(e => e.AttributeId == Formula2_Id);
				var formula3_variableAttributes = FormulaVariableAttributes.Where(e => e.AttributeId == Formula3_Id);
				var formula4_variableAttributes = FormulaVariableAttributes.Where(e => e.AttributeId == Formula4_Id);

				return new[] {
				new Model.Attribute(formula1_variableAttributes) {
					Id = Formula1_Id,
					Name = "Formula 1",
					RoadmapId = RoadmapIdAsIdentiyObject,
					Formula = "A1 + A2",
				},
				new Model.Attribute(formula2_variableAttributes) {
					Id = Formula2_Id,
					Name = "Formula 2",
					RoadmapId = RoadmapIdAsIdentiyObject,
					Formula = "A3 + A4",
				},
				new Model.Attribute(formula3_variableAttributes) {
					Id = Formula3_Id,
					Name = "Formula 3",
					RoadmapId = RoadmapIdAsIdentiyObject,
					Formula = "A5 + A6",
				},
				new Model.Attribute(formula4_variableAttributes) {
					Id = Formula4_Id,
					Name = "Formula 4",
					RoadmapId = RoadmapIdAsIdentiyObject,
					Formula = "A7 + A8",
				},
			};
			}
		}

		public static List<Model.FormulaVariableAttribute> FormulaVariableAttributes
		{
			get {
				return new List<FormulaVariableAttribute>()
				{
					new FormulaVariableAttribute(Tenant_Id, Formula1_Id, NormalAttributes[0].Id),
					new FormulaVariableAttribute(Tenant_Id, Formula1_Id, NormalAttributes[1].Id),

					new FormulaVariableAttribute(Tenant_Id, Formula2_Id, NormalAttributes[2].Id),
					new FormulaVariableAttribute(Tenant_Id, Formula2_Id, NormalAttributes[3].Id),

					new FormulaVariableAttribute(Tenant_Id, Formula3_Id, NormalAttributes[4].Id),
					new FormulaVariableAttribute(Tenant_Id, Formula3_Id, NormalAttributes[5].Id),

					new FormulaVariableAttribute(Tenant_Id, Formula4_Id, NormalAttributes[6].Id),
					new FormulaVariableAttribute(Tenant_Id, Formula4_Id, NormalAttributes[7].Id),
				};
			}
		}
	}
}
