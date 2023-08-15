using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayrollLite.Migrations
{
    /// <inheritdoc />
    public partial class AddEnumKeyToPayrollStatusType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EnumKey",
                table: "PayrollStatusTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnumKey",
                table: "PayrollStatusTypes");
        }
    }
}
