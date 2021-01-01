using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EDUHOME.Migrations
{
    public partial class CreateEvenDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LatestPostDetails_Layers_LayerId",
                table: "LatestPostDetails");

            migrationBuilder.DropIndex(
                name: "IX_LatestPostDetails_LayerId",
                table: "LatestPostDetails");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Layers");

            migrationBuilder.DropColumn(
                name: "LayerId",
                table: "LatestPostDetails");

            migrationBuilder.DropColumn(
                name: "Imace",
                table: "BestDetailesWorkshops");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "BestDetailesWorkshops");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "BestDetailesWorkshops");

            migrationBuilder.DropColumn(
                name: "Venue",
                table: "BestDetailesWorkshops");

            migrationBuilder.AddColumn<int>(
                name: "Day",
                table: "Layers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LatestPostDetailId",
                table: "Layers",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "LatestPostDetails",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Day",
                table: "LatestPostDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "LatestPostDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Month",
                table: "LatestPostDetails",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LatestPostDetailId",
                table: "BestDetailesWorkshops",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Layers_LatestPostDetailId",
                table: "Layers",
                column: "LatestPostDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_BestDetailesWorkshops_LatestPostDetailId",
                table: "BestDetailesWorkshops",
                column: "LatestPostDetailId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BestDetailesWorkshops_LatestPostDetails_LatestPostDetailId",
                table: "BestDetailesWorkshops",
                column: "LatestPostDetailId",
                principalTable: "LatestPostDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Layers_LatestPostDetails_LatestPostDetailId",
                table: "Layers",
                column: "LatestPostDetailId",
                principalTable: "LatestPostDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BestDetailesWorkshops_LatestPostDetails_LatestPostDetailId",
                table: "BestDetailesWorkshops");

            migrationBuilder.DropForeignKey(
                name: "FK_Layers_LatestPostDetails_LatestPostDetailId",
                table: "Layers");

            migrationBuilder.DropIndex(
                name: "IX_Layers_LatestPostDetailId",
                table: "Layers");

            migrationBuilder.DropIndex(
                name: "IX_BestDetailesWorkshops_LatestPostDetailId",
                table: "BestDetailesWorkshops");

            migrationBuilder.DropColumn(
                name: "Day",
                table: "Layers");

            migrationBuilder.DropColumn(
                name: "LatestPostDetailId",
                table: "Layers");

            migrationBuilder.DropColumn(
                name: "Day",
                table: "LatestPostDetails");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "LatestPostDetails");

            migrationBuilder.DropColumn(
                name: "Month",
                table: "LatestPostDetails");

            migrationBuilder.DropColumn(
                name: "LatestPostDetailId",
                table: "BestDetailesWorkshops");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Layers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "LatestPostDetails",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LayerId",
                table: "LatestPostDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Imace",
                table: "BestDetailesWorkshops",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                table: "BestDetailesWorkshops",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "BestDetailesWorkshops",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Venue",
                table: "BestDetailesWorkshops",
                type: "nvarchar(max)",
                nullable: true);

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
    }
}
