using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuiXuanHung0281.Migrations
{
    /// <inheritdoc />
    public partial class Create_Table_BXHstudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BXHstudent",
                columns: table => new
                {
                    BXHstudentID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BXHstudentName = table.Column<string>(type: "TEXT", nullable: false),
                    BXHstudentSex = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BXHstudent", x => x.BXHstudentID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BXHstudent");
        }
    }
}
