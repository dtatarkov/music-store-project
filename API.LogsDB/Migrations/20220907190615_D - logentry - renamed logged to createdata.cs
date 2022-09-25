using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.LogsDB.Migrations
{
    public partial class Dlogentryrenamedloggedtocreatedata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Logged",
                table: "LogEntries",
                newName: "CreateDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "LogEntries",
                newName: "Logged");
        }
    }
}
