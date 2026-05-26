namespace WebApplication1.PJATK_APBD_Cw4_s27746.Models;

public class ComponentManufacturers
{
  public int Id { get; set; }
  public string? Abbreviation { get; set; }
  public string? FullName { get; set; }
  public DateOnly FoundationDate { get; set; }
  
  public IEnumerable<Components> Components { get; set; } = [];
}