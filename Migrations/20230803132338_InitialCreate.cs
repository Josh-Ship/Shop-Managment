using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop_Sales.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    employee_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    hourlyPay_in_cents = table.Column<int>(type: "INTEGER", nullable: false),
                    shiftPay_in_cents = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.employee_id);
                });

            migrationBuilder.CreateTable(
                name: "Records",
                columns: table => new
                {
                    record_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    date = table.Column<string>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    amount_in_cents = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Records", x => x.record_id);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    region_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    fee_in_cents = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.region_id);
                });

            migrationBuilder.CreateTable(
                name: "Employee_Shift",
                columns: table => new
                {
                    shift_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    employee_id = table.Column<int>(type: "INTEGER", nullable: false),
                    date = table.Column<string>(type: "TEXT", nullable: false),
                    start_time = table.Column<string>(type: "TEXT", nullable: false),
                    end_time = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee_Shift", x => x.shift_id);
                    table.ForeignKey(
                        name: "FK_Employee_Shift_Employee_employee_id",
                        column: x => x.employee_id,
                        principalTable: "Employee",
                        principalColumn: "employee_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Driver_Trip",
                columns: table => new
                {
                    trip_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    employee_id = table.Column<int>(type: "INTEGER", nullable: false),
                    date = table.Column<string>(type: "TEXT", nullable: false),
                    region_id = table.Column<int>(type: "INTEGER", nullable: false),
                    departure_time = table.Column<string>(type: "TEXT", nullable: false),
                    shiftPay_in_cents = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Driver_Trip", x => x.trip_id);
                    table.ForeignKey(
                        name: "FK_Driver_Trip_Employee_employee_id",
                        column: x => x.employee_id,
                        principalTable: "Employee",
                        principalColumn: "employee_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Driver_Trip_Region_region_id",
                        column: x => x.region_id,
                        principalTable: "Region",
                        principalColumn: "region_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Driver_Trip_employee_id",
                table: "Driver_Trip",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_Driver_Trip_region_id",
                table: "Driver_Trip",
                column: "region_id");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Shift_employee_id",
                table: "Employee_Shift",
                column: "employee_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Driver_Trip");

            migrationBuilder.DropTable(
                name: "Employee_Shift");

            migrationBuilder.DropTable(
                name: "Records");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
