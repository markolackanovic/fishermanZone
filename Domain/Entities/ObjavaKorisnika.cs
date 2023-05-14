using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class ObjavaKorisnika
{
    public int ObjavaKorisnikaId { get; set; }

    public int KorisnikId { get; set; }

    public int ObjavaId { get; set; }

    public int UdruzenjeId { get; set; }

    public virtual Korisnik Korisnik { get; set; } = null!;

    public virtual Objava Objava { get; set; } = null!;

    public virtual Udruzenje Udruzenje { get; set; } = null!;
}
