using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "Effort", "Name" },
                values: new object[,]
                {
                    { new Guid("33c4d656-65f3-420b-b25f-0657f73e6e54"), null, 10, "Academy Activities" },
                    { new Guid("df89da86-0ce8-4865-85ed-cdd55b127c54"), null, 7, "Job Activities" }
                });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskId", "CategoryId", "Date", "DateToEnd", "Description", "TaskPriority", "Title" },
                values: new object[,]
                {
                    { new Guid("56ba4700-16a4-44d8-a610-feb9fec0f0b7"), new Guid("df89da86-0ce8-4865-85ed-cdd55b127c54"), new DateTime(2024, 5, 22, 1, 43, 31, 763, DateTimeKind.Utc).AddTicks(4271), null, "Update all COOSALUD apps", 1, "Update COOSALUD" },
                    { new Guid("ba8cbb16-7c89-4cd5-9495-c46febda8215"), new Guid("33c4d656-65f3-420b-b25f-0657f73e6e54"), new DateTime(2024, 5, 22, 1, 43, 31, 763, DateTimeKind.Utc).AddTicks(4266), null, "Study English with Platzi until to be bilingual", 2, "Study English" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("56ba4700-16a4-44d8-a610-feb9fec0f0b7"));

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("ba8cbb16-7c89-4cd5-9495-c46febda8215"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("33c4d656-65f3-420b-b25f-0657f73e6e54"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("df89da86-0ce8-4865-85ed-cdd55b127c54"));
        }
    }
}
