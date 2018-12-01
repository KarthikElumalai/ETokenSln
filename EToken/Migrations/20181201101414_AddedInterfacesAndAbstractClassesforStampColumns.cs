using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EToken.Migrations
{
    public partial class AddedInterfacesAndAbstractClassesforStampColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CustomerPhoneNumber",
                table: "Login",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Login",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Login",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Login",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Login",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeletedFlag",
                table: "Login",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Login",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Login",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeletedFlag",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Customer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Login");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Login");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Login");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Login");

            migrationBuilder.DropColumn(
                name: "IsDeletedFlag",
                table: "Login");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Login");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Login");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "IsDeletedFlag",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Customer");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerPhoneNumber",
                table: "Login",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
