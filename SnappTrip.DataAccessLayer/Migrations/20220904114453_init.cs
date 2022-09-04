using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SnappTrip.DataAccessLayer.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FixedDisplacementAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    PercentageDisplacementAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    MaximumDisplacementAmount = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rules",
                columns: table => new
                {
                    ID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    RuleType = table.Column<int>(type: "INTEGER", nullable: false),
                    ActionId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rules", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Rules_Actions_ActionId",
                        column: x => x.ActionId,
                        principalTable: "Actions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Conditions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ConditionType = table.Column<int>(type: "INTEGER", nullable: false),
                    ConditionValue = table.Column<int>(type: "INTEGER", nullable: false),
                    RuleId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conditions_Rules_RuleId",
                        column: x => x.RuleId,
                        principalTable: "Rules",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Actions",
                columns: new[] { "Id", "FixedDisplacementAmount", "MaximumDisplacementAmount", "PercentageDisplacementAmount" },
                values: new object[] { 3331L, 20000m, 25500m, 10m });

            migrationBuilder.InsertData(
                table: "Actions",
                columns: new[] { "Id", "FixedDisplacementAmount", "MaximumDisplacementAmount", "PercentageDisplacementAmount" },
                values: new object[] { 3332L, 10000m, 20000m, 5m });

            migrationBuilder.InsertData(
                table: "Actions",
                columns: new[] { "Id", "FixedDisplacementAmount", "MaximumDisplacementAmount", "PercentageDisplacementAmount" },
                values: new object[] { 3333L, 25000m, 40000m, 10m });

            migrationBuilder.InsertData(
                table: "Actions",
                columns: new[] { "Id", "FixedDisplacementAmount", "MaximumDisplacementAmount", "PercentageDisplacementAmount" },
                values: new object[] { 3334L, 1500.25m, 20000.243m, 12.5m });

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

            migrationBuilder.CreateIndex(
                name: "IX_Conditions_RuleId",
                table: "Conditions",
                column: "RuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Rules_ActionId",
                table: "Rules",
                column: "ActionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conditions");

            migrationBuilder.DropTable(
                name: "Rules");

            migrationBuilder.DropTable(
                name: "Actions");
        }
    }
}
