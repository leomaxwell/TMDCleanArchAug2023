using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayrollLite.Migrations
{
    /// <inheritdoc />
    public partial class ChangesFieldDecimalDataType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_GenderTypes_GenderTypeId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_PayrollItems_Employees_EmployeeId",
                table: "PayrollItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PayrollItems_Payrolls_PayrollId",
                table: "PayrollItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Payrolls_MonthsOfYear_MonthOfYearId",
                table: "Payrolls");

            migrationBuilder.DropForeignKey(
                name: "FK_Payrolls_PayrollStatusTypes_PayrollStatusTypeId",
                table: "Payrolls");

            migrationBuilder.DropIndex(
                name: "IX_Payrolls_MonthOfYearId",
                table: "Payrolls");

            migrationBuilder.DropIndex(
                name: "IX_Payrolls_PayrollStatusTypeId",
                table: "Payrolls");

            migrationBuilder.DropIndex(
                name: "IX_Employees_GenderTypeId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "MonthOfYearId",
                table: "Payrolls");

            migrationBuilder.DropColumn(
                name: "PayrollStatusTypeId",
                table: "Payrolls");

            migrationBuilder.DropColumn(
                name: "GenderTypeId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "Decimal(19,2)",
                table: "Payrolls",
                newName: "ExchangeRate");

            migrationBuilder.AlterColumn<decimal>(
                name: "ExchangeRate",
                table: "Payrolls",
                type: "DECIMAL(10,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "IncomeTax",
                table: "PayrollItems",
                type: "DECIMAL(10,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(19,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "GrossSalary",
                table: "PayrollItems",
                type: "DECIMAL(10,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(19,2)");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNo",
                table: "Employees",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "GrossSalary",
                table: "Employees",
                type: "DECIMAL(10,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateIndex(
                name: "IX_Payrolls_MonthId",
                table: "Payrolls",
                column: "MonthId");

            migrationBuilder.CreateIndex(
                name: "IX_Payrolls_StatusId",
                table: "Payrolls",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_GenderId",
                table: "Employees",
                column: "GenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_GenderTypes_GenderId",
                table: "Employees",
                column: "GenderId",
                principalTable: "GenderTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PayrollItems_Employees_EmployeeId",
                table: "PayrollItems",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PayrollItems_Payrolls_PayrollId",
                table: "PayrollItems",
                column: "PayrollId",
                principalTable: "Payrolls",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payrolls_MonthsOfYear_MonthId",
                table: "Payrolls",
                column: "MonthId",
                principalTable: "MonthsOfYear",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payrolls_PayrollStatusTypes_StatusId",
                table: "Payrolls",
                column: "StatusId",
                principalTable: "PayrollStatusTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_GenderTypes_GenderId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_PayrollItems_Employees_EmployeeId",
                table: "PayrollItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PayrollItems_Payrolls_PayrollId",
                table: "PayrollItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Payrolls_MonthsOfYear_MonthId",
                table: "Payrolls");

            migrationBuilder.DropForeignKey(
                name: "FK_Payrolls_PayrollStatusTypes_StatusId",
                table: "Payrolls");

            migrationBuilder.DropIndex(
                name: "IX_Payrolls_MonthId",
                table: "Payrolls");

            migrationBuilder.DropIndex(
                name: "IX_Payrolls_StatusId",
                table: "Payrolls");

            migrationBuilder.DropIndex(
                name: "IX_Employees_GenderId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "ExchangeRate",
                table: "Payrolls",
                newName: "Decimal(19,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Decimal(19,2)",
                table: "Payrolls",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(10,4)");

            migrationBuilder.AddColumn<int>(
                name: "MonthOfYearId",
                table: "Payrolls",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PayrollStatusTypeId",
                table: "Payrolls",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "IncomeTax",
                table: "PayrollItems",
                type: "Decimal(19,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(10,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "GrossSalary",
                table: "PayrollItems",
                type: "Decimal(19,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(10,4)");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNo",
                table: "Employees",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "GrossSalary",
                table: "Employees",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(10,4)");

            migrationBuilder.AddColumn<int>(
                name: "GenderTypeId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payrolls_MonthOfYearId",
                table: "Payrolls",
                column: "MonthOfYearId");

            migrationBuilder.CreateIndex(
                name: "IX_Payrolls_PayrollStatusTypeId",
                table: "Payrolls",
                column: "PayrollStatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_GenderTypeId",
                table: "Employees",
                column: "GenderTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_GenderTypes_GenderTypeId",
                table: "Employees",
                column: "GenderTypeId",
                principalTable: "GenderTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PayrollItems_Employees_EmployeeId",
                table: "PayrollItems",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PayrollItems_Payrolls_PayrollId",
                table: "PayrollItems",
                column: "PayrollId",
                principalTable: "Payrolls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payrolls_MonthsOfYear_MonthOfYearId",
                table: "Payrolls",
                column: "MonthOfYearId",
                principalTable: "MonthsOfYear",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payrolls_PayrollStatusTypes_PayrollStatusTypeId",
                table: "Payrolls",
                column: "PayrollStatusTypeId",
                principalTable: "PayrollStatusTypes",
                principalColumn: "Id");
        }
    }
}
