namespace passeports_backend.DTOs;

public class AvantageDto
{
    public int Id { get; set; }
    public string Contenu { get; set; }
    public int PaysVisitables { get; set; }
    public List<int> PassportIds { get; set; } = new List<int>();
}

public class AvantageDetailsDto
{
    public int Id { get; set; }
    public string Contenu { get; set; }
    public int PaysVisitables { get; set; }
}