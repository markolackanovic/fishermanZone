using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Objava
{
    public int ObjavaId { get; set; }

    public string? Naslov { get; set; }

    public string Sadrzaj { get; set; } = null!;

    public DateTime? DatumObjave { get; set; }

    public string LokacijaLat { get; set; } = null!;

    public string LokacijaLong { get; set; } = null!;

    public int TipObjaveId { get; set; }

    public virtual ICollection<DatotekaObjave> DatotekaObjaves { get; } = new List<DatotekaObjave>();

    public virtual ICollection<Komentar> Komentars { get; } = new List<Komentar>();

    public virtual ICollection<ObjavaKorisnika> ObjavaKorisnikas { get; } = new List<ObjavaKorisnika>();

    public virtual ICollection<ObjaveUdruzenja> ObjaveUdruzenjas { get; } = new List<ObjaveUdruzenja>();

    public virtual TipObjave TipObjave { get; set; } = null!;
}
