﻿// <auto-generated />
using System;
using EToken.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EToken.Migrations
{
    [DbContext(typeof(ETokenDBContext))]
    [Migration("20190116043134_IntialSetUp")]
    partial class IntialSetUp
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EToken.Models.Address", b =>
                {
                    b.Property<int>("AddressID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("AddressLine2")
                        .HasMaxLength(50);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("CountryRegion")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("DeletedBy")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<bool?>("IsDeletedFlag");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("StateProvince")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("AddressID");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("EToken.Models.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("DeletedBy")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<string>("EmailAddress")
                        .HasMaxLength(50);

                    b.Property<string>("FirstName")
                        .HasMaxLength(50);

                    b.Property<int?>("FkAddressID");

                    b.Property<bool?>("IsDeletedFlag");

                    b.Property<string>("LastName")
                        .HasMaxLength(50);

                    b.Property<string>("MiddleName")
                        .HasMaxLength(50);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Title")
                        .HasMaxLength(10);

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("CustomerID");

                    b.HasIndex("FkAddressID");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("EToken.Models.Organisation", b =>
                {
                    b.Property<int>("OrganisationID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("DeletedBy")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<int?>("FkAddressID");

                    b.Property<string>("Industry")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<bool?>("IsDeletedFlag");

                    b.Property<string>("OrganisationName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("OrganisationType")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("OrganisationID");

                    b.HasIndex("FkAddressID");

                    b.ToTable("Organisation");
                });

            modelBuilder.Entity("EToken.Models.OrganisationServiceProvider", b =>
                {
                    b.Property<int>("OrganisationServiceProviderID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FkOrganisationID");

                    b.Property<int?>("FkProviderID");

                    b.Property<int?>("FkServiceID");

                    b.HasKey("OrganisationServiceProviderID");

                    b.HasIndex("FkOrganisationID");

                    b.HasIndex("FkProviderID");

                    b.HasIndex("FkServiceID");

                    b.ToTable("OrganisationServiceProvider");
                });

            modelBuilder.Entity("EToken.Models.Provider", b =>
                {
                    b.Property<int>("ProviderID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("DeletedBy")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<string>("EmailAddress")
                        .HasMaxLength(50);

                    b.Property<string>("FirstName")
                        .HasMaxLength(50);

                    b.Property<int?>("FkAddressID");

                    b.Property<bool?>("IsDeletedFlag");

                    b.Property<string>("LastName")
                        .HasMaxLength(50);

                    b.Property<string>("MiddleName")
                        .HasMaxLength(50);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("ProviderType")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Title")
                        .HasMaxLength(10);

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("ProviderID");

                    b.HasIndex("FkAddressID");

                    b.ToTable("Provider");
                });

            modelBuilder.Entity("EToken.Models.Service", b =>
                {
                    b.Property<int>("ServiceID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("DeletedBy")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<bool?>("IsDeletedFlag");

                    b.Property<string>("ServiceDescription")
                        .HasMaxLength(500);

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("ServiceType")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("ServiceID");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("EToken.Models.Token", b =>
                {
                    b.Property<int>("TokenID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("DeletedBy")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<int?>("FkCustomerID");

                    b.Property<int?>("FkOrganisationServiceProviderID");

                    b.Property<int?>("FkTokenStatusID");

                    b.Property<bool?>("IsDeletedFlag");

                    b.Property<string>("TokenDescription");

                    b.Property<int>("TokenNumber");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("TokenID");

                    b.HasIndex("FkCustomerID");

                    b.HasIndex("FkOrganisationServiceProviderID");

                    b.HasIndex("FkTokenStatusID");

                    b.ToTable("Token");
                });

            modelBuilder.Entity("EToken.Models.TokenStatus", b =>
                {
                    b.Property<int>("TokenStatusID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("DeletedBy")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<bool?>("IsDeletedFlag");

                    b.Property<string>("StatusCode")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("StatusDescription")
                        .HasMaxLength(500);

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("TokenStatusID");

                    b.ToTable("TokenStatus");
                });

            modelBuilder.Entity("EToken.Models.Customer", b =>
                {
                    b.HasOne("EToken.Models.Address", "FkAddressNav")
                        .WithMany()
                        .HasForeignKey("FkAddressID");
                });

            modelBuilder.Entity("EToken.Models.Organisation", b =>
                {
                    b.HasOne("EToken.Models.Address", "FkAddressNav")
                        .WithMany()
                        .HasForeignKey("FkAddressID");
                });

            modelBuilder.Entity("EToken.Models.OrganisationServiceProvider", b =>
                {
                    b.HasOne("EToken.Models.Organisation", "FkOrganisationNav")
                        .WithMany()
                        .HasForeignKey("FkOrganisationID");

                    b.HasOne("EToken.Models.Provider", "FkProviderNav")
                        .WithMany()
                        .HasForeignKey("FkProviderID");

                    b.HasOne("EToken.Models.Service", "FkServiceNav")
                        .WithMany()
                        .HasForeignKey("FkServiceID");
                });

            modelBuilder.Entity("EToken.Models.Provider", b =>
                {
                    b.HasOne("EToken.Models.Address", "FkAddressNav")
                        .WithMany()
                        .HasForeignKey("FkAddressID");
                });

            modelBuilder.Entity("EToken.Models.Token", b =>
                {
                    b.HasOne("EToken.Models.Customer", "FkCustomerNav")
                        .WithMany()
                        .HasForeignKey("FkCustomerID");

                    b.HasOne("EToken.Models.OrganisationServiceProvider", "FkOrganisationServiceProviderNav")
                        .WithMany()
                        .HasForeignKey("FkOrganisationServiceProviderID");

                    b.HasOne("EToken.Models.TokenStatus", "FkTokenStatusNav")
                        .WithMany()
                        .HasForeignKey("FkTokenStatusID");
                });
#pragma warning restore 612, 618
        }
    }
}
