using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieR.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedingToSeats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: new Guid("230465b8-7d79-4896-8dc4-3052b5a3c26f"));

            migrationBuilder.DeleteData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: new Guid("3dae973d-0b08-46af-b7fc-81af3d5ef5f2"));

            migrationBuilder.DeleteData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: new Guid("9684e9b8-b0c1-4bf1-a723-bc46d49ccd38"));

            migrationBuilder.DeleteData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: new Guid("af47403c-e5d5-4349-a284-a7963d699ba1"));

            migrationBuilder.DeleteData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: new Guid("efe9e384-3001-442d-8d3e-12507a3e5a69"));

            migrationBuilder.DeleteData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: new Guid("fb98a14b-5eed-4d4b-b2f4-f343c3f149d0"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("12f609a6-ab4d-42a3-b69a-5b0db8ec8b6b"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("159e6bb1-c185-40bc-b3a2-9c2e67c4a560"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("1e82459e-256e-435d-a1ce-55e4d7845cfc"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("44e69150-fdfa-49a1-8315-d1229be86fc1"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("53bda430-eee8-4c80-b9b4-28a10023e0fd"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("ed0a3434-eb40-4c48-9093-b605f40ddac5"));

            migrationBuilder.DeleteData(
                table: "ScreeningRooms",
                keyColumn: "Id",
                keyValue: new Guid("0dc407d3-e93c-44a0-bcdb-8e41bb3de2c1"));

            migrationBuilder.DeleteData(
                table: "ScreeningRooms",
                keyColumn: "Id",
                keyValue: new Guid("35de9145-3fb4-4694-82d1-8b0add1a5b3b"));

            migrationBuilder.DeleteData(
                table: "ScreeningRooms",
                keyColumn: "Id",
                keyValue: new Guid("552cd46a-266c-42cb-8410-03a9ee547f8d"));

            migrationBuilder.DeleteData(
                table: "ScreeningRooms",
                keyColumn: "Id",
                keyValue: new Guid("c59538e7-5888-452b-b6f2-8005be22e5f7"));

            migrationBuilder.DeleteData(
                table: "ScreeningRooms",
                keyColumn: "Id",
                keyValue: new Guid("dae06b3c-e812-429c-981f-18929cafa048"));

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "DurationMinutes", "Genre", "PosterUrl", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("1f9284eb-afa1-4372-9fe7-23adcf42fc7a"), "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.", 0, "", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Godfather" },
                    { new Guid("23c42bb7-09c9-45e0-8bd3-16b3036ab934"), "Gandalf and Aragorn lead the World", 0, "", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Lord of the Rings: The Return of the King" },
                    { new Guid("2612a288-156a-49e3-8d40-09a00330cb3a"), "Two imprisoned", 0, "", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Shawshank Redemption" },
                    { new Guid("2710da4d-ffe9-4e5b-bdaf-b3843fa3c6b0"), "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.", 0, "", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pulp Fiction" },
                    { new Guid("39544054-30a8-4e5f-a4fd-3dc957c99669"), "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.", 0, "", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Dark Knight" },
                    { new Guid("c6ef9da8-bb4c-4efe-8a93-da6f51f87a1b"), "The Dark Knight of Gotham City begins his war on crime with his first major enemy being Jack Napier, a criminal who becomes the clownishly homicidal Joker.", 0, "", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Batman" }
                });

            migrationBuilder.InsertData(
                table: "ScreeningRooms",
                columns: new[] { "Id", "MaxCapacity", "Name", "TotalColumns", "TotalRows" },
                values: new object[,]
                {
                    { new Guid("04834c6d-5384-487d-8267-f0e0c450c9c6"), 0, "Sál 2", 8, 20 },
                    { new Guid("893a63ad-bb4b-473c-9207-bbb9a16eacfe"), 0, "Sál 5", 10, 10 },
                    { new Guid("9e3364cc-a114-4b60-9c82-adfe2aa7874f"), 0, "Sál 4", 15, 15 },
                    { new Guid("b2297133-7f2c-4965-8e03-ec58d15fa1ac"), 0, "Sál 3", 12, 15 },
                    { new Guid("f8f04731-2eda-41d4-966d-092f1e28eb07"), 0, "Sál 1", 10, 10 }
                });

            migrationBuilder.InsertData(
                table: "Screenings",
                columns: new[] { "Id", "MovieId", "ScreeningRoomId", "StartDate" },
                values: new object[,]
                {
                    { new Guid("40cc3132-00bb-46da-affd-9f62c5275c3b"), new Guid("c6ef9da8-bb4c-4efe-8a93-da6f51f87a1b"), new Guid("9e3364cc-a114-4b60-9c82-adfe2aa7874f"), new DateTime(2025, 1, 1, 8, 38, 2, 169, DateTimeKind.Local).AddTicks(830) },
                    { new Guid("457f6f49-9348-43e6-9fb9-b252dc9a3bb6"), new Guid("39544054-30a8-4e5f-a4fd-3dc957c99669"), new Guid("b2297133-7f2c-4965-8e03-ec58d15fa1ac"), new DateTime(2024, 12, 31, 8, 38, 2, 169, DateTimeKind.Local).AddTicks(830) },
                    { new Guid("92f07277-7ec8-463c-9600-286d41c3b289"), new Guid("23c42bb7-09c9-45e0-8bd3-16b3036ab934"), new Guid("893a63ad-bb4b-473c-9207-bbb9a16eacfe"), new DateTime(2025, 1, 2, 8, 38, 2, 169, DateTimeKind.Local).AddTicks(830) },
                    { new Guid("93a8a0cb-3555-4912-a854-41262759e831"), new Guid("2612a288-156a-49e3-8d40-09a00330cb3a"), new Guid("f8f04731-2eda-41d4-966d-092f1e28eb07"), new DateTime(2024, 12, 29, 8, 38, 2, 169, DateTimeKind.Local).AddTicks(770) },
                    { new Guid("a54717d6-6841-49a2-a7a8-463665cac233"), new Guid("1f9284eb-afa1-4372-9fe7-23adcf42fc7a"), new Guid("04834c6d-5384-487d-8267-f0e0c450c9c6"), new DateTime(2024, 12, 30, 8, 38, 2, 169, DateTimeKind.Local).AddTicks(820) },
                    { new Guid("d5aae6a7-baad-41bb-bd3e-ff56175376d9"), new Guid("2710da4d-ffe9-4e5b-bdaf-b3843fa3c6b0"), new Guid("f8f04731-2eda-41d4-966d-092f1e28eb07"), new DateTime(2025, 1, 3, 8, 38, 2, 169, DateTimeKind.Local).AddTicks(840) }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Column", "IsAvailable", "Row", "ScreeningId" },
                values: new object[,]
                {
                    { new Guid("15133da9-aabb-449a-9f8e-44d38f171e94"), 6, true, 1, new Guid("93a8a0cb-3555-4912-a854-41262759e831") },
                    { new Guid("380711d8-7760-4c21-b638-bbb4e3bcd234"), 5, true, 1, new Guid("93a8a0cb-3555-4912-a854-41262759e831") },
                    { new Guid("49b1fadf-925e-4683-80e0-8c0b5cc65376"), 3, true, 1, new Guid("93a8a0cb-3555-4912-a854-41262759e831") },
                    { new Guid("8f74d1ed-e741-4bb5-a31b-37acccffe6c5"), 2, true, 1, new Guid("93a8a0cb-3555-4912-a854-41262759e831") },
                    { new Guid("9e317427-bbd3-4a45-b418-9ff1284087be"), 4, true, 1, new Guid("93a8a0cb-3555-4912-a854-41262759e831") },
                    { new Guid("a85110e0-97cf-4fe2-9936-6ce87c1408ef"), 1, true, 1, new Guid("93a8a0cb-3555-4912-a854-41262759e831") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: new Guid("40cc3132-00bb-46da-affd-9f62c5275c3b"));

            migrationBuilder.DeleteData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: new Guid("457f6f49-9348-43e6-9fb9-b252dc9a3bb6"));

            migrationBuilder.DeleteData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: new Guid("92f07277-7ec8-463c-9600-286d41c3b289"));

            migrationBuilder.DeleteData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: new Guid("a54717d6-6841-49a2-a7a8-463665cac233"));

            migrationBuilder.DeleteData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: new Guid("d5aae6a7-baad-41bb-bd3e-ff56175376d9"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("15133da9-aabb-449a-9f8e-44d38f171e94"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("380711d8-7760-4c21-b638-bbb4e3bcd234"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("49b1fadf-925e-4683-80e0-8c0b5cc65376"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("8f74d1ed-e741-4bb5-a31b-37acccffe6c5"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("9e317427-bbd3-4a45-b418-9ff1284087be"));

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: new Guid("a85110e0-97cf-4fe2-9936-6ce87c1408ef"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("1f9284eb-afa1-4372-9fe7-23adcf42fc7a"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("23c42bb7-09c9-45e0-8bd3-16b3036ab934"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("2710da4d-ffe9-4e5b-bdaf-b3843fa3c6b0"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("39544054-30a8-4e5f-a4fd-3dc957c99669"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("c6ef9da8-bb4c-4efe-8a93-da6f51f87a1b"));

            migrationBuilder.DeleteData(
                table: "ScreeningRooms",
                keyColumn: "Id",
                keyValue: new Guid("04834c6d-5384-487d-8267-f0e0c450c9c6"));

            migrationBuilder.DeleteData(
                table: "ScreeningRooms",
                keyColumn: "Id",
                keyValue: new Guid("893a63ad-bb4b-473c-9207-bbb9a16eacfe"));

            migrationBuilder.DeleteData(
                table: "ScreeningRooms",
                keyColumn: "Id",
                keyValue: new Guid("9e3364cc-a114-4b60-9c82-adfe2aa7874f"));

            migrationBuilder.DeleteData(
                table: "ScreeningRooms",
                keyColumn: "Id",
                keyValue: new Guid("b2297133-7f2c-4965-8e03-ec58d15fa1ac"));

            migrationBuilder.DeleteData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: new Guid("93a8a0cb-3555-4912-a854-41262759e831"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("2612a288-156a-49e3-8d40-09a00330cb3a"));

            migrationBuilder.DeleteData(
                table: "ScreeningRooms",
                keyColumn: "Id",
                keyValue: new Guid("f8f04731-2eda-41d4-966d-092f1e28eb07"));

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "DurationMinutes", "Genre", "PosterUrl", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("12f609a6-ab4d-42a3-b69a-5b0db8ec8b6b"), "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.", 0, "", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Godfather" },
                    { new Guid("159e6bb1-c185-40bc-b3a2-9c2e67c4a560"), "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.", 0, "", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pulp Fiction" },
                    { new Guid("1e82459e-256e-435d-a1ce-55e4d7845cfc"), "Gandalf and Aragorn lead the World", 0, "", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Lord of the Rings: The Return of the King" },
                    { new Guid("44e69150-fdfa-49a1-8315-d1229be86fc1"), "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.", 0, "", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Dark Knight" },
                    { new Guid("53bda430-eee8-4c80-b9b4-28a10023e0fd"), "Two imprisoned", 0, "", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Shawshank Redemption" },
                    { new Guid("ed0a3434-eb40-4c48-9093-b605f40ddac5"), "The Dark Knight of Gotham City begins his war on crime with his first major enemy being Jack Napier, a criminal who becomes the clownishly homicidal Joker.", 0, "", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Batman" }
                });

            migrationBuilder.InsertData(
                table: "ScreeningRooms",
                columns: new[] { "Id", "MaxCapacity", "Name", "TotalColumns", "TotalRows" },
                values: new object[,]
                {
                    { new Guid("0dc407d3-e93c-44a0-bcdb-8e41bb3de2c1"), 0, "Sál 5", 10, 10 },
                    { new Guid("35de9145-3fb4-4694-82d1-8b0add1a5b3b"), 0, "Sál 1", 10, 10 },
                    { new Guid("552cd46a-266c-42cb-8410-03a9ee547f8d"), 0, "Sál 4", 15, 15 },
                    { new Guid("c59538e7-5888-452b-b6f2-8005be22e5f7"), 0, "Sál 3", 12, 15 },
                    { new Guid("dae06b3c-e812-429c-981f-18929cafa048"), 0, "Sál 2", 8, 20 }
                });

            migrationBuilder.InsertData(
                table: "Screenings",
                columns: new[] { "Id", "MovieId", "ScreeningRoomId", "StartDate" },
                values: new object[,]
                {
                    { new Guid("230465b8-7d79-4896-8dc4-3052b5a3c26f"), new Guid("1e82459e-256e-435d-a1ce-55e4d7845cfc"), new Guid("0dc407d3-e93c-44a0-bcdb-8e41bb3de2c1"), new DateTime(2025, 1, 1, 7, 56, 9, 682, DateTimeKind.Local).AddTicks(820) },
                    { new Guid("3dae973d-0b08-46af-b7fc-81af3d5ef5f2"), new Guid("ed0a3434-eb40-4c48-9093-b605f40ddac5"), new Guid("552cd46a-266c-42cb-8410-03a9ee547f8d"), new DateTime(2024, 12, 31, 7, 56, 9, 682, DateTimeKind.Local).AddTicks(810) },
                    { new Guid("9684e9b8-b0c1-4bf1-a723-bc46d49ccd38"), new Guid("12f609a6-ab4d-42a3-b69a-5b0db8ec8b6b"), new Guid("dae06b3c-e812-429c-981f-18929cafa048"), new DateTime(2024, 12, 29, 7, 56, 9, 682, DateTimeKind.Local).AddTicks(790) },
                    { new Guid("af47403c-e5d5-4349-a284-a7963d699ba1"), new Guid("159e6bb1-c185-40bc-b3a2-9c2e67c4a560"), new Guid("35de9145-3fb4-4694-82d1-8b0add1a5b3b"), new DateTime(2025, 1, 2, 7, 56, 9, 682, DateTimeKind.Local).AddTicks(820) },
                    { new Guid("efe9e384-3001-442d-8d3e-12507a3e5a69"), new Guid("44e69150-fdfa-49a1-8315-d1229be86fc1"), new Guid("c59538e7-5888-452b-b6f2-8005be22e5f7"), new DateTime(2024, 12, 30, 7, 56, 9, 682, DateTimeKind.Local).AddTicks(800) },
                    { new Guid("fb98a14b-5eed-4d4b-b2f4-f343c3f149d0"), new Guid("53bda430-eee8-4c80-b9b4-28a10023e0fd"), new Guid("35de9145-3fb4-4694-82d1-8b0add1a5b3b"), new DateTime(2024, 12, 28, 7, 56, 9, 682, DateTimeKind.Local).AddTicks(740) }
                });
        }
    }
}
