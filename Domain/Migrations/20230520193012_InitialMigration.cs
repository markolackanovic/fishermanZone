using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    KorisnikID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ime = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Prezime = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    JMBG = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: true),
                    KorisnickoIme = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Lozinka = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Adresa = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    UdruzenjeID = table.Column<int>(type: "integer", nullable: true),
                    UlogaKorisnikaID = table.Column<int>(type: "integer", nullable: true),
                    ProfilnaSlika = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Aktivan = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.KorisnikID);
                });

            migrationBuilder.CreateTable(
                name: "TipAdministrativneJedinice",
                columns: table => new
                {
                    TipAdministrativneJediniceID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Naziv = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Aktivno = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipAdministrativneJedinice", x => x.TipAdministrativneJediniceID);
                });

            migrationBuilder.CreateTable(
                name: "TipClana",
                columns: table => new
                {
                    TipClanaID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Naziv = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Aktivno = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipClana", x => x.TipClanaID);
                });

            migrationBuilder.CreateTable(
                name: "TipDatoteke",
                columns: table => new
                {
                    TipDatotekeID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Naziv = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipDatoteke", x => x.TipDatotekeID);
                });

            migrationBuilder.CreateTable(
                name: "TipObjave",
                columns: table => new
                {
                    TipObjaveID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Naziv = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipObjave", x => x.TipObjaveID);
                });

            migrationBuilder.CreateTable(
                name: "UlogaKorisnika",
                columns: table => new
                {
                    UlogaKorisnikaID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Naziv = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Opis = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Aktivno = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UlogaKorisnika", x => x.UlogaKorisnikaID);
                });

            migrationBuilder.CreateTable(
                name: "AdministrativnaJedinica",
                columns: table => new
                {
                    AdministrativnaJedinicaID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Naziv = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    TipAdministrativneJediniceID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdministrativnaJedinica", x => x.AdministrativnaJedinicaID);
                    table.ForeignKey(
                        name: "FK_AdministrativnaJedinica_TipAdministrativneJedinice",
                        column: x => x.TipAdministrativneJediniceID,
                        principalTable: "TipAdministrativneJedinice",
                        principalColumn: "TipAdministrativneJediniceID");
                });

            migrationBuilder.CreateTable(
                name: "Datoteka",
                columns: table => new
                {
                    DatotekaID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Naziv = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    TipDatotekeID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Datoteka", x => x.DatotekaID);
                    table.ForeignKey(
                        name: "FK_Datoteka_TipDatoteke",
                        column: x => x.TipDatotekeID,
                        principalTable: "TipDatoteke",
                        principalColumn: "TipDatotekeID");
                });

            migrationBuilder.CreateTable(
                name: "Objava",
                columns: table => new
                {
                    ObjavaID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Naslov = table.Column<string>(type: "text", nullable: true),
                    Sadrzaj = table.Column<string>(type: "text", nullable: false),
                    DatumObjave = table.Column<DateTime>(type: "date", nullable: true),
                    LokacijaLat = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    LokacijaLong = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    TipObjaveID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objava", x => x.ObjavaID);
                    table.ForeignKey(
                        name: "FK_Objava_TipObjave",
                        column: x => x.TipObjaveID,
                        principalTable: "TipObjave",
                        principalColumn: "TipObjaveID");
                });

            migrationBuilder.CreateTable(
                name: "Udruzenje",
                columns: table => new
                {
                    UdruzenjeID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NadredjenoUdruzenjeID = table.Column<int>(type: "integer", nullable: true),
                    Naziv = table.Column<string>(type: "text", nullable: false),
                    AdministrativnaJedinicaID = table.Column<int>(type: "integer", nullable: false),
                    Adresa = table.Column<string>(type: "text", nullable: true),
                    Opis = table.Column<string>(type: "text", nullable: true),
                    LogoPath = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Udruzenje", x => x.UdruzenjeID);
                    table.ForeignKey(
                        name: "FK_Udruzenje_AdministrativnaJedinica",
                        column: x => x.AdministrativnaJedinicaID,
                        principalTable: "AdministrativnaJedinica",
                        principalColumn: "AdministrativnaJedinicaID");
                    table.ForeignKey(
                        name: "FK_Udruzenje_Udruzenje",
                        column: x => x.NadredjenoUdruzenjeID,
                        principalTable: "Udruzenje",
                        principalColumn: "UdruzenjeID");
                });

            migrationBuilder.CreateTable(
                name: "DatotekaObjave",
                columns: table => new
                {
                    DatotekeObjaveID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DatotekaID = table.Column<int>(type: "integer", nullable: false),
                    ObjavaID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatotekaObjave", x => x.DatotekeObjaveID);
                    table.ForeignKey(
                        name: "FK_DatotekaObjave_Datoteka",
                        column: x => x.DatotekaID,
                        principalTable: "Datoteka",
                        principalColumn: "DatotekaID");
                    table.ForeignKey(
                        name: "FK_DatotekaObjave_Objava",
                        column: x => x.ObjavaID,
                        principalTable: "Objava",
                        principalColumn: "ObjavaID");
                });

            migrationBuilder.CreateTable(
                name: "Komentar",
                columns: table => new
                {
                    KomentarID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Sadrzaj = table.Column<string>(type: "text", nullable: false),
                    KorisnikID = table.Column<int>(type: "integer", nullable: false),
                    ObjavaID = table.Column<int>(type: "integer", nullable: false),
                    Aktivno = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Komentar", x => x.KomentarID);
                    table.ForeignKey(
                        name: "FK_Komentar_Korisnik",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikID");
                    table.ForeignKey(
                        name: "FK_Komentar_Objava",
                        column: x => x.ObjavaID,
                        principalTable: "Objava",
                        principalColumn: "ObjavaID");
                });

            migrationBuilder.CreateTable(
                name: "Dokument",
                columns: table => new
                {
                    DokumentID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Naziv = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    UdruzenjeID = table.Column<int>(type: "integer", nullable: false),
                    DatotekaID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dokument", x => x.DokumentID);
                    table.ForeignKey(
                        name: "FK_Dokument_Datoteka",
                        column: x => x.DatotekaID,
                        principalTable: "Datoteka",
                        principalColumn: "DatotekaID");
                    table.ForeignKey(
                        name: "FK_Dokument_Udruzenje",
                        column: x => x.UdruzenjeID,
                        principalTable: "Udruzenje",
                        principalColumn: "UdruzenjeID");
                });

            migrationBuilder.CreateTable(
                name: "ObjavaKorisnika",
                columns: table => new
                {
                    ObjavaKorisnikaID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KorisnikID = table.Column<int>(type: "integer", nullable: false),
                    ObjavaID = table.Column<int>(type: "integer", nullable: false),
                    UdruzenjeID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjavaKorisnika", x => x.ObjavaKorisnikaID);
                    table.ForeignKey(
                        name: "FK_ObjavaKorisnika_Korisnik",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikID");
                    table.ForeignKey(
                        name: "FK_ObjavaKorisnika_Objava",
                        column: x => x.ObjavaID,
                        principalTable: "Objava",
                        principalColumn: "ObjavaID");
                    table.ForeignKey(
                        name: "FK_ObjavaKorisnika_Udruzenje",
                        column: x => x.UdruzenjeID,
                        principalTable: "Udruzenje",
                        principalColumn: "UdruzenjeID");
                });

            migrationBuilder.CreateTable(
                name: "ObjaveUdruzenja",
                columns: table => new
                {
                    ObjaveUdruzenjaID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ObjavaID = table.Column<int>(type: "integer", nullable: false),
                    UdruzenjeID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjaveUdruzenja", x => x.ObjaveUdruzenjaID);
                    table.ForeignKey(
                        name: "FK_ObjaveUdruzenja_Objava",
                        column: x => x.ObjavaID,
                        principalTable: "Objava",
                        principalColumn: "ObjavaID");
                    table.ForeignKey(
                        name: "FK_ObjaveUdruzenja_Udruzenje",
                        column: x => x.UdruzenjeID,
                        principalTable: "Udruzenje",
                        principalColumn: "UdruzenjeID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdministrativnaJedinica_TipAdministrativneJediniceID",
                table: "AdministrativnaJedinica",
                column: "TipAdministrativneJediniceID");

            migrationBuilder.CreateIndex(
                name: "IX_Datoteka_TipDatotekeID",
                table: "Datoteka",
                column: "TipDatotekeID");

            migrationBuilder.CreateIndex(
                name: "IX_DatotekaObjave_DatotekaID",
                table: "DatotekaObjave",
                column: "DatotekaID");

            migrationBuilder.CreateIndex(
                name: "IX_DatotekaObjave_ObjavaID",
                table: "DatotekaObjave",
                column: "ObjavaID");

            migrationBuilder.CreateIndex(
                name: "IX_Dokument_DatotekaID",
                table: "Dokument",
                column: "DatotekaID");

            migrationBuilder.CreateIndex(
                name: "IX_Dokument_UdruzenjeID",
                table: "Dokument",
                column: "UdruzenjeID");

            migrationBuilder.CreateIndex(
                name: "IX_Komentar_KorisnikID",
                table: "Komentar",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Komentar_ObjavaID",
                table: "Komentar",
                column: "ObjavaID");

            migrationBuilder.CreateIndex(
                name: "IX_Objava_TipObjaveID",
                table: "Objava",
                column: "TipObjaveID");

            migrationBuilder.CreateIndex(
                name: "IX_ObjavaKorisnika_KorisnikID",
                table: "ObjavaKorisnika",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_ObjavaKorisnika_ObjavaID",
                table: "ObjavaKorisnika",
                column: "ObjavaID");

            migrationBuilder.CreateIndex(
                name: "IX_ObjavaKorisnika_UdruzenjeID",
                table: "ObjavaKorisnika",
                column: "UdruzenjeID");

            migrationBuilder.CreateIndex(
                name: "IX_ObjaveUdruzenja_ObjavaID",
                table: "ObjaveUdruzenja",
                column: "ObjavaID");

            migrationBuilder.CreateIndex(
                name: "IX_ObjaveUdruzenja_UdruzenjeID",
                table: "ObjaveUdruzenja",
                column: "UdruzenjeID");

            migrationBuilder.CreateIndex(
                name: "IX_Udruzenje_AdministrativnaJedinicaID",
                table: "Udruzenje",
                column: "AdministrativnaJedinicaID");

            migrationBuilder.CreateIndex(
                name: "IX_Udruzenje_NadredjenoUdruzenjeID",
                table: "Udruzenje",
                column: "NadredjenoUdruzenjeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DatotekaObjave");

            migrationBuilder.DropTable(
                name: "Dokument");

            migrationBuilder.DropTable(
                name: "Komentar");

            migrationBuilder.DropTable(
                name: "ObjavaKorisnika");

            migrationBuilder.DropTable(
                name: "ObjaveUdruzenja");

            migrationBuilder.DropTable(
                name: "TipClana");

            migrationBuilder.DropTable(
                name: "UlogaKorisnika");

            migrationBuilder.DropTable(
                name: "Datoteka");

            migrationBuilder.DropTable(
                name: "Korisnik");

            migrationBuilder.DropTable(
                name: "Objava");

            migrationBuilder.DropTable(
                name: "Udruzenje");

            migrationBuilder.DropTable(
                name: "TipDatoteke");

            migrationBuilder.DropTable(
                name: "TipObjave");

            migrationBuilder.DropTable(
                name: "AdministrativnaJedinica");

            migrationBuilder.DropTable(
                name: "TipAdministrativneJedinice");
        }
    }
}
