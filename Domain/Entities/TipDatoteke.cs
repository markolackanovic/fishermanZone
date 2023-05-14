using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class TipDatoteke
{
    public int TipDatotekeId { get; set; }

    public string Naziv { get; set; } = null!;

    public virtual ICollection<Datoteka> Datotekas { get; } = new List<Datoteka>();
}
