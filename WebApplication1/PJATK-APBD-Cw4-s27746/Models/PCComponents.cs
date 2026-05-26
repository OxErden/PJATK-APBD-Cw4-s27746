namespace WebApplication1.PJATK_APBD_Cw4_s27746.Models;

public class PCComponents
{
    public int PCId { get; set; }
    public string? ComponentCode { get; set; }
    public int amount {get; set;}

    public PCs PCs { get; set; } = null!;
    public Components Components { get; set; } = null!;
}