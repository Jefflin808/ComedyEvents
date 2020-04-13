using Microsoft.EntityFrameworkCore.Migrations;

namespace ComedyEvents.Migrations
{
    public partial class FixErrorInIntialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gig_Comdians_ComedianId",
                table: "Gig");

            migrationBuilder.DropForeignKey(
                name: "FK_Gig_Events_EventId",
                table: "Gig");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gig",
                table: "Gig");

            migrationBuilder.RenameTable(
                name: "Gig",
                newName: "Gigs");

            migrationBuilder.RenameColumn(
                name: "Zipcode",
                table: "Venues",
                newName: "ZipCode");

            migrationBuilder.RenameColumn(
                name: "FristName",
                table: "Comdians",
                newName: "FirstName");

            migrationBuilder.RenameIndex(
                name: "IX_Gig_EventId",
                table: "Gigs",
                newName: "IX_Gigs_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_Gig_ComedianId",
                table: "Gigs",
                newName: "IX_Gigs_ComedianId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gigs",
                table: "Gigs",
                column: "GigId");

            migrationBuilder.UpdateData(
                table: "Comdians",
                keyColumn: "ComedianId",
                keyValue: 1,
                column: "FirstName",
                value: "Pavol");

            migrationBuilder.UpdateData(
                table: "Comdians",
                keyColumn: "ComedianId",
                keyValue: 2,
                column: "FirstName",
                value: "Robin");

            migrationBuilder.UpdateData(
                table: "Venues",
                keyColumn: "VenueId",
                keyValue: 1,
                column: "ZipCode",
                value: "18702");

            migrationBuilder.AddForeignKey(
                name: "FK_Gigs_Comdians_ComedianId",
                table: "Gigs",
                column: "ComedianId",
                principalTable: "Comdians",
                principalColumn: "ComedianId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Gigs_Events_EventId",
                table: "Gigs",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gigs_Comdians_ComedianId",
                table: "Gigs");

            migrationBuilder.DropForeignKey(
                name: "FK_Gigs_Events_EventId",
                table: "Gigs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gigs",
                table: "Gigs");

            migrationBuilder.RenameTable(
                name: "Gigs",
                newName: "Gig");

            migrationBuilder.RenameColumn(
                name: "ZipCode",
                table: "Venues",
                newName: "Zipcode");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Comdians",
                newName: "FristName");

            migrationBuilder.RenameIndex(
                name: "IX_Gigs_EventId",
                table: "Gig",
                newName: "IX_Gig_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_Gigs_ComedianId",
                table: "Gig",
                newName: "IX_Gig_ComedianId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gig",
                table: "Gig",
                column: "GigId");

            migrationBuilder.UpdateData(
                table: "Comdians",
                keyColumn: "ComedianId",
                keyValue: 1,
                column: "FristName",
                value: null);

            migrationBuilder.UpdateData(
                table: "Comdians",
                keyColumn: "ComedianId",
                keyValue: 2,
                column: "FristName",
                value: null);

            migrationBuilder.UpdateData(
                table: "Venues",
                keyColumn: "VenueId",
                keyValue: 1,
                column: "Zipcode",
                value: null);

            migrationBuilder.AddForeignKey(
                name: "FK_Gig_Comdians_ComedianId",
                table: "Gig",
                column: "ComedianId",
                principalTable: "Comdians",
                principalColumn: "ComedianId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Gig_Events_EventId",
                table: "Gig",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
