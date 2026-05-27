namespace WebApplication1.PJATK_APBD_Cw4_s27746.DTO;

public class PcUpdateRequest
{
    public string Name { get; set; } = string.Empty;
    public float Weight{get; set;}
    public int Warranty {get; set;}
    public DateTime CreatedAt {get; set;}
    public int Stock {get; set;}
}