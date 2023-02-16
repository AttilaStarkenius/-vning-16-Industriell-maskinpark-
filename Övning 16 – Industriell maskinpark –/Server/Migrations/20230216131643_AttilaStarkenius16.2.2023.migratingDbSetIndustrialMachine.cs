using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Övning16Industriellmaskinpark.Server.Migrations
{
    /// <inheritdoc />
    public partial class AttilaStarkenius1622023migratingDbSetIndustrialMachine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IndustrialMachines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    currentStatus = table.Column<bool>(type: "bit", nullable: false),
                    latestDataSentFromMachine = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndustrialMachines", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IndustrialMachines");
        }
    }
}
