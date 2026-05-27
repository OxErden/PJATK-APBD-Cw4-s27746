using Microsoft.EntityFrameworkCore;
using WebApplication1.PJATK_APBD_Cw4_s27746.DTO;
using WebApplication1.PJATK_APBD_Cw4_s27746.Infrastructure;
using WebApplication1.PJATK_APBD_Cw4_s27746.Models;

namespace WebApplication1.PJATK_APBD_Cw4_s27746.Services;

public class PcService(DataBaseContext ctx) : IPcService
{
    public async Task<IEnumerable<PcGetAllResponse>> GetAllPcAsync(CancellationToken cancellationToken)
    {
        return await ctx.PCs.Select(p => new  PcGetAllResponse
        {
            Id = p.Id,
            Name = p.Name,
            Weight = p.weight,
            Warranty = p.warranty,
            CreatedAt = p.created_at,
            Stock = p.stock
        }).ToListAsync(cancellationToken);
        
    }

    public async Task<IEnumerable<PcGetComponentsResponse>> GetComponentPcAsync(int id, CancellationToken cancellationToken)
    {
        var pc = await ctx.PCs.FindAsync(id, cancellationToken);
        if (pc == null)
            throw new KeyNotFoundException("Pc not found");

        return await ctx.PCComponents.Where(p => p.PCs.Id == id).Select(p => new PcGetComponentsResponse
        {
            ComponentCode = p.ComponentCode,
            ComponentName = p.Components.Name ?? string.Empty,
            Description = p.Components.Description,
            Amount = p.amount
        }).ToListAsync(cancellationToken);
    }

    public async Task<PcGetAllResponse> CreateAsync(PcCreateRequest request, CancellationToken cancellationToken)
    {
        var pc = new PCs
        {
            Name = request.Name,
            weight = request.Weight,
            warranty = request.Warranty,
            created_at = request.CreatedAt,
            stock = request.Stock
        };

        ctx.Add(pc);
        await ctx.SaveChangesAsync(cancellationToken);

        return new PcGetAllResponse
        {
            Id = pc.Id,
            Name = pc.Name,
            Weight = pc.weight,
            Warranty = pc.warranty,
            CreatedAt = pc.created_at,
            Stock = pc.stock
        };
    }

    public async Task UpdateAsync(int id, PcUpdateRequest request, CancellationToken cancellationToken)
    {
        var pc = await ctx.PCs.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

        if (pc == null)
        {
            throw new KeyNotFoundException("Pc not found");
        }
        pc.Name = request.Name;
        pc.weight = request.Weight;
        pc.warranty = request.Warranty;
        pc.created_at = request.CreatedAt;
        pc.stock = request.Stock;
        await ctx.SaveChangesAsync(cancellationToken);
}

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var pc = await ctx.PCs.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

        if (pc == null)
        {
            throw new KeyNotFoundException("Pc was not found");
        }
        
        ctx.PCs.Remove(pc);
        await ctx.SaveChangesAsync(cancellationToken);
    }
    
}