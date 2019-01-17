using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EToken.Migrations
{
    public partial class IntialSetUp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    IsDeletedFlag = table.Column<bool>(nullable: true),
                    DeletedBy = table.Column<string>(maxLength: 100, nullable: true),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    AddressLine1 = table.Column<string>(maxLength: 100, nullable: false),
                    AddressLine2 = table.Column<string>(maxLength: 50, nullable: true),
                    City = table.Column<string>(maxLength: 50, nullable: false),
                    StateProvince = table.Column<string>(maxLength: 50, nullable: false),
                    CountryRegion = table.Column<string>(maxLength: 50, nullable: false),
                    PostalCode = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressID);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    ServiceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    IsDeletedFlag = table.Column<bool>(nullable: true),
                    DeletedBy = table.Column<string>(maxLength: 100, nullable: true),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    ServiceName = table.Column<string>(maxLength: 100, nullable: false),
                    ServiceType = table.Column<string>(maxLength: 100, nullable: false),
                    ServiceDescription = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.ServiceID);
                });

            migrationBuilder.CreateTable(
                name: "TokenStatus",
                columns: table => new
                {
                    TokenStatusID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    IsDeletedFlag = table.Column<bool>(nullable: true),
                    DeletedBy = table.Column<string>(maxLength: 100, nullable: true),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    StatusCode = table.Column<string>(maxLength: 100, nullable: false),
                    StatusDescription = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TokenStatus", x => x.TokenStatusID);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    IsDeletedFlag = table.Column<bool>(nullable: true),
                    DeletedBy = table.Column<string>(maxLength: 100, nullable: true),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(maxLength: 10, nullable: true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    MiddleName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    EmailAddress = table.Column<string>(maxLength: 50, nullable: true),
                    Phone = table.Column<string>(maxLength: 50, nullable: false),
                    FkAddressID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerID);
                    table.ForeignKey(
                        name: "FK_Customer_Address_FkAddressID",
                        column: x => x.FkAddressID,
                        principalTable: "Address",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Organisation",
                columns: table => new
                {
                    OrganisationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    IsDeletedFlag = table.Column<bool>(nullable: true),
                    DeletedBy = table.Column<string>(maxLength: 100, nullable: true),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    OrganisationName = table.Column<string>(maxLength: 100, nullable: false),
                    OrganisationType = table.Column<string>(maxLength: 100, nullable: false),
                    Industry = table.Column<string>(maxLength: 100, nullable: false),
                    FkAddressID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organisation", x => x.OrganisationID);
                    table.ForeignKey(
                        name: "FK_Organisation_Address_FkAddressID",
                        column: x => x.FkAddressID,
                        principalTable: "Address",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Provider",
                columns: table => new
                {
                    ProviderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    IsDeletedFlag = table.Column<bool>(nullable: true),
                    DeletedBy = table.Column<string>(maxLength: 100, nullable: true),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(maxLength: 10, nullable: true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    MiddleName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    EmailAddress = table.Column<string>(maxLength: 50, nullable: true),
                    Phone = table.Column<string>(maxLength: 50, nullable: false),
                    ProviderType = table.Column<string>(maxLength: 100, nullable: false),
                    FkAddressID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provider", x => x.ProviderID);
                    table.ForeignKey(
                        name: "FK_Provider_Address_FkAddressID",
                        column: x => x.FkAddressID,
                        principalTable: "Address",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrganisationServiceProvider",
                columns: table => new
                {
                    OrganisationServiceProviderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FkOrganisationID = table.Column<int>(nullable: true),
                    FkServiceID = table.Column<int>(nullable: true),
                    FkProviderID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganisationServiceProvider", x => x.OrganisationServiceProviderID);
                    table.ForeignKey(
                        name: "FK_OrganisationServiceProvider_Organisation_FkOrganisationID",
                        column: x => x.FkOrganisationID,
                        principalTable: "Organisation",
                        principalColumn: "OrganisationID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrganisationServiceProvider_Provider_FkProviderID",
                        column: x => x.FkProviderID,
                        principalTable: "Provider",
                        principalColumn: "ProviderID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrganisationServiceProvider_Service_FkServiceID",
                        column: x => x.FkServiceID,
                        principalTable: "Service",
                        principalColumn: "ServiceID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Token",
                columns: table => new
                {
                    TokenID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    IsDeletedFlag = table.Column<bool>(nullable: true),
                    DeletedBy = table.Column<string>(maxLength: 100, nullable: true),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    TokenNumber = table.Column<int>(nullable: false),
                    TokenDescription = table.Column<string>(nullable: true),
                    FkCustomerID = table.Column<int>(nullable: true),
                    FkTokenStatusID = table.Column<int>(nullable: true),
                    FkOrganisationServiceProviderID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Token", x => x.TokenID);
                    table.ForeignKey(
                        name: "FK_Token_Customer_FkCustomerID",
                        column: x => x.FkCustomerID,
                        principalTable: "Customer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Token_OrganisationServiceProvider_FkOrganisationServiceProviderID",
                        column: x => x.FkOrganisationServiceProviderID,
                        principalTable: "OrganisationServiceProvider",
                        principalColumn: "OrganisationServiceProviderID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Token_TokenStatus_FkTokenStatusID",
                        column: x => x.FkTokenStatusID,
                        principalTable: "TokenStatus",
                        principalColumn: "TokenStatusID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_FkAddressID",
                table: "Customer",
                column: "FkAddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Organisation_FkAddressID",
                table: "Organisation",
                column: "FkAddressID");

            migrationBuilder.CreateIndex(
                name: "IX_OrganisationServiceProvider_FkOrganisationID",
                table: "OrganisationServiceProvider",
                column: "FkOrganisationID");

            migrationBuilder.CreateIndex(
                name: "IX_OrganisationServiceProvider_FkProviderID",
                table: "OrganisationServiceProvider",
                column: "FkProviderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrganisationServiceProvider_FkServiceID",
                table: "OrganisationServiceProvider",
                column: "FkServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_Provider_FkAddressID",
                table: "Provider",
                column: "FkAddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Token_FkCustomerID",
                table: "Token",
                column: "FkCustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Token_FkOrganisationServiceProviderID",
                table: "Token",
                column: "FkOrganisationServiceProviderID");

            migrationBuilder.CreateIndex(
                name: "IX_Token_FkTokenStatusID",
                table: "Token",
                column: "FkTokenStatusID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Token");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "OrganisationServiceProvider");

            migrationBuilder.DropTable(
                name: "TokenStatus");

            migrationBuilder.DropTable(
                name: "Organisation");

            migrationBuilder.DropTable(
                name: "Provider");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
