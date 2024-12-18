using System;
using System.Collections.Generic;

namespace passeports_backend.entities;

public partial class Avantage
{
    public int Id { get; set; }

    public string Contenu { get; set; } = null!;

    public int PaysVisitables { get; set; }

    public virtual ICollection<Passeport> Passeports { get; set; }
}
