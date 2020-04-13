using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComedyEvents.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comdians",
                columns: table => new
                {
                    ComedianId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FristName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    ContactPhone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comdians", x => x.ComedianId);
                });

            migrationBuilder.CreateTable(
                name: "Venues",
                columns: table => new
                {
                    VenueId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VenueName = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Zipcode = table.Column<string>(nullable: true),
                    Seating = table.Column<int>(nullable: false),
                    ServesAlcohol = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venues", x => x.VenueId);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EventName = table.Column<string>(nullable: true),
                    EventDate = table.Column<DateTime>(nullable: false),
                    VenueId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Events_Venues_VenueId",
                        column: x => x.VenueId,
                        principalTable: "Venues",
                        principalColumn: "VenueId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Gig",
                columns: table => new
                {
                    GigId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GigHeadline = table.Column<string>(nullable: true),
                    GigLengthInMinutes = table.Column<int>(nullable: false),
                    EventId = table.Column<int>(nullable: true),
                    ComedianId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gig", x => x.GigId);
                    table.ForeignKey(
                        name: "FK_Gig_Comdians_ComedianId",
                        column: x => x.ComedianId,
                        principalTable: "Comdians",
                        principalColumn: "ComedianId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Gig_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Comdians",
                columns: new[] { "ComedianId", "ContactPhone", "FristName", "LastName" },
                values: new object[] { 1, "111-222-333", null, "Almasi" });

            migrationBuilder.InsertData(
                table: "Comdians",
                columns: new[] { "ComedianId", "ContactPhone", "FristName", "LastName" },
                values: new object[] { 2, "444-555-666", null, "Williams" });

            migrationBuilder.InsertData(
                table: "Venues",
                columns: new[] { "VenueId", "City", "Seating", "ServesAlcohol", "State", "Street", "VenueName", "Zipcode" },
                values: new object[] { 1, "Wilkes Barre", 125, true, "PA", "123 Main Street", "Mohegan Sun", null });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "EventDate", "EventName", "VenueId" },
                values: new object[] { 1, new DateTime(2019, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Funny Comedy Night", 1 });

            migrationBuilder.InsertData(
                table: "Gig",
                columns: new[] { "GigId", "ComedianId", "EventId", "GigHeadline", "GigLengthInMinutes" },
                values: new object[] { 1, 1, 1, "Pavols Funny Show", 60 });

            migrationBuilder.InsertData(
                table: "Gig",
                columns: new[] { "GigId", "ComedianId", "EventId", "GigHeadline", "GigLengthInMinutes" },
                values: new object[] { 2, 2, 1, "Lifetime Of Fun", 45 });

            migrationBuilder.CreateIndex(
                name: "IX_Events_VenueId",
                table: "Events",
                column: "VenueId");

            migrationBuilder.CreateIndex(
                name: "IX_Gig_ComedianId",
                table: "Gig",
                column: "ComedianId");

            migrationBuilder.CreateIndex(
                name: "IX_Gig_EventId",
                table: "Gig",
                column: "EventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gig");

            migrationBuilder.DropTable(
                name: "Comdians");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Venues");
        }
    }
}
