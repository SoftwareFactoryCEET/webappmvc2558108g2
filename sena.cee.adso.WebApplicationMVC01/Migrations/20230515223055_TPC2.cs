using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sena.cee.adso.WebApplicationMVC01.Migrations
{
    /// <inheritdoc />
    public partial class TPC2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "DownloadSpeed",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "MobileNumber",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "PackageType",
                table: "Contracts");

            migrationBuilder.CreateTable(
                name: "BroadBandContract",
                columns: table => new
                {
                    ContractId = table.Column<int>(type: "int", nullable: false),
                    DownloadSpeed = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BroadBandContract", x => x.ContractId);
                    table.ForeignKey(
                        name: "FK_BroadBandContract_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "ContractId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MobileContract",
                columns: table => new
                {
                    ContractId = table.Column<int>(type: "int", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobileContract", x => x.ContractId);
                    table.ForeignKey(
                        name: "FK_MobileContract_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "ContractId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TvContract",
                columns: table => new
                {
                    ContractId = table.Column<int>(type: "int", nullable: false),
                    PackageType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvContract", x => x.ContractId);
                    table.ForeignKey(
                        name: "FK_TvContract_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "ContractId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BroadBandContract");

            migrationBuilder.DropTable(
                name: "MobileContract");

            migrationBuilder.DropTable(
                name: "TvContract");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Contracts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DownloadSpeed",
                table: "Contracts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MobileNumber",
                table: "Contracts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PackageType",
                table: "Contracts",
                type: "int",
                nullable: true);
        }
    }
}
