using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class ObjaveUdruzenja
{
    public int ObjaveUdruzenjaId { get; set; }

    public int ObjavaId { get; set; }

    public int UdruzenjeId { get; set; }

    public bool Aktivno { get; set; }

    public virtual Objava Objava { get; set; } = null!;

    public virtual Udruzenje Udruzenje { get; set; } = null!;
}
