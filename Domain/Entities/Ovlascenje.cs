using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Ovlascenje
{
    public int OvlascenjeId { get; set; }

    public string Naziv { get; set; } = null!;

    public virtual ICollection<OvlascenjeUloge> OvlascenjeUloges { get; set; } = new List<OvlascenjeUloge>();
}
