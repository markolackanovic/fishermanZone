using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Udruzenje
{
    public int UdruzenjeId { get; set; }

    public int? NadredjenjoUdruzenjeId { get; set; }

    public string Naziv { get; set; } = null!;

    public int AdministrativnaJedinicaId { get; set; }

    public string? Adresa { get; set; }

    public string? Opis { get; set; }

    public string? LogoPath { get; set; }

    public virtual AdministrativnaJedinica AdministrativnaJedinica { get; set; } = null!;

    public virtual ICollection<Dokument> Dokuments { get; set; } = new List<Dokument>();

    public virtual ICollection<Udruzenje> InverseNadredjenjoUdruzenje { get; set; } = new List<Udruzenje>();

    public virtual Udruzenje? NadredjenjoUdruzenje { get; set; }

    public virtual ICollection<ObjavaKorisnika> ObjavaKorisnikas { get; set; } = new List<ObjavaKorisnika>();

    public virtual ICollection<ObjaveUdruzenja> ObjaveUdruzenjas { get; set; } = new List<ObjaveUdruzenja>();
}
