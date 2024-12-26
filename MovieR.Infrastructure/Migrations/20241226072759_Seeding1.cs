using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieR.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Seeding1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "DurationMinutes", "Genre", "PosterUrl", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("20f25861-875d-451f-a01e-b6f314ff5903"), "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.", 0, "", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Godfather" },
                    { new Guid("384478fd-4977-4ce0-957b-d61d5d7b3382"), "The Dark Knight of Gotham City begins his war on crime with his first major enemy being Jack Napier, a criminal who becomes the clownishly homicidal Joker.", 0, "", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Batman" },
                    { new Guid("42481c16-ba8b-411a-85a8-ad501d590e68"), "Two imprisoned", 0, "", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Shawshank Redemption" },
                    { new Guid("9264d67b-d0f0-445d-809c-85836bf67d7d"), "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.", 0, "", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pulp Fiction" },
                    { new Guid("d093ed54-63b8-47c1-b1d5-dae702251a00"), "Gandalf and Aragorn lead the World", 0, "", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Lord of the Rings: The Return of the King" },
                    { new Guid("f8d47660-d885-4f08-b4f9-bf0ab53a0126"), "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.", 0, "", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Dark Knight" }
                });

            migrationBuilder.InsertData(
                table: "ScreeningRooms",
                columns: new[] { "Id", "Name", "TotalColumns", "TotalRows" },
                values: new object[,]
                {
                    { new Guid("055fdb73-0ce5-4f01-978c-98bac173c138"), "Sál 2", 8, 20 },
                    { new Guid("083c2b00-0231-4830-9a9c-f32b7f2e69dc"), "Sál 1", 10, 10 },
                    { new Guid("276fa985-ea6c-45a6-b2b9-c8e25ce769c9"), "Sál 5", 10, 10 },
                    { new Guid("3a6ca45b-b2a0-4c5f-b429-7f679e5eeb37"), "Sál 3", 12, 15 },
                    { new Guid("b9a0ee62-76e2-43f5-b737-a91878edc345"), "Sál 4", 15, 15 }
                });

            migrationBuilder.InsertData(
                table: "Screenings",
                columns: new[] { "Id", "MovieId", "ScreeningRoomId", "StartDate" },
                values: new object[,]
                {
                    { new Guid("0b408efd-e6a7-4893-804f-16544b51aaf3"), new Guid("20f25861-875d-451f-a01e-b6f314ff5903"), new Guid("055fdb73-0ce5-4f01-978c-98bac173c138"), new DateTime(2024, 12, 28, 8, 27, 59, 568, DateTimeKind.Local).AddTicks(9880) },
                    { new Guid("21856b39-b297-4e25-9dba-ae6347895925"), new Guid("42481c16-ba8b-411a-85a8-ad501d590e68"), new Guid("083c2b00-0231-4830-9a9c-f32b7f2e69dc"), new DateTime(2024, 12, 27, 8, 27, 59, 568, DateTimeKind.Local).AddTicks(9790) },
                    { new Guid("7c9aa09a-8c98-45d1-ac09-e22c4adaf9fe"), new Guid("f8d47660-d885-4f08-b4f9-bf0ab53a0126"), new Guid("3a6ca45b-b2a0-4c5f-b429-7f679e5eeb37"), new DateTime(2024, 12, 29, 8, 27, 59, 568, DateTimeKind.Local).AddTicks(9880) },
                    { new Guid("a6fdbd45-df69-4878-be9e-c8771870e920"), new Guid("9264d67b-d0f0-445d-809c-85836bf67d7d"), new Guid("083c2b00-0231-4830-9a9c-f32b7f2e69dc"), new DateTime(2025, 1, 1, 8, 27, 59, 568, DateTimeKind.Local).AddTicks(9910) },
                    { new Guid("e7009a77-90a8-4985-9703-18b9301ed304"), new Guid("384478fd-4977-4ce0-957b-d61d5d7b3382"), new Guid("b9a0ee62-76e2-43f5-b737-a91878edc345"), new DateTime(2024, 12, 30, 8, 27, 59, 568, DateTimeKind.Local).AddTicks(9890) },
                    { new Guid("f1fa3844-28b5-47ed-9dbe-5670d0b49799"), new Guid("d093ed54-63b8-47c1-b1d5-dae702251a00"), new Guid("276fa985-ea6c-45a6-b2b9-c8e25ce769c9"), new DateTime(2024, 12, 31, 8, 27, 59, 568, DateTimeKind.Local).AddTicks(9900) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: new Guid("0b408efd-e6a7-4893-804f-16544b51aaf3"));

            migrationBuilder.DeleteData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: new Guid("21856b39-b297-4e25-9dba-ae6347895925"));

            migrationBuilder.DeleteData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: new Guid("7c9aa09a-8c98-45d1-ac09-e22c4adaf9fe"));

            migrationBuilder.DeleteData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: new Guid("a6fdbd45-df69-4878-be9e-c8771870e920"));

            migrationBuilder.DeleteData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: new Guid("e7009a77-90a8-4985-9703-18b9301ed304"));

            migrationBuilder.DeleteData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: new Guid("f1fa3844-28b5-47ed-9dbe-5670d0b49799"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("20f25861-875d-451f-a01e-b6f314ff5903"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("384478fd-4977-4ce0-957b-d61d5d7b3382"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("42481c16-ba8b-411a-85a8-ad501d590e68"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("9264d67b-d0f0-445d-809c-85836bf67d7d"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("d093ed54-63b8-47c1-b1d5-dae702251a00"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("f8d47660-d885-4f08-b4f9-bf0ab53a0126"));

            migrationBuilder.DeleteData(
                table: "ScreeningRooms",
                keyColumn: "Id",
                keyValue: new Guid("055fdb73-0ce5-4f01-978c-98bac173c138"));

            migrationBuilder.DeleteData(
                table: "ScreeningRooms",
                keyColumn: "Id",
                keyValue: new Guid("083c2b00-0231-4830-9a9c-f32b7f2e69dc"));

            migrationBuilder.DeleteData(
                table: "ScreeningRooms",
                keyColumn: "Id",
                keyValue: new Guid("276fa985-ea6c-45a6-b2b9-c8e25ce769c9"));

            migrationBuilder.DeleteData(
                table: "ScreeningRooms",
                keyColumn: "Id",
                keyValue: new Guid("3a6ca45b-b2a0-4c5f-b429-7f679e5eeb37"));

            migrationBuilder.DeleteData(
                table: "ScreeningRooms",
                keyColumn: "Id",
                keyValue: new Guid("b9a0ee62-76e2-43f5-b737-a91878edc345"));
        }
    }
}
