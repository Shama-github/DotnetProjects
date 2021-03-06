// <auto-generated />
using Entityframeworkcoremvc.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Entityframeworkcoremvc.Migrations
{
    [DbContext(typeof(EmpDbContext))]
    [Migration("20210730045923_CodeFirstDemo")]
    partial class CodeFirstDemo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entityframeworkcoremvc.Models.Emp", b =>
                {
                    b.Property<int>("EID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ESal")
                        .HasColumnType("int");

                    b.HasKey("EID");

                    b.ToTable("Emps");
                });
#pragma warning restore 612, 618
        }
    }
}
