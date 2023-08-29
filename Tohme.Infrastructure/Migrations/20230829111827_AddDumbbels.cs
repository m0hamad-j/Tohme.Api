using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tohme.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDumbbels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GymId",
                table: "Trainers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GymId",
                table: "Trainees",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GymId",
                table: "Proteins",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GymId",
                table: "Dumbbells",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trainers_GymId",
                table: "Trainers",
                column: "GymId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainees_GymId",
                table: "Trainees",
                column: "GymId");

            migrationBuilder.CreateIndex(
                name: "IX_Proteins_GymId",
                table: "Proteins",
                column: "GymId");

            migrationBuilder.CreateIndex(
                name: "IX_Dumbbells_GymId",
                table: "Dumbbells",
                column: "GymId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dumbbells_Gyms_GymId",
                table: "Dumbbells",
                column: "GymId",
                principalTable: "Gyms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Proteins_Gyms_GymId",
                table: "Proteins",
                column: "GymId",
                principalTable: "Gyms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainees_Gyms_GymId",
                table: "Trainees",
                column: "GymId",
                principalTable: "Gyms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainers_Gyms_GymId",
                table: "Trainers",
                column: "GymId",
                principalTable: "Gyms",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dumbbells_Gyms_GymId",
                table: "Dumbbells");

            migrationBuilder.DropForeignKey(
                name: "FK_Proteins_Gyms_GymId",
                table: "Proteins");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainees_Gyms_GymId",
                table: "Trainees");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainers_Gyms_GymId",
                table: "Trainers");

            migrationBuilder.DropIndex(
                name: "IX_Trainers_GymId",
                table: "Trainers");

            migrationBuilder.DropIndex(
                name: "IX_Trainees_GymId",
                table: "Trainees");

            migrationBuilder.DropIndex(
                name: "IX_Proteins_GymId",
                table: "Proteins");

            migrationBuilder.DropIndex(
                name: "IX_Dumbbells_GymId",
                table: "Dumbbells");

            migrationBuilder.DropColumn(
                name: "GymId",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "GymId",
                table: "Trainees");

            migrationBuilder.DropColumn(
                name: "GymId",
                table: "Proteins");

            migrationBuilder.DropColumn(
                name: "GymId",
                table: "Dumbbells");
        }
    }
}
