﻿// <auto-generated />
using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Domain.Migrations
{
    //Ukoliko se rade migracije otkomentarisati ovde i na jos jednom mestu
    //[DbContext(typeof(BihfishingContext))]
    partial class BihfishingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.AdministrativnaJedinica", b =>
                {
                    b.Property<int>("AdministrativnaJedinicaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("AdministrativnaJedinicaID");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AdministrativnaJedinicaId"));

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<int?>("TipAdministrativneJediniceId")
                        .HasColumnType("integer")
                        .HasColumnName("TipAdministrativneJediniceID");

                    b.HasKey("AdministrativnaJedinicaId");

                    b.HasIndex("TipAdministrativneJediniceId");

                    b.ToTable("AdministrativnaJedinica", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Datoteka", b =>
                {
                    b.Property<int>("DatotekaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("DatotekaID");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DatotekaId"));

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("TipDatotekeId")
                        .HasColumnType("integer")
                        .HasColumnName("TipDatotekeID");

                    b.HasKey("DatotekaId");

                    b.HasIndex("TipDatotekeId");

                    b.ToTable("Datoteka", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.DatotekaObjave", b =>
                {
                    b.Property<int>("DatotekeObjaveId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("DatotekeObjaveID");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DatotekeObjaveId"));

                    b.Property<int>("DatotekaId")
                        .HasColumnType("integer")
                        .HasColumnName("DatotekaID");

                    b.Property<int>("ObjavaId")
                        .HasColumnType("integer")
                        .HasColumnName("ObjavaID");

                    b.HasKey("DatotekeObjaveId");

                    b.HasIndex("DatotekaId");

                    b.HasIndex("ObjavaId");

                    b.ToTable("DatotekaObjave", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Dokument", b =>
                {
                    b.Property<int>("DokumentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("DokumentID");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DokumentId"));

                    b.Property<int>("DatotekaId")
                        .HasColumnType("integer")
                        .HasColumnName("DatotekaID");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("UdruzenjeId")
                        .HasColumnType("integer")
                        .HasColumnName("UdruzenjeID");

                    b.HasKey("DokumentId");

                    b.HasIndex("DatotekaId");

                    b.HasIndex("UdruzenjeId");

                    b.ToTable("Dokument", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Komentar", b =>
                {
                    b.Property<int>("KomentarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("KomentarID");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("KomentarId"));

                    b.Property<bool>("Aktivno")
                        .HasColumnType("boolean");

                    b.Property<int>("KorisnikId")
                        .HasColumnType("integer")
                        .HasColumnName("KorisnikID");

                    b.Property<int>("ObjavaId")
                        .HasColumnType("integer")
                        .HasColumnName("ObjavaID");

                    b.Property<string>("Sadrzaj")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("KomentarId");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("ObjavaId");

                    b.ToTable("Komentar", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Korisnik", b =>
                {
                    b.Property<int>("KorisnikId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("KorisnikID");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("KorisnikId"));

                    b.Property<string>("Adresa")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<bool>("Aktivan")
                        .HasColumnType("boolean");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Jmbg")
                        .HasMaxLength(13)
                        .HasColumnType("character varying(13)")
                        .HasColumnName("JMBG");

                    b.Property<string>("KorisnickoIme")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Lozinka")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("ProfilnaSlika")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int?>("UdruzenjeId")
                        .HasColumnType("integer")
                        .HasColumnName("UdruzenjeID");

                    b.Property<int?>("UlogaKorisnikaId")
                        .HasColumnType("integer")
                        .HasColumnName("UlogaKorisnikaID");

                    b.HasKey("KorisnikId");

                    b.ToTable("Korisnik", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Objava", b =>
                {
                    b.Property<int>("ObjavaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ObjavaID");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ObjavaId"));

                    b.Property<DateTime?>("DatumObjave")
                        .HasColumnType("date");

                    b.Property<string>("LokacijaLat")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<string>("LokacijaLong")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<string>("Naslov")
                        .HasColumnType("text");

                    b.Property<string>("Sadrzaj")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TipObjaveId")
                        .HasColumnType("integer")
                        .HasColumnName("TipObjaveID");

                    b.HasKey("ObjavaId");

                    b.HasIndex("TipObjaveId");

                    b.ToTable("Objava", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.ObjavaKorisnika", b =>
                {
                    b.Property<int>("ObjavaKorisnikaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ObjavaKorisnikaID");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ObjavaKorisnikaId"));

                    b.Property<int>("KorisnikId")
                        .HasColumnType("integer")
                        .HasColumnName("KorisnikID");

                    b.Property<int>("ObjavaId")
                        .HasColumnType("integer")
                        .HasColumnName("ObjavaID");

                    b.Property<int>("UdruzenjeId")
                        .HasColumnType("integer")
                        .HasColumnName("UdruzenjeID");

                    b.HasKey("ObjavaKorisnikaId");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("ObjavaId");

                    b.HasIndex("UdruzenjeId");

                    b.ToTable("ObjavaKorisnika", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.ObjaveUdruzenja", b =>
                {
                    b.Property<int>("ObjaveUdruzenjaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ObjaveUdruzenjaID");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ObjaveUdruzenjaId"));

                    b.Property<int>("ObjavaId")
                        .HasColumnType("integer")
                        .HasColumnName("ObjavaID");

                    b.Property<int>("UdruzenjeId")
                        .HasColumnType("integer")
                        .HasColumnName("UdruzenjeID");

                    b.HasKey("ObjaveUdruzenjaId");

                    b.HasIndex("ObjavaId");

                    b.HasIndex("UdruzenjeId");

                    b.ToTable("ObjaveUdruzenja", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.TipAdministrativneJedinice", b =>
                {
                    b.Property<int>("TipAdministrativneJediniceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("TipAdministrativneJediniceID");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TipAdministrativneJediniceId"));

                    b.Property<bool>("Aktivno")
                        .HasColumnType("boolean");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.HasKey("TipAdministrativneJediniceId");

                    b.ToTable("TipAdministrativneJedinice", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.TipClana", b =>
                {
                    b.Property<int>("TipClanaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("TipClanaID");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TipClanaId"));

                    b.Property<bool>("Aktivno")
                        .HasColumnType("boolean");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("TipClanaId");

                    b.ToTable("TipClana", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.TipDatoteke", b =>
                {
                    b.Property<int>("TipDatotekeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("TipDatotekeID");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TipDatotekeId"));

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("TipDatotekeId");

                    b.ToTable("TipDatoteke", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.TipObjave", b =>
                {
                    b.Property<int>("TipObjaveId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("TipObjaveID");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TipObjaveId"));

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.HasKey("TipObjaveId");

                    b.ToTable("TipObjave", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Udruzenje", b =>
                {
                    b.Property<int>("UdruzenjeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("UdruzenjeID");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UdruzenjeId"));

                    b.Property<int>("AdministrativnaJedinicaId")
                        .HasColumnType("integer")
                        .HasColumnName("AdministrativnaJedinicaID");

                    b.Property<string>("Adresa")
                        .HasColumnType("text");

                    b.Property<string>("LogoPath")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<int?>("NadredjenjoUdruzenjeId")
                        .HasColumnType("integer")
                        .HasColumnName("NadredjenjoUdruzenjeID");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Opis")
                        .HasColumnType("text");

                    b.HasKey("UdruzenjeId");

                    b.HasIndex("AdministrativnaJedinicaId");

                    b.HasIndex("NadredjenjoUdruzenjeId");

                    b.ToTable("Udruzenje", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.UlogaKorisnika", b =>
                {
                    b.Property<int>("UlogaKorisnikaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("UlogaKorisnikaID");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UlogaKorisnikaId"));

                    b.Property<bool>("Aktivno")
                        .HasColumnType("boolean");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Opis")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.HasKey("UlogaKorisnikaId");

                    b.ToTable("UlogaKorisnika", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.AdministrativnaJedinica", b =>
                {
                    b.HasOne("Domain.Entities.TipAdministrativneJedinice", "TipAdministrativneJedinice")
                        .WithMany("AdministrativnaJedinicas")
                        .HasForeignKey("TipAdministrativneJediniceId")
                        .HasConstraintName("FK_AdministrativnaJedinica_TipAdministrativneJedinice");

                    b.Navigation("TipAdministrativneJedinice");
                });

            modelBuilder.Entity("Domain.Entities.Datoteka", b =>
                {
                    b.HasOne("Domain.Entities.TipDatoteke", "TipDatoteke")
                        .WithMany("Datotekas")
                        .HasForeignKey("TipDatotekeId")
                        .IsRequired()
                        .HasConstraintName("FK_Datoteka_TipDatoteke");

                    b.Navigation("TipDatoteke");
                });

            modelBuilder.Entity("Domain.Entities.DatotekaObjave", b =>
                {
                    b.HasOne("Domain.Entities.Datoteka", "Datoteka")
                        .WithMany("DatotekaObjaves")
                        .HasForeignKey("DatotekaId")
                        .IsRequired()
                        .HasConstraintName("FK_DatotekaObjave_Datoteka");

                    b.HasOne("Domain.Entities.Objava", "Objava")
                        .WithMany("DatotekaObjaves")
                        .HasForeignKey("ObjavaId")
                        .IsRequired()
                        .HasConstraintName("FK_DatotekaObjave_Objava");

                    b.Navigation("Datoteka");

                    b.Navigation("Objava");
                });

            modelBuilder.Entity("Domain.Entities.Dokument", b =>
                {
                    b.HasOne("Domain.Entities.Datoteka", "Datoteka")
                        .WithMany("Dokuments")
                        .HasForeignKey("DatotekaId")
                        .IsRequired()
                        .HasConstraintName("FK_Dokument_Datoteka");

                    b.HasOne("Domain.Entities.Udruzenje", "Udruzenje")
                        .WithMany("Dokuments")
                        .HasForeignKey("UdruzenjeId")
                        .IsRequired()
                        .HasConstraintName("FK_Dokument_Udruzenje");

                    b.Navigation("Datoteka");

                    b.Navigation("Udruzenje");
                });

            modelBuilder.Entity("Domain.Entities.Komentar", b =>
                {
                    b.HasOne("Domain.Entities.Korisnik", "Korisnik")
                        .WithMany("Komentars")
                        .HasForeignKey("KorisnikId")
                        .IsRequired()
                        .HasConstraintName("FK_Komentar_Korisnik");

                    b.HasOne("Domain.Entities.Objava", "Objava")
                        .WithMany("Komentars")
                        .HasForeignKey("ObjavaId")
                        .IsRequired()
                        .HasConstraintName("FK_Komentar_Objava");

                    b.Navigation("Korisnik");

                    b.Navigation("Objava");
                });

            modelBuilder.Entity("Domain.Entities.Objava", b =>
                {
                    b.HasOne("Domain.Entities.TipObjave", "TipObjave")
                        .WithMany("Objavas")
                        .HasForeignKey("TipObjaveId")
                        .IsRequired()
                        .HasConstraintName("FK_Objava_TipObjave");

                    b.Navigation("TipObjave");
                });

            modelBuilder.Entity("Domain.Entities.ObjavaKorisnika", b =>
                {
                    b.HasOne("Domain.Entities.Korisnik", "Korisnik")
                        .WithMany("ObjavaKorisnikas")
                        .HasForeignKey("KorisnikId")
                        .IsRequired()
                        .HasConstraintName("FK_ObjavaKorisnika_Korisnik");

                    b.HasOne("Domain.Entities.Objava", "Objava")
                        .WithMany("ObjavaKorisnikas")
                        .HasForeignKey("ObjavaId")
                        .IsRequired()
                        .HasConstraintName("FK_ObjavaKorisnika_Objava");

                    b.HasOne("Domain.Entities.Udruzenje", "Udruzenje")
                        .WithMany("ObjavaKorisnikas")
                        .HasForeignKey("UdruzenjeId")
                        .IsRequired()
                        .HasConstraintName("FK_ObjavaKorisnika_Udruzenje");

                    b.Navigation("Korisnik");

                    b.Navigation("Objava");

                    b.Navigation("Udruzenje");
                });

            modelBuilder.Entity("Domain.Entities.ObjaveUdruzenja", b =>
                {
                    b.HasOne("Domain.Entities.Objava", "Objava")
                        .WithMany("ObjaveUdruzenjas")
                        .HasForeignKey("ObjavaId")
                        .IsRequired()
                        .HasConstraintName("FK_ObjaveUdruzenja_Objava");

                    b.HasOne("Domain.Entities.Udruzenje", "Udruzenje")
                        .WithMany("ObjaveUdruzenjas")
                        .HasForeignKey("UdruzenjeId")
                        .IsRequired()
                        .HasConstraintName("FK_ObjaveUdruzenja_Udruzenje");

                    b.Navigation("Objava");

                    b.Navigation("Udruzenje");
                });

            modelBuilder.Entity("Domain.Entities.Udruzenje", b =>
                {
                    b.HasOne("Domain.Entities.AdministrativnaJedinica", "AdministrativnaJedinica")
                        .WithMany("Udruzenjes")
                        .HasForeignKey("AdministrativnaJedinicaId")
                        .IsRequired()
                        .HasConstraintName("FK_Udruzenje_AdministrativnaJedinica");

                    b.HasOne("Domain.Entities.Udruzenje", "NadredjenjoUdruzenje")
                        .WithMany("InverseNadredjenjoUdruzenje")
                        .HasForeignKey("NadredjenjoUdruzenjeId")
                        .HasConstraintName("FK_Udruzenje_Udruzenje");

                    b.Navigation("AdministrativnaJedinica");

                    b.Navigation("NadredjenjoUdruzenje");
                });

            modelBuilder.Entity("Domain.Entities.AdministrativnaJedinica", b =>
                {
                    b.Navigation("Udruzenjes");
                });

            modelBuilder.Entity("Domain.Entities.Datoteka", b =>
                {
                    b.Navigation("DatotekaObjaves");

                    b.Navigation("Dokuments");
                });

            modelBuilder.Entity("Domain.Entities.Korisnik", b =>
                {
                    b.Navigation("Komentars");

                    b.Navigation("ObjavaKorisnikas");
                });

            modelBuilder.Entity("Domain.Entities.Objava", b =>
                {
                    b.Navigation("DatotekaObjaves");

                    b.Navigation("Komentars");

                    b.Navigation("ObjavaKorisnikas");

                    b.Navigation("ObjaveUdruzenjas");
                });

            modelBuilder.Entity("Domain.Entities.TipAdministrativneJedinice", b =>
                {
                    b.Navigation("AdministrativnaJedinicas");
                });

            modelBuilder.Entity("Domain.Entities.TipDatoteke", b =>
                {
                    b.Navigation("Datotekas");
                });

            modelBuilder.Entity("Domain.Entities.TipObjave", b =>
                {
                    b.Navigation("Objavas");
                });

            modelBuilder.Entity("Domain.Entities.Udruzenje", b =>
                {
                    b.Navigation("Dokuments");

                    b.Navigation("InverseNadredjenjoUdruzenje");

                    b.Navigation("ObjavaKorisnikas");

                    b.Navigation("ObjaveUdruzenjas");
                });
#pragma warning restore 612, 618
        }
    }
}
