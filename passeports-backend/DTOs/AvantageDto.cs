namespace passeports_backend.DTOs;

public class AvantageDto
{
    public AvantageDto(int Id, string Contenu, int PaysVisitables)
    {
      Id = Id;
      Contenu = Contenu;
      PaysVisitables = PaysVisitables;
    }
public int Id { get; set; }
public string Contenu { get; set; }
public int PaysVisitables { get; set; }
}