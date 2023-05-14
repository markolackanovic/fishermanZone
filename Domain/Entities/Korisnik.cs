using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Korisnik
{
    public int KorisnikId { get; set; }

    public string Ime { get; set; } = null!;

    public string Prezime { get; set; } = null!;

    public string? Jmbg { get; set; }

    public string KorisnickoIme { get; set; } = null!;

    public string Lozinka { get; set; } = null!;

    public string? Adresa { get; set; }

    public int? UdruzenjeId { get; set; }

    public int? UlogaKorisnikaId { get; set; }

    public string? ProfilnaSlika { get; set; }

    public bool Aktivan { get; set; }

    public virtual ICollection<Komentar> Komentars { get; } = new List<Komentar>();

    public virtual ICollection<ObjavaKorisnika> ObjavaKorisnikas { get; } = new List<ObjavaKorisnika>();
}
