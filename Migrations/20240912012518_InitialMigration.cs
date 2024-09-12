using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Rare_BE.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Bio = table.Column<string>(type: "text", nullable: false),
                    ImageURL = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AuthorId = table.Column<int>(type: "integer", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    PublicationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ImageURL = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posts_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FollowerId = table.Column<int>(type: "integer", nullable: false),
                    AuthorId = table.Column<int>(type: "integer", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AuthorId = table.Column<int>(type: "integer", nullable: false),
                    PostId = table.Column<int>(type: "integer", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostTag",
                columns: table => new
                {
                    PostsId = table.Column<int>(type: "integer", nullable: false),
                    TagsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTag", x => new { x.PostsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_PostTag_Posts_PostsId",
                        column: x => x.PostsId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Label" },
                values: new object[,]
                {
                    { 1, "Drama" },
                    { 2, "Arts" },
                    { 3, "Technology" },
                    { 4, "Astronomy" },
                    { 5, "Science" },
                    { 6, "Sci-Fi" },
                    { 7, "Fanfic" },
                    { 8, "Music" },
                    { 9, "Business" },
                    { 10, "Health" },
                    { 11, "Travel" },
                    { 12, "Politics" },
                    { 13, "Sports" },
                    { 14, "Culture" },
                    { 15, "Food" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Label" },
                values: new object[,]
                {
                    { 1, "America" },
                    { 2, "Olympics" },
                    { 3, "Election" },
                    { 4, "Budget" },
                    { 5, "Fusion" },
                    { 6, "Moscow" },
                    { 7, "Europe" },
                    { 8, "Opinion" },
                    { 9, "Currency" },
                    { 10, "Gardening" },
                    { 11, "Parenthood" },
                    { 12, "DIY" },
                    { 13, "Bird Beaks <>" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Bio", "CreatedOn", "Email", "FirstName", "ImageURL", "LastName", "Uid" },
                values: new object[,]
                {
                    { 1, "Now deceased but still at it.", new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "whosafraid@me.com", "Virginia", "", "Woolf", null },
                    { 2, "Local weatherman turned vigilante techno DJ", new DateTime(2019, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "alexjones@gmail.com", "Alex", "", "Jones", null },
                    { 3, "Shoulda bought Apple", new DateTime(1998, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "funkyfrog@yahoo.com", "Taylor", "", "Harrison", null },
                    { 4, "I'm watching anime", new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "lastnamejoseph@aol.com", "Odie", "", "Dicaprio", null },
                    { 5, "Born in 1955, Quincy Quayle grew up in the city of New Mammoth, Montana. He is predeceased by carnival employees Jack and Barbara. No relation.", new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "notdan@notdan.com", "Quincy", "", "Quayle", null }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "CategoryId", "Content", "ImageURL", "PublicationDate", "Title" },
                values: new object[,]
                {
                    { 1, 1, 2, "Mr. Bennett says that it is only if the characters are real that the novel has any chance of surviving. Otherwise, die it must. But, I ask myself, what is reality? And who are the judges of reality?", "", new DateTime(2024, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mr. Bennett and Mrs. Brown" },
                    { 2, 3, 10, "A young frog named Freddie struggles with a seemingly simple task: tying his shoes. Despite his best efforts and the helpful advice from his friends, Freddie's frustration grows as he faces a series of amusing mishaps. Ultimately, Freddie learns that perseverance and a bit of creativity can turn even the most challenging problems into opportunities for growth and friendship.", "", new DateTime(2008, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Frog That Couldn't Tie His Shoes" },
                    { 3, 5, 11, "A curious young cat named Sparky embarks on a thrilling adventure to the distant city of Timbuktu. Along the way, Sparky encounters exotic landscapes, befriends fascinating characters, and uncovers the rich cultural tapestry of the region. Through his journey, Sparky discovers that true adventure lies not just in new places, but in the friendships and experiences that shape his path.", "", new DateTime(2024, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sparky Goes to Timbuktu" },
                    { 4, 5, 6, "Set in a post-apocalyptic world where humans have vanished, the remaining wildlife faces a mysterious crisis: birds are evolving with deformed beaks, threatening their survival. A clever raven named Rook teams up with a resourceful squirrel named Nutmeg to investigate the cause of this anomaly. As they unravel the clues, they discover that the key to restoring balance lies in a hidden human artifact, leading them on a perilous journey to save their world from impending chaos.", "", new DateTime(2024, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Bird Beak Conundrum" }
                });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "AuthorId", "CreatedOn", "EndedOn", "FollowerId" },
                values: new object[,]
                {
                    { 1, 4, new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1 },
                    { 2, 4, new DateTime(2024, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3 },
                    { 3, 4, new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5 },
                    { 4, 2, new DateTime(2024, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1 },
                    { 5, 5, new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 6, 5, new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedOn", "PostId" },
                values: new object[,]
                {
                    { 1, 4, "Sounds like a good anime", new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 2, 5, "Pitching it to Warner Brothers!", new DateTime(2024, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AuthorId",
                table: "Comments",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AuthorId",
                table: "Posts",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTag_TagsId",
                table: "PostTag",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_AuthorId",
                table: "Subscriptions",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "PostTag");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
