using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Komentar
{
    public int KomentarId { get; set; }

    public string Sadrzaj { get; set; } = null!;

    public int KorisnikId { get; set; }

    public int ObjavaId { get; set; }

    public bool Aktivno { get; set; }

    public virtual Korisnik Korisnik { get; set; } = null!;

    public virtual Objava Objava { get; set; } = null!;
}
