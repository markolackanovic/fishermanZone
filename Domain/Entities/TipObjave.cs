using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class TipObjave
{
    public int TipObjaveId { get; set; }

    public string Naziv { get; set; } = null!;

    public virtual ICollection<Objava> Objavas { get; } = new List<Objava>();
}
