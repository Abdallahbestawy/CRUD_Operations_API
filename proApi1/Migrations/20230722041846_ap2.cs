using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proApi1.Migrations
{
    public partial class ap2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DeptId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "DeptId",
                table: "Employees",
                newName: "DeptID");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_DeptId",
                table: "Employees",
                newName: "IX_Employees_DeptID");

            migrationBuilder.AlterColumn<int>(
                name: "DeptID",
                table: "Employees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DeptID",
                table: "Employees",
                column: "DeptID",
                principalTable: "Departments",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DeptID",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "DeptID",
                table: "Employees",
                newName: "DeptId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_DeptID",
                table: "Employees",
                newName: "IX_Employees_DeptId");

            migrationBuilder.AlterColumn<int>(
                name: "DeptId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DeptId",
                table: "Employees",
                column: "DeptId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
