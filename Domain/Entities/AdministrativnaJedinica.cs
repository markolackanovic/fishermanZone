using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class AdministrativnaJedinica
{
    public int AdministrativnaJedinicaId { get; set; }

    public string Naziv { get; set; } = null!;

    public int? TipAdministrativneJediniceId { get; set; }

    public bool? Aktivno { get; set; }

    public virtual TipAdministrativneJedinice? TipAdministrativneJedinice { get; set; }

    public virtual ICollection<Udruzenje> Udruzenjes { get; set; } = new List<Udruzenje>();
}
