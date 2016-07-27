using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using kirby.models;

namespace kirby.Migrations
{
    [DbContext(typeof(appDbContext))]
    partial class appDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("kirby.models.formula", b =>
                {
                    b.Property<int>("formulaId")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("arm");

                    b.Property<float>("cuff");

                    b.Property<string>("name");

                    b.Property<float>("neck");

                    b.HasKey("formulaId");

                    b.ToTable("formulas");
                });

            modelBuilder.Entity("kirby.models.needle", b =>
                {
                    b.Property<int>("needleId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("brand");

                    b.Property<string>("line");

                    b.Property<string>("material");

                    b.Property<float>("mmSize");

                    b.Property<string>("product");

                    b.Property<string>("style");

                    b.HasKey("needleId");

                    b.ToTable("needles");
                });

            modelBuilder.Entity("kirby.models.pattern", b =>
                {
                    b.Property<int>("patternId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("name");

                    b.HasKey("patternId");

                    b.ToTable("patterns");
                });

            modelBuilder.Entity("kirby.models.size", b =>
                {
                    b.Property<int>("sizeId")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("bust");

                    b.Property<float>("cuff");

                    b.Property<float>("hip");

                    b.Property<string>("name");

                    b.Property<float>("neck");

                    b.Property<float>("sleeveLen");

                    b.Property<float>("torso");

                    b.HasKey("sizeId");

                    b.ToTable("sizes");
                });

            modelBuilder.Entity("kirby.models.swatch", b =>
                {
                    b.Property<int>("swatchId")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("length");

                    b.Property<string>("name");

                    b.Property<int?>("needleId");

                    b.Property<int>("rows");

                    b.Property<int>("stitches");

                    b.Property<float>("width");

                    b.Property<int?>("yarnId");

                    b.HasKey("swatchId");

                    b.HasIndex("needleId");

                    b.HasIndex("yarnId");

                    b.ToTable("swatches");
                });

            modelBuilder.Entity("kirby.models.sweater", b =>
                {
                    b.Property<int>("sweaterId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("formulaId");

                    b.Property<string>("name");

                    b.Property<int?>("patternId");

                    b.Property<string>("recipient");

                    b.Property<int?>("sizeId");

                    b.Property<int?>("swatchId");

                    b.HasKey("sweaterId");

                    b.HasIndex("formulaId");

                    b.HasIndex("patternId");

                    b.HasIndex("sizeId");

                    b.HasIndex("swatchId");

                    b.ToTable("sweaters");
                });

            modelBuilder.Entity("kirby.models.yarn", b =>
                {
                    b.Property<int>("yarnId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("brand");

                    b.Property<string>("line");

                    b.Property<string>("notes");

                    b.Property<string>("product");

                    b.Property<string>("weight");

                    b.HasKey("yarnId");

                    b.ToTable("yarns");
                });

            modelBuilder.Entity("kirby.models.swatch", b =>
                {
                    b.HasOne("kirby.models.needle", "needle")
                        .WithMany()
                        .HasForeignKey("needleId");

                    b.HasOne("kirby.models.yarn", "yarn")
                        .WithMany()
                        .HasForeignKey("yarnId");
                });

            modelBuilder.Entity("kirby.models.sweater", b =>
                {
                    b.HasOne("kirby.models.formula", "formula")
                        .WithMany()
                        .HasForeignKey("formulaId");

                    b.HasOne("kirby.models.pattern", "pattern")
                        .WithMany()
                        .HasForeignKey("patternId");

                    b.HasOne("kirby.models.size", "size")
                        .WithMany()
                        .HasForeignKey("sizeId");

                    b.HasOne("kirby.models.swatch", "swatch")
                        .WithMany()
                        .HasForeignKey("swatchId");
                });
        }
    }
}
