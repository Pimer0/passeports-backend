namespace passeports_backend.DTOs;

public class PasseportDto
{
    public int Id { get; set; }
    public string Pays { get; set; }
    public string Description { get; set; }
    public List<int> AvantageIds { get; set; } = new List<int>();
}

public class PassportWithDetailsDto : PasseportDto
{
    public int Id { get; set; }
    public string Pays { get; set; }
    public string Description { get; set; }
    public List<AvantageDetailsDto> Avantages { get; set; }
}