using System;
using System.Collections.Generic;
using passeports_backend.DTOs;

namespace passeports_backend.entities;

public partial class Passeport
{
    public int Id { get; set; }

    public string Pays { get; set; } = null!;

    public string? Description { get; set; }
    
    public byte? Image { get; set; }

    public virtual ICollection<AvantageDto> Avantages { get; set; } = new List<AvantageDto>();
}
