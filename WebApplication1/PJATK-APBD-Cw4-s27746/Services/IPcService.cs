using WebApplication1.PJATK_APBD_Cw4_s27746.DTO;

namespace WebApplication1.PJATK_APBD_Cw4_s27746.Services;

public interface IPcService
{
    Task<IEnumerable<PcGetAllResponse>> GetAllPcAsync(CancellationToken cancellationToken);
    Task<IEnumerable<PcGetComponentsResponse>> GetComponentPcAsync(int id, CancellationToken cancellationToken);
    Task<PcGetAllResponse> CreateAsync(PcCreateRequest request, CancellationToken cancellationToken);
    Task UpdateAsync(int id, PcUpdateRequest request, CancellationToken cancellationToken);
    Task DeleteAsync(int id, CancellationToken cancellationToken);
}