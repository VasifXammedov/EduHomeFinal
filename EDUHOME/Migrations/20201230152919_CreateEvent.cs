using Microsoft.EntityFrameworkCore.Migrations;

namespace EDUHOME.Migrations
{
    public partial class CreateEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LayerId",
                table: "LatestPostDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_LatestPostDetails_LayerId",
                table: "LatestPostDetails",
                column: "LayerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LatestPostDetails_Layers_LayerId",
                table: "LatestPostDetails",
                column: "LayerId",
                principalTable: "Layers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LatestPostDetails_Layers_LayerId",
                table: "LatestPostDetails");

            migrationBuilder.DropIndex(
                name: "IX_LatestPostDetails_LayerId",
                table: "LatestPostDetails");

            migrationBuilder.DropColumn(
                name: "LayerId",
                table: "LatestPostDetails");
        }
    }
}
