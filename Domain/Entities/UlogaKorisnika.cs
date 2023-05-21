using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class UlogaKorisnika
{
    public int UlogaKorisnikaId { get; set; }

    public string Naziv { get; set; } = null!;

    public string? Opis { get; set; }

    public bool? Aktivno { get; set; }
}
