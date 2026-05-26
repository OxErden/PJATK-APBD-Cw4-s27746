namespace WebApplication1.PJATK_APBD_Cw4_s27746.Models;

public class PCs
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public float weight { get; set; }
    public int warranty { get; set; }
    public DateTime created_at { get; set; }
    public int stock { get; set; }
}