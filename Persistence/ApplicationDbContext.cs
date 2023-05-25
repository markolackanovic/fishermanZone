using System;
using System.Collections.Generic;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace Persistence
{
    public partial class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        private readonly IMediator _mediator;

        public ApplicationDbContext(IMediator mediator)
        {
            _mediator = mediator;
        }
        public virtual DbSet<AdministrativnaJedinica> AdministrativnaJedinicas { get; set; }

        public virtual DbSet<Datoteka> Datotekas { get; set; }

        public virtual DbSet<DatotekaObjave> DatotekaObjaves { get; set; }

        public virtual DbSet<Dokument> Dokuments { get; set; }

        public virtual DbSet<Komentar> Komentars { get; set; }

        public virtual DbSet<Korisnik> Korisniks { get; set; }

        public virtual DbSet<Objava> Objavas { get; set; }

        public virtual DbSet<ObjavaKorisnika> ObjavaKorisnikas { get; set; }

        public virtual DbSet<ObjaveUdruzenja> ObjaveUdruzenjas { get; set; }

        public virtual DbSet<TipAdministrativneJedinice> TipAdministrativneJedinices { get; set; }

        public virtual DbSet<TipClana> TipClanas { get; set; }

        public virtual DbSet<TipDatoteke> TipDatotekes { get; set; }

        public virtual DbSet<TipObjave> TipObjaves { get; set; }

        public virtual DbSet<Udruzenje> Udruzenjes { get; set; }

        public virtual DbSet<UlogaKorisnika> UlogaKorisnikas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseNpgsql("Server=localhost;Port=5432;User ID=postgres;Password=Pa$$w0rd;Database=BIHFishing;Trust Server Certificate=false;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdministrativnaJedinica>(entity =>
            {
                entity.ToTable("AdministrativnaJedinica");

                entity.HasIndex(e => e.TipAdministrativneJediniceId, "IX_AdministrativnaJedinica_TipAdministrativneJediniceID");

                entity.Property(e => e.AdministrativnaJedinicaId).HasColumnName("AdministrativnaJedinicaID");
                entity.Property(e => e.Naziv).HasMaxLength(500);
                entity.Property(e => e.TipAdministrativneJediniceId).HasColumnName("TipAdministrativneJediniceID");

                entity.HasOne(d => d.TipAdministrativneJedinice).WithMany(p => p.AdministrativnaJedinicas)
                    .HasForeignKey(d => d.TipAdministrativneJediniceId)
                    .HasConstraintName("FK_AdministrativnaJedinica_TipAdministrativneJedinice");
            });

            modelBuilder.Entity<Datoteka>(entity =>
            {
                entity.ToTable("Datoteka");

                entity.HasIndex(e => e.TipDatotekeId, "IX_Datoteka_TipDatotekeID");

                entity.Property(e => e.DatotekaId).HasColumnName("DatotekaID");
                entity.Property(e => e.Naziv).HasMaxLength(100);
                entity.Property(e => e.TipDatotekeId).HasColumnName("TipDatotekeID");

                entity.HasOne(d => d.TipDatoteke).WithMany(p => p.Datotekas)
                    .HasForeignKey(d => d.TipDatotekeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Datoteka_TipDatoteke");
            });

            modelBuilder.Entity<DatotekaObjave>(entity =>
            {
                entity.HasKey(e => e.DatotekeObjaveId);

                entity.ToTable("DatotekaObjave");

                entity.HasIndex(e => e.DatotekaId, "IX_DatotekaObjave_DatotekaID");

                entity.HasIndex(e => e.ObjavaId, "IX_DatotekaObjave_ObjavaID");

                entity.Property(e => e.DatotekeObjaveId).HasColumnName("DatotekeObjaveID");
                entity.Property(e => e.DatotekaId).HasColumnName("DatotekaID");
                entity.Property(e => e.ObjavaId).HasColumnName("ObjavaID");

                entity.HasOne(d => d.Datoteka).WithMany(p => p.DatotekaObjaves)
                    .HasForeignKey(d => d.DatotekaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DatotekaObjave_Datoteka");

                entity.HasOne(d => d.Objava).WithMany(p => p.DatotekaObjaves)
                    .HasForeignKey(d => d.ObjavaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DatotekaObjave_Objava");
            });

            modelBuilder.Entity<Dokument>(entity =>
            {
                entity.ToTable("Dokument");

                entity.HasIndex(e => e.DatotekaId, "IX_Dokument_DatotekaID");

                entity.HasIndex(e => e.UdruzenjeId, "IX_Dokument_UdruzenjeID");

                entity.Property(e => e.DokumentId).HasColumnName("DokumentID");
                entity.Property(e => e.DatotekaId).HasColumnName("DatotekaID");
                entity.Property(e => e.Naziv).HasMaxLength(50);
                entity.Property(e => e.UdruzenjeId).HasColumnName("UdruzenjeID");

                entity.HasOne(d => d.Datoteka).WithMany(p => p.Dokuments)
                    .HasForeignKey(d => d.DatotekaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Dokument_Datoteka");

                entity.HasOne(d => d.Udruzenje).WithMany(p => p.Dokuments)
                    .HasForeignKey(d => d.UdruzenjeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Dokument_Udruzenje");
            });

            modelBuilder.Entity<Komentar>(entity =>
            {
                entity.ToTable("Komentar");

                entity.HasIndex(e => e.KorisnikId, "IX_Komentar_KorisnikID");

                entity.HasIndex(e => e.ObjavaId, "IX_Komentar_ObjavaID");

                entity.Property(e => e.KomentarId).HasColumnName("KomentarID");
                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");
                entity.Property(e => e.ObjavaId).HasColumnName("ObjavaID");

                entity.HasOne(d => d.Korisnik).WithMany(p => p.Komentars)
                    .HasForeignKey(d => d.KorisnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Komentar_Korisnik");

                entity.HasOne(d => d.Objava).WithMany(p => p.Komentars)
                    .HasForeignKey(d => d.ObjavaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Komentar_Objava");
            });

            modelBuilder.Entity<Korisnik>(entity =>
            {
                entity.ToTable("Korisnik");

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");
                entity.Property(e => e.Adresa).HasMaxLength(500);
                entity.Property(e => e.Ime).HasMaxLength(100);
                entity.Property(e => e.Jmbg)
                    .HasMaxLength(13)
                    .HasColumnName("JMBG");
                entity.Property(e => e.KorisnickoIme).HasMaxLength(50);
                entity.Property(e => e.Lozinka).HasMaxLength(500);
                entity.Property(e => e.Prezime).HasMaxLength(100);
                entity.Property(e => e.ProfilnaSlika).HasMaxLength(100);
                entity.Property(e => e.UdruzenjeId).HasColumnName("UdruzenjeID");
                entity.Property(e => e.UlogaKorisnikaId).HasColumnName("UlogaKorisnikaID");
            });

            modelBuilder.Entity<Objava>(entity =>
            {
                entity.ToTable("Objava");

                entity.HasIndex(e => e.TipObjaveId, "IX_Objava_TipObjaveID");

                entity.Property(e => e.ObjavaId).HasColumnName("ObjavaID");
                entity.Property(e => e.LokacijaLat).HasMaxLength(10);
                entity.Property(e => e.LokacijaLong).HasMaxLength(10);
                entity.Property(e => e.TipObjaveId).HasColumnName("TipObjaveID");

                entity.HasOne(d => d.TipObjave).WithMany(p => p.Objavas)
                    .HasForeignKey(d => d.TipObjaveId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Objava_TipObjave");
            });

            modelBuilder.Entity<ObjavaKorisnika>(entity =>
            {
                entity.ToTable("ObjavaKorisnika");

                entity.HasIndex(e => e.KorisnikId, "IX_ObjavaKorisnika_KorisnikID");

                entity.HasIndex(e => e.ObjavaId, "IX_ObjavaKorisnika_ObjavaID");

                entity.HasIndex(e => e.UdruzenjeId, "IX_ObjavaKorisnika_UdruzenjeID");

                entity.Property(e => e.ObjavaKorisnikaId).HasColumnName("ObjavaKorisnikaID");
                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");
                entity.Property(e => e.ObjavaId).HasColumnName("ObjavaID");
                entity.Property(e => e.UdruzenjeId).HasColumnName("UdruzenjeID");

                entity.HasOne(d => d.Korisnik).WithMany(p => p.ObjavaKorisnikas)
                    .HasForeignKey(d => d.KorisnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ObjavaKorisnika_Korisnik");

                entity.HasOne(d => d.Objava).WithMany(p => p.ObjavaKorisnikas)
                    .HasForeignKey(d => d.ObjavaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ObjavaKorisnika_Objava");

                entity.HasOne(d => d.Udruzenje).WithMany(p => p.ObjavaKorisnikas)
                    .HasForeignKey(d => d.UdruzenjeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ObjavaKorisnika_Udruzenje");
            });

            modelBuilder.Entity<ObjaveUdruzenja>(entity =>
            {
                entity.ToTable("ObjaveUdruzenja");

                entity.HasIndex(e => e.ObjavaId, "IX_ObjaveUdruzenja_ObjavaID");

                entity.HasIndex(e => e.UdruzenjeId, "IX_ObjaveUdruzenja_UdruzenjeID");

                entity.Property(e => e.ObjaveUdruzenjaId).HasColumnName("ObjaveUdruzenjaID");
                entity.Property(e => e.ObjavaId).HasColumnName("ObjavaID");
                entity.Property(e => e.UdruzenjeId).HasColumnName("UdruzenjeID");

                entity.HasOne(d => d.Objava).WithMany(p => p.ObjaveUdruzenjas)
                    .HasForeignKey(d => d.ObjavaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ObjaveUdruzenja_Objava");

                entity.HasOne(d => d.Udruzenje).WithMany(p => p.ObjaveUdruzenjas)
                    .HasForeignKey(d => d.UdruzenjeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ObjaveUdruzenja_Udruzenje");
            });

            modelBuilder.Entity<TipAdministrativneJedinice>(entity =>
            {
                entity.ToTable("TipAdministrativneJedinice");

                entity.Property(e => e.TipAdministrativneJediniceId).HasColumnName("TipAdministrativneJediniceID");
                entity.Property(e => e.Naziv).HasMaxLength(500);
            });

            modelBuilder.Entity<TipClana>(entity =>
            {
                entity.ToTable("TipClana");

                entity.Property(e => e.TipClanaId).HasColumnName("TipClanaID");
                entity.Property(e => e.Naziv).HasMaxLength(100);
            });

            modelBuilder.Entity<TipDatoteke>(entity =>
            {
                entity.ToTable("TipDatoteke");

                entity.Property(e => e.TipDatotekeId).HasColumnName("TipDatotekeID");
                entity.Property(e => e.Naziv).HasMaxLength(100);
            });

            modelBuilder.Entity<TipObjave>(entity =>
            {
                entity.ToTable("TipObjave");

                entity.Property(e => e.TipObjaveId).HasColumnName("TipObjaveID");
                entity.Property(e => e.Naziv).HasMaxLength(500);
            });

            modelBuilder.Entity<Udruzenje>(entity =>
            {
                entity.ToTable("Udruzenje");

                entity.HasIndex(e => e.AdministrativnaJedinicaId, "IX_Udruzenje_AdministrativnaJedinicaID");

                entity.HasIndex(e => e.NadredjenjoUdruzenjeId, "IX_Udruzenje_NadredjenjoUdruzenjeID");

                entity.Property(e => e.UdruzenjeId).HasColumnName("UdruzenjeID");
                entity.Property(e => e.AdministrativnaJedinicaId).HasColumnName("AdministrativnaJedinicaID");
                entity.Property(e => e.LogoPath).HasMaxLength(500);
                entity.Property(e => e.NadredjenjoUdruzenjeId).HasColumnName("NadredjenjoUdruzenjeID");

                entity.HasOne(d => d.AdministrativnaJedinica).WithMany(p => p.Udruzenjes)
                    .HasForeignKey(d => d.AdministrativnaJedinicaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Udruzenje_AdministrativnaJedinica");

                entity.HasOne(d => d.NadredjenjoUdruzenje).WithMany(p => p.InverseNadredjenjoUdruzenje)
                    .HasForeignKey(d => d.NadredjenjoUdruzenjeId)
                    .HasConstraintName("FK_Udruzenje_Udruzenje");
            });

            modelBuilder.Entity<UlogaKorisnika>(entity =>
            {
                entity.ToTable("UlogaKorisnika");

                entity.Property(e => e.UlogaKorisnikaId).HasColumnName("UlogaKorisnikaID");
                entity.Property(e => e.Naziv).HasMaxLength(50);
                entity.Property(e => e.Opis).HasMaxLength(500);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}