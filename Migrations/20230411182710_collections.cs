using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RedditProject.Migrations
{
    /// <inheritdoc />
    public partial class collections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_UserId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "CommentId",
                table: "Users",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_CommentId",
                table: "Users",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Comments_CommentId",
                table: "Users",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "CommentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Comments_CommentId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CommentId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Comments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
