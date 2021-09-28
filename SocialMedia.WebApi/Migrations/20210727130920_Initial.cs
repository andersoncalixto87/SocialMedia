using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialMedia.WebApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbHobby",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRIPTION = table.Column<string>(type: "NVARCHAR(200)", nullable: true),
                    PATH_IMAGE = table.Column<string>(type: "NVARCHAR(200)", nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbHobby", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbUser",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    USERNAME = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    PASSWORD = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    PROFILE_IMAGE = table.Column<string>(type: "nvarchar(300)", nullable: true),
                    COVER_IMAGE = table.Column<string>(type: "nvarchar(300)", nullable: true),
                    BIO = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    ISPRIVATE = table.Column<bool>(type: "bit", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbUser", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbPost",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRIPTION = table.Column<string>(type: "NVARCHAR(200)", nullable: true),
                    IMAGE = table.Column<string>(type: "NVARCHAR(200)", nullable: false),
                    LOCATION = table.Column<string>(type: "NVARCHAR(200)", nullable: true),
                    PRIVACY = table.Column<int>(type: "int", nullable: false),
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbPost", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tbPost_tbUser_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "tbUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "tbUserDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CURRENT_CITY = table.Column<string>(type: "NVARCHAR(200)", nullable: true),
                    HOMETOWN = table.Column<string>(type: "NVARCHAR(200)", nullable: true),
                    RELATIONSHIP = table.Column<int>(type: "int", nullable: false),
                    WORK_COMPANY = table.Column<string>(type: "NVARCHAR(200)", nullable: true),
                    JOB_TITLE = table.Column<string>(type: "NVARCHAR(200)", nullable: true),
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbUserDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tbUserDetails_tbUser_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "tbUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "tbUserHobby",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    HOBBY_ID = table.Column<int>(type: "int", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbUserHobby", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tbUserHobby_tbHobby_HOBBY_ID",
                        column: x => x.HOBBY_ID,
                        principalTable: "tbHobby",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_tbUserHobby_tbUser_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "tbUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "tbUserLink",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRIPTION = table.Column<string>(type: "NVARCHAR(200)", nullable: false),
                    LINK_TYPE = table.Column<int>(type: "int", nullable: false),
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbUserLink", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tbUserLink_tbUser_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "tbUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "tbComment",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    POST_ID = table.Column<int>(type: "int", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbComment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tbComment_tbPost_POST_ID",
                        column: x => x.POST_ID,
                        principalTable: "tbPost",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_tbComment_tbUser_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "tbUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "tbPostLike",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    POST_ID = table.Column<int>(type: "int", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbPostLike", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tbPostLike_tbPost_POST_ID",
                        column: x => x.POST_ID,
                        principalTable: "tbPost",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_tbPostLike_tbUser_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "tbUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "tbCommentLike",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    COMMENT_ID = table.Column<int>(type: "int", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCommentLike", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tbCommentLike_tbComment_COMMENT_ID",
                        column: x => x.COMMENT_ID,
                        principalTable: "tbComment",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_tbCommentLike_tbUser_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "tbUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbComment_POST_ID",
                table: "tbComment",
                column: "POST_ID");

            migrationBuilder.CreateIndex(
                name: "IX_tbComment_USER_ID",
                table: "tbComment",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_tbCommentLike_COMMENT_ID",
                table: "tbCommentLike",
                column: "COMMENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_tbCommentLike_USER_ID",
                table: "tbCommentLike",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_tbPost_USER_ID",
                table: "tbPost",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_tbPostLike_POST_ID",
                table: "tbPostLike",
                column: "POST_ID");

            migrationBuilder.CreateIndex(
                name: "IX_tbPostLike_USER_ID",
                table: "tbPostLike",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_tbUserDetails_USER_ID",
                table: "tbUserDetails",
                column: "USER_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbUserHobby_HOBBY_ID",
                table: "tbUserHobby",
                column: "HOBBY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_tbUserHobby_USER_ID",
                table: "tbUserHobby",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_tbUserLink_USER_ID",
                table: "tbUserLink",
                column: "USER_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbCommentLike");

            migrationBuilder.DropTable(
                name: "tbPostLike");

            migrationBuilder.DropTable(
                name: "tbUserDetails");

            migrationBuilder.DropTable(
                name: "tbUserHobby");

            migrationBuilder.DropTable(
                name: "tbUserLink");

            migrationBuilder.DropTable(
                name: "tbComment");

            migrationBuilder.DropTable(
                name: "tbHobby");

            migrationBuilder.DropTable(
                name: "tbPost");

            migrationBuilder.DropTable(
                name: "tbUser");
        }
    }
}
