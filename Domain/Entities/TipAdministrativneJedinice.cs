using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class TipAdministrativneJedinice
{
    public int TipAdministrativneJediniceId { get; set; }

    public string Naziv { get; set; } = null!;

    public bool Aktivno { get; set; }

    public virtual ICollection<AdministrativnaJedinica> AdministrativnaJedinicas { get; set; } = new List<AdministrativnaJedinica>();
}
