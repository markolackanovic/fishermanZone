﻿using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Udruzenje
{
    public int UdruzenjeId { get; set; }
    public int? NadredjenoUdruzenjeId { get; set; }
    public string Naziv { get; set; } = null!;
    public int AdministrativnaJedinicaId { get; set; }
    public string? Adresa { get; set; }
    public string? Opis { get; set; }

    public bool Aktivno { get; set; }

    public string? KontaktTelefon { get; set; }

    public string? KontaktEmail { get; set; }

    public int? LogoDatotekaId { get; set; } = null!;

    public virtual AdministrativnaJedinica AdministrativnaJedinica { get; set; } = null!;
    public virtual Datoteka LogoDatoteka { get; set; } = null!;

    public virtual ICollection<Dokument> Dokuments { get; set; } = new List<Dokument>();

    public virtual ICollection<Udruzenje> InverseNadredjenoUdruzenje { get; set; } = new List<Udruzenje>();

    public virtual ICollection<Korisnik> Korisniks { get; set; } = new List<Korisnik>();

    public virtual Udruzenje? NadredjenoUdruzenje { get; set; }

    public virtual ICollection<ObjavaKorisnika> ObjavaKorisnikas { get; set; } = new List<ObjavaKorisnika>();

    public virtual ICollection<ObjaveUdruzenja> ObjaveUdruzenjas { get; set; } = new List<ObjaveUdruzenja>();
}
