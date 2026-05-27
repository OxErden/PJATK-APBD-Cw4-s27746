using Microsoft.AspNetCore.Mvc;
using WebApplication1.PJATK_APBD_Cw4_s27746.DTO;
using WebApplication1.PJATK_APBD_Cw4_s27746.Services;

namespace WebApplication1.PJATK_APBD_Cw4_s27746.Controllers;


[ApiController]
[Route("api/[controller]")]
public class PcController(IPcService service) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetAllPcs(CancellationToken cancellationToken)
    {
        return Ok(await service.GetAllPcAsync(cancellationToken));
    }


    [HttpGet("{id:int}/components")]
    public async Task<IActionResult> GetPcComponentsAsync([FromRoute]int id, CancellationToken cancellationToken)
    {
        try
        {
            var result = await service.GetComponentPcAsync(id, cancellationToken);
            return Ok(result);
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }


    [HttpPost]
    public async Task<IActionResult> CreatePcAsync([FromBody] PcCreateRequest request,
        CancellationToken cancellationToken)
    {
        var pc = await service.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetAllPcs), new { id = pc.Id }, pc);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] PcUpdateRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            await service.UpdateAsync(id, request, cancellationToken);
            return NoContent();
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id, CancellationToken cancellationToken)
    {
        try
        {
            await service.DeleteAsync(id,cancellationToken);
            return NoContent();
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
    
    
    
}