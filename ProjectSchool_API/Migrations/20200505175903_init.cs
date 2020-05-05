using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectSchool_API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    DtBirth = table.Column<string>(nullable: true),
                    TeacherId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Students_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "ID", "Name" },
                values: new object[] { 1, "John" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "ID", "Name" },
                values: new object[] { 2, "Mary" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "ID", "Name" },
                values: new object[] { 3, "Steve" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "ID", "DtBirth", "Lastname", "Name", "TeacherId" },
                values: new object[] { 1, "01/01/2000", "McDonald", "Alexander", 1 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "ID", "DtBirth", "Lastname", "Name", "TeacherId" },
                values: new object[] { 2, "02/02/2000", "Bruce", "Glen", 2 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "ID", "DtBirth", "Lastname", "Name", "TeacherId" },
                values: new object[] { 3, "02/03/2000", "Nelson", "Connor", 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Students_TeacherId",
                table: "Students",
                column: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
