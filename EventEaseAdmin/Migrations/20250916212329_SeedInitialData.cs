using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventEaseAdmin.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Email", "FullName", "Organization", "Phone" },
                values: new object[,]
                {
                    { 1L, "alice@example.com", "Alice Smith", "Acme Corp", "123-456-7890" },
                    { 2L, "bob@example.com", "Bob Johnson", "Beta LLC", "234-567-8901" },
                    { 3L, "carol@example.com", "Carol Lee", "Gamma Inc", "345-678-9012" }
                });

            migrationBuilder.InsertData(
                table: "Venues",
                columns: new[] { "VenueId", "Capacity", "ImageUrl", "IsActive", "Location", "VenueName" },
                values: new object[,]
                {
                    { 1L, 500, null, true, "123 Main St", "Grand Hall" },
                    { 2L, 200, null, true, "456 Elm St", "Conference Center" },
                    { 3L, 1000, null, false, "789 Oak St", "Open Air Arena" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "CustomerId", "Description", "EndAt", "EventDate", "EventName", "StartAt", "VenueId" },
                values: new object[,]
                {
                    { 1L, 1L, "Annual technology expo.", null, new DateTime(2025, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tech Expo", null, 1L },
                    { 2L, 2L, "Business leaders summit.", null, new DateTime(2025, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Business Summit", null, 2L },
                    { 3L, 3L, "Outdoor music festival.", null, new DateTime(2025, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Music Festival", null, 3L }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "BookingId", "BookingDate", "EndAt", "EventId", "StartAt", "Status", "VenueId" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 10, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), "Confirmed", 1L },
                    { new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2025, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 15, 18, 0, 0, 0, DateTimeKind.Unspecified), 2L, new DateTime(2025, 11, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), "Pending", 2L },
                    { new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 5, 23, 0, 0, 0, DateTimeKind.Unspecified), 3L, new DateTime(2025, 12, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), "Cancelled", 3L }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Venues",
                keyColumn: "VenueId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Venues",
                keyColumn: "VenueId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Venues",
                keyColumn: "VenueId",
                keyValue: 3L);
        }
    }
}
