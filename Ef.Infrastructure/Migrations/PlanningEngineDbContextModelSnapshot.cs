﻿// <auto-generated />
using System;
using Ef.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Ef.Infrastructure.Migrations
{
    [DbContext(typeof(PlanningEngineDbContext))]
    partial class PlanningEngineDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("PlanningEngine")
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Ef.Model.Attribute", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Formula");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<Guid?>("ParentId");

                    b.Property<Guid>("RoadmapId");

                    b.Property<Guid>("TenantId");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Attribute");
                });

            modelBuilder.Entity("Ef.Model.FormulaVariableAttribute", b =>
                {
                    b.Property<Guid>("AttributeId");

                    b.Property<Guid>("VariableAttributeId");

                    b.Property<Guid>("TenantId");

                    b.HasKey("AttributeId", "VariableAttributeId");

                    b.ToTable("AttributeFormulaVariableAttribute");
                });

            modelBuilder.Entity("Ef.Model.Attribute", b =>
                {
                    b.HasOne("Ef.Model.Attribute")
                        .WithMany()
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("Ef.Model.FormulaVariableAttribute", b =>
                {
                    b.HasOne("Ef.Model.Attribute")
                        .WithMany("FormulaVariableAttributes")
                        .HasForeignKey("AttributeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
