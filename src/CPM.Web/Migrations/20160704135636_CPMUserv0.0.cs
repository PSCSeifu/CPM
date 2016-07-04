using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CPM.Web.Migrations
{
    public partial class CPMUserv00 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    cpmAnalytics = table.Column<bool>(nullable: true),
                    cpmAutoBargain = table.Column<bool>(nullable: true),
                    cpmEscrow = table.Column<bool>(nullable: true),
                    cpmForum = table.Column<bool>(nullable: true),
                    cpmModerate = table.Column<bool>(nullable: true),
                    cpmNews = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CPMUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Actions = table.Column<string>(nullable: true),
                    AgreedOnTerms = table.Column<bool>(nullable: true),
                    CanReadEmails = table.Column<bool>(nullable: true),
                    CheckIsUsedBefore = table.Column<bool>(nullable: true),
                    ClientId = table.Column<int>(nullable: true),
                    DateRegistered = table.Column<DateTime>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    ExpiryDate = table.Column<DateTime>(nullable: true),
                    LastSawMessage = table.Column<DateTime>(nullable: true),
                    LoginAttempts = table.Column<int>(nullable: true),
                    Password2 = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    PasswordStrength = table.Column<int>(nullable: true),
                    PreviousPasswords = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Suspended = table.Column<bool>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    WebUserType = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPMUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MarketCap = table.Column<decimal>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Offer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientId = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DefaultCurrencyId = table.Column<int>(nullable: true),
                    Detail = table.Column<string>(nullable: true),
                    ExpiryDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    WalletId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wallet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Balance = table.Column<decimal>(nullable: false),
                    ClientId = table.Column<int>(nullable: false),
                    Currency = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    DeleteDate = table.Column<DateTime>(nullable: true),
                    ImageId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: true),
                    IsLocked = table.Column<bool>(nullable: false),
                    LockOnNotificationLimit = table.Column<bool>(nullable: false),
                    LockOnSpendLimit = table.Column<bool>(nullable: false),
                    LockOnWithdrawLimit = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NotificationLimit = table.Column<decimal>(nullable: false),
                    SpendLimit = table.Column<decimal>(nullable: false),
                    WalletTypeId = table.Column<int>(nullable: true),
                    WithdrawLimit = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WalletType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Category = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalletType", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "CPMUsers");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "Offer");

            migrationBuilder.DropTable(
                name: "Wallet");

            migrationBuilder.DropTable(
                name: "WalletType");
        }
    }
}
