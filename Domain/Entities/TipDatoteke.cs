using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class TipDatoteke
{
    public int TipDatotekeId { get; set; }

    public string Naziv { get; set; } = null!;
    public string Ekstenzija { get; set; } = null!;

    public bool Aktivno { get; set; }

    public string? Ekstenzija { get; set; }

    public virtual ICollection<Datoteka> Datotekas { get; set; } = new List<Datoteka>();
}
