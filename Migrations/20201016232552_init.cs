using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AuslinkOperatingSupport.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientClasses",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientContactPerson = table.Column<string>(nullable: true),
                    ClientContactNumber = table.Column<string>(nullable: true),
                    ClientCompanyName = table.Column<string>(nullable: false),
                    ClientRateSheetID = table.Column<string>(nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientClasses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ContainerClasses",
                columns: table => new
                {
                    ContainerNumber = table.Column<string>(nullable: false),
                    OceanFreightETA = table.Column<DateTime>(nullable: false),
                    TimeToYard = table.Column<DateTime>(nullable: false),
                    ClientCompanyName = table.Column<string>(nullable: false),
                    HandlerName = table.Column<string>(nullable: false),
                    IfCartageOnly = table.Column<bool>(nullable: false),
                    IfRequireDelivery = table.Column<bool>(nullable: false),
                    IfRequireStorage = table.Column<bool>(nullable: false),
                    IfBookedCartage = table.Column<bool>(nullable: false),
                    IfEnteredCartonCloud = table.Column<bool>(nullable: false),
                    ChargeFrom = table.Column<string>(nullable: true),
                    IfExtraLeg = table.Column<bool>(nullable: false),
                    IfInvoiced = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContainerClasses", x => x.ContainerNumber);
                });

            migrationBuilder.CreateTable(
                name: "staff_Classes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false),
                    MobileNumber = table.Column<string>(nullable: true),
                    AuthorityLevel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_staff_Classes", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientClasses");

            migrationBuilder.DropTable(
                name: "ContainerClasses");

            migrationBuilder.DropTable(
                name: "staff_Classes");
        }
    }
}
