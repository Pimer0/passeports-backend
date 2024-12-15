using System;
using System.Collections.Generic;

namespace passeports_backend.entities;

public partial class Passeport
{
    public int Id { get; set; }

    public string Pays { get; set; } = null!;

    public string? Description { get; set; }
    
    public string? Image { get; set; }

    public virtual ICollection<Avantage> Avantages { get; set; } = new List<Avantage>();
}
