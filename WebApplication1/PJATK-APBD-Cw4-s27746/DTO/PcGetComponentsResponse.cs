namespace WebApplication1.PJATK_APBD_Cw4_s27746.DTO;

public class PcGetComponentsResponse
{
    public string ComponentCode { get; set; } = string.Empty;
    public string ComponentName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int Amount {get; set;}
}