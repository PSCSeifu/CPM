using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CPM.Data.Global.Account;

namespace CPM.Web.Migrations
{
    [DbContext(typeof(CPMUserContext))]
    partial class CPMUserContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CPM.Data.Entities.ClientEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("UserId");

                    b.Property<string>("Username");

                    b.Property<bool?>("cpmAnalytics");

                    b.Property<bool?>("cpmAutoBargain");

                    b.Property<bool?>("cpmEscrow");

                    b.Property<bool?>("cpmForum");

                    b.Property<bool?>("cpmModerate");

                    b.Property<bool?>("cpmNews");

                    b.HasKey("Id");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("CPM.Data.Entities.CPMUserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Actions");

                    b.Property<bool?>("AgreedOnTerms");

                    b.Property<bool?>("CanReadEmails");

                    b.Property<bool?>("CheckIsUsedBefore");

                    b.Property<int?>("ClientId");

                    b.Property<DateTime?>("DateRegistered");

                    b.Property<string>("Email");

                    b.Property<DateTime?>("ExpiryDate");

                    b.Property<DateTime?>("LastSawMessage");

                    b.Property<int?>("LoginAttempts");

                    b.Property<string>("Password2");

                    b.Property<string>("PasswordHash")
                        .HasColumnName("Password");

                    b.Property<int?>("PasswordStrength");

                    b.Property<string>("PreviousPasswords");

                    b.Property<string>("Surname");

                    b.Property<bool?>("Suspended");

                    b.Property<string>("Username");

                    b.Property<int?>("WebUserType");

                    b.HasKey("Id");

                    b.ToTable("CPMUsers");
                });

            modelBuilder.Entity("CPM.Data.Entities.CurrencyEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("Description");

                    b.Property<decimal?>("MarketCap");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Currency");
                });

            modelBuilder.Entity("CPM.Data.Entities.OfferEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClientId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<int?>("DefaultCurrencyId");

                    b.Property<string>("Detail");

                    b.Property<DateTime>("ExpiryDate");

                    b.Property<string>("Name");

                    b.Property<int>("WalletId");

                    b.HasKey("Id");

                    b.ToTable("Offer");
                });

            modelBuilder.Entity("CPM.Data.Entities.WalletEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Balance");

                    b.Property<int>("ClientId");

                    b.Property<string>("Currency");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<DateTime?>("DeleteDate");

                    b.Property<int>("ImageId");

                    b.Property<bool?>("IsDeleted");

                    b.Property<bool>("IsLocked");

                    b.Property<bool>("LockOnNotificationLimit");

                    b.Property<bool>("LockOnSpendLimit");

                    b.Property<bool>("LockOnWithdrawLimit");

                    b.Property<string>("Name");

                    b.Property<decimal>("NotificationLimit");

                    b.Property<decimal>("SpendLimit");

                    b.Property<int?>("WalletTypeId");

                    b.Property<decimal>("WithdrawLimit");

                    b.HasKey("Id");

                    b.ToTable("Wallet");
                });

            modelBuilder.Entity("CPM.Data.Entities.WalletTypeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Category");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("WalletType");
                });
        }
    }
}
