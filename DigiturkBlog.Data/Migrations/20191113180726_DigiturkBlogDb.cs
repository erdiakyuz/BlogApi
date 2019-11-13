using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DigiturkBlog.Data.Migrations
{
    public partial class DigiturkBlogDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    About = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AuthorId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    PublishedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArticleTag",
                columns: table => new
                {
                    ArticleId = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleTag", x => new { x.TagId, x.ArticleId });
                    table.ForeignKey(
                        name: "FK_ArticleTag_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleTag_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "About", "Email", "FirstName", "IsActive", "LastName" },
                values: new object[,]
                {
                    { 2, "DummyAbout", "xxx@vvv.com", "Misaki", true, "Taro" },
                    { 1, "DummyAbout", "xxx@vvv.com", "Tsubasa", true, "Ozora" },
                    { 3, "DummyAbout", "xxx@vvv.com", "Jun", true, "Misugi" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Fiction" },
                    { 2, "Technology" },
                    { 3, "Art" }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "AuthorId", "Content", "IsActive", "ModifiedDate", "PublishedDate", "Title" },
                values: new object[] { 2, 2, "Lorem ipsum dolor sit amed.", true, new DateTime(2019, 11, 13, 21, 7, 26, 328, DateTimeKind.Local).AddTicks(5329), new DateTime(2019, 11, 13, 21, 7, 26, 328, DateTimeKind.Local).AddTicks(5324), "C# Movie" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "AuthorId", "Content", "IsActive", "ModifiedDate", "PublishedDate", "Title" },
                values: new object[] { 1, 1, "Lorem ipsum dolor sit amed.", true, new DateTime(2019, 11, 13, 21, 7, 26, 328, DateTimeKind.Local).AddTicks(3567), new DateTime(2019, 11, 13, 21, 7, 26, 327, DateTimeKind.Local).AddTicks(5848), "What is Art-Fiction" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "AuthorId", "Content", "IsActive", "ModifiedDate", "PublishedDate", "Title" },
                values: new object[] { 3, 3, "Lorem ipsum dolor sit amed.", true, new DateTime(2019, 11, 13, 21, 7, 26, 328, DateTimeKind.Local).AddTicks(5354), new DateTime(2019, 11, 13, 21, 7, 26, 328, DateTimeKind.Local).AddTicks(5354), "Terminator" });

            migrationBuilder.InsertData(
                table: "ArticleTag",
                columns: new[] { "TagId", "ArticleId" },
                values: new object[,]
                {
                    { 2, 2 },
                    { 3, 2 },
                    { 1, 1 },
                    { 3, 1 },
                    { 3, 3 },
                    { 2, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_AuthorId",
                table: "Articles",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleTag_ArticleId",
                table: "ArticleTag",
                column: "ArticleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleTag");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
