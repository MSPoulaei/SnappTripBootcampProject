using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SnappTrip.DataAccessLayer.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Actions",
                columns: new[] { "Id", "FixedDisplacementAmount", "MaximumDisplacementAmount", "PercentageDisplacementAmount" },
                values: new object[,]
                {
                    { 3331L, 20000m, 25500m, 10m },
                    { 3332L, 10000m, 20000m, 5m },
                    { 3333L, 25000m, 40000m, 10m },
                    { 3334L, 1500.25m, 20000.243m, 12.5m }
                });

            migrationBuilder.InsertData(
                table: "Rules",
                columns: new[] { "ID", "ActionId", "Name", "RuleType" },
                values: new object[] { 2000L, 3331L, "کاربر b2b", 0 });

            migrationBuilder.InsertData(
                table: "Rules",
                columns: new[] { "ID", "ActionId", "Name", "RuleType" },
                values: new object[] { 2001L, 3334L, "کاربر b2c", 1 });

            migrationBuilder.InsertData(
                table: "Conditions",
                columns: new[] { "Id", "ConditionType", "ConditionValue", "RuleId" },
                values: new object[] { 1000L, 0, 0, 2000L });

            migrationBuilder.InsertData(
                table: "Conditions",
                columns: new[] { "Id", "ConditionType", "ConditionValue", "RuleId" },
                values: new object[] { 1001L, 0, 1, 2001L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Actions",
                keyColumn: "Id",
                keyValue: 3332L);

            migrationBuilder.DeleteData(
                table: "Actions",
                keyColumn: "Id",
                keyValue: 3333L);

            migrationBuilder.DeleteData(
                table: "Conditions",
                keyColumn: "Id",
                keyValue: 1000L);

            migrationBuilder.DeleteData(
                table: "Conditions",
                keyColumn: "Id",
                keyValue: 1001L);

            migrationBuilder.DeleteData(
                table: "Rules",
                keyColumn: "ID",
                keyValue: 2000L);

            migrationBuilder.DeleteData(
                table: "Rules",
                keyColumn: "ID",
                keyValue: 2001L);

            migrationBuilder.DeleteData(
                table: "Actions",
                keyColumn: "Id",
                keyValue: 3331L);

            migrationBuilder.DeleteData(
                table: "Actions",
                keyColumn: "Id",
                keyValue: 3334L);
        }
    }
}
