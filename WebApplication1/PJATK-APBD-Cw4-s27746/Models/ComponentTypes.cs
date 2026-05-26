namespace WebApplication1.PJATK_APBD_Cw4_s27746.Models;

public class ComponentTypes
{
    public int Id { get; set; }
    public string? Abbreviation { get; set; }
    public string? Name { get; set; }
    
    public IEnumerable<Components> Components { get; set; } = [];
}