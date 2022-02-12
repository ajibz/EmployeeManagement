using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.Migrations
{
    public partial class forthDbMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "maritalStatuses");

            migrationBuilder.DropColumn(
                name: "EmploeeName",
                table: "projects");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeName",
                table: "projects",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeName",
                table: "projects");

            migrationBuilder.AddColumn<string>(
                name: "EmploeeName",
                table: "projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "maritalStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Female = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Male = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    employeesEmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_maritalStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_maritalStatuses_employees_employeesEmployeeId",
                        column: x => x.employeesEmployeeId,
                        principalTable: "employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_maritalStatuses_employeesEmployeeId",
                table: "maritalStatuses",
                column: "employeesEmployeeId");
        }
    }
}
