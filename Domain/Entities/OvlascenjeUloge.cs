using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class OvlascenjeUloge
{
    public int OvlascenjeUlogeId { get; set; }

    public int UlogaId { get; set; }

    public int OvlascenjeId { get; set; }

    public virtual Ovlascenje Ovlascenje { get; set; } = null!;

    public virtual UlogaKorisnika Uloga { get; set; } = null!;
}
