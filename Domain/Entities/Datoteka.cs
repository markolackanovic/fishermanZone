using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Datoteka
{
    public int DatotekaId { get; set; }

    public string Naziv { get; set; } = null!;

    public int TipDatotekeId { get; set; }

    public bool Aktivno { get; set; }

    public string? Guid { get; set; }

    public string? Ekstenzija { get; set; }

    public virtual ICollection<DatotekaObjave> DatotekaObjaves { get; set; } = new List<DatotekaObjave>();

    public virtual ICollection<Dokument> Dokuments { get; set; } = new List<Dokument>();
    public virtual ICollection<Udruzenje> Udruzenjes { get; set; } = new List<Udruzenje>();

    public virtual TipDatoteke TipDatoteke { get; set; } = null!;
}
