using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Dokument
{
    public int DokumentId { get; set; }

    public string Naziv { get; set; } = null!;

    public int UdruzenjeId { get; set; }

    public int DatotekaId { get; set; }

    public bool? Aktivno { get; set; }

    public virtual Datoteka Datoteka { get; set; } = null!;

    public virtual Udruzenje Udruzenje { get; set; } = null!;
}
