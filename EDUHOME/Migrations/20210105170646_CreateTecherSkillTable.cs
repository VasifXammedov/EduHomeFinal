using Microsoft.EntityFrameworkCore.Migrations;

namespace EDUHOME.Migrations
{
    public partial class CreateTecherSkillTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeacherSkill",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillsTeacherDetailId = table.Column<int>(nullable: false),
                    TeacherId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherSkill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherSkill_SkillsTeacherDetails_SkillsTeacherDetailId",
                        column: x => x.SkillsTeacherDetailId,
                        principalTable: "SkillsTeacherDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherSkill_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSkill_SkillsTeacherDetailId",
                table: "TeacherSkill",
                column: "SkillsTeacherDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSkill_TeacherId",
                table: "TeacherSkill",
                column: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeacherSkill");
        }
    }
}
