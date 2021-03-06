// <auto-generated />
using System;
using DirtRivalsswag;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DirtRivalsswag.Migrations
{
    [DbContext(typeof(DailyChallengeContext))]
    partial class DailyChallengeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DirtRivalsswag.Models.Challenge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ChallengeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MetaDataId")
                        .HasColumnType("int");

                    b.Property<string>("ReferenceName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("discipline")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("entryWindowEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("entryWindowStart")
                        .HasColumnType("datetime2");

                    b.Property<string>("eventName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("stageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("vehicleClass")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MetaDataId");

                    b.ToTable("Challenges");
                });

            modelBuilder.Entity("DirtRivalsswag.Models.Entry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("DNF")
                        .HasColumnType("bit");

                    b.Property<string>("DriverName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EntryReferenceName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rank")
                        .HasColumnType("int");

                    b.Property<string>("VehicleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("assist")
                        .HasColumnType("bit");

                    b.Property<int>("challengeId")
                        .HasColumnType("int");

                    b.Property<string>("platform")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("stagetime")
                        .HasColumnType("float");

                    b.Property<bool>("wheel")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("challengeId");

                    b.ToTable("Entries");
                });

            modelBuilder.Entity("DirtRivalsswag.Models.MetaData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Year")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Metadatas");
                });

            modelBuilder.Entity("Models.Rival", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DriverName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("DriverName")
                        .IsUnique()
                        .HasFilter("[DriverName] IS NOT NULL");

                    b.ToTable("Rivals");
                });

            modelBuilder.Entity("DirtRivalsswag.Models.Challenge", b =>
                {
                    b.HasOne("DirtRivalsswag.Models.MetaData", null)
                        .WithMany("Challenges")
                        .HasForeignKey("MetaDataId");
                });

            modelBuilder.Entity("DirtRivalsswag.Models.Entry", b =>
                {
                    b.HasOne("DirtRivalsswag.Models.Challenge", null)
                        .WithMany("entries")
                        .HasForeignKey("challengeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DirtRivalsswag.Models.Challenge", b =>
                {
                    b.Navigation("entries");
                });

            modelBuilder.Entity("DirtRivalsswag.Models.MetaData", b =>
                {
                    b.Navigation("Challenges");
                });
#pragma warning restore 612, 618
        }
    }
}
