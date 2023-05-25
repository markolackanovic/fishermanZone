using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class DatotekaObjave
{
    public int DatotekeObjaveId { get; set; }

    public int DatotekaId { get; set; }

    public int ObjavaId { get; set; }

    public bool Aktivno { get; set; }

    public virtual Datoteka Datoteka { get; set; } = null!;

    public virtual Objava Objava { get; set; } = null!;
}
