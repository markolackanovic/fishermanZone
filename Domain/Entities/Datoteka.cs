using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Datoteka
{
    public int DatotekaId { get; set; }

    public string Naziv { get; set; } = null!;

    public int TipDatotekeId { get; set; }

    public bool? Aktivno { get; set; }

    public virtual ICollection<DatotekaObjave> DatotekaObjaves { get; set; } = new List<DatotekaObjave>();

    public virtual ICollection<Dokument> Dokuments { get; set; } = new List<Dokument>();

    public virtual TipDatoteke TipDatoteke { get; set; } = null!;
}
