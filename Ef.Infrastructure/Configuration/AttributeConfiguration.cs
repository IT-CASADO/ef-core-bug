using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Diagnostics;
using System.Linq;

namespace Ef.Infrastructure.Configuration
{
	public class AttributeConfiguration : IEntityTypeConfiguration<Model.Attribute>
	{

		public AttributeConfiguration()
		{
		}

		public void Configure(EntityTypeBuilder<Model.Attribute> builder)
		{
			builder.HasKey(x => x.Id);

			builder.Property(u => u.TenantId)
				.IsRequired();

			builder.Property(u => u.RoadmapId)
				.HasIdentityObjectGuidConverter()
				.IsRequired();

			builder.Property(x => x.Name)
				.HasMaxLength(128)
				.IsRequired();

			builder.Property(x => x.Formula);

			builder.Metadata.FindNavigation(nameof(Model.Attribute.FormulaVariableAttributes))
				.SetPropertyAccessMode(PropertyAccessMode.Field);

			builder.ToTable("Attribute");

			//builder.HasData(TestData.AllAttributes);
		}
	}

	public class FormulaVariableAttributeConfiguration : IEntityTypeConfiguration<Model.FormulaVariableAttribute>
	{
		public void Configure(EntityTypeBuilder<Model.FormulaVariableAttribute> builder)
		{
			builder.HasKey(dv => new { dv.AttributeId, dv.VariableAttributeId });

			builder.Property("TenantId")
				.IsRequired();

			builder.ToTable("AttributeFormulaVariableAttribute");

			//builder.HasData(TestData.FormulaVariableAttributes);
		}
	}
}
