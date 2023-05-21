using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class TipClana
{
    public int TipClanaId { get; set; }

    public string Naziv { get; set; } = null!;

    public bool? Aktivno { get; set; }
}
