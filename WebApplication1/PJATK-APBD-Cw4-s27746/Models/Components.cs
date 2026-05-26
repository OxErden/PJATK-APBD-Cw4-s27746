namespace WebApplication1.PJATK_APBD_Cw4_s27746.Models;

public class Components
{
    public string? Code { get; set; } 
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int ComponentManufacturersId { get; set; }
    public int ComponentTypesId { get; set; }


    public ComponentManufacturers ComponentManufacturer { get; set; } = null!;
    public ComponentTypes ComponentType { get; set; } = null!;
    public IEnumerable<PCComponents> PCcomponents { get; set; } = [];
}