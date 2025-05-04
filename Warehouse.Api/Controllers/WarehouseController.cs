using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warehouse.Domain.Entities;
using Warehouse.Infrastructure;

namespace Warehouse.Api.Controllers;

[ApiController]
[Route("warehouse")]
public class WarehouseController : ControllerBase
{
    private readonly AppDbContext _context;

    public WarehouseController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("createSector")]
    public async Task<IActionResult> CreateSector([FromBody] string name)
    {
        if (string.IsNullOrEmpty(name))
            return BadRequest("имя не должно быть пустым");
        var sector = new Sector { Name = name };

        await _context.Sectors.AddAsync(sector);
        await _context.SaveChangesAsync();
        return Ok(sector.Id);
    }

    [HttpPost("createCell")]
    public async Task<IActionResult> CreateStorageCell([FromBody] CreateCellDto dto)
    {
        if (string.IsNullOrEmpty(dto.Name)
            || string.IsNullOrEmpty(dto.SectorId)
            || dto.Width <= 0
            || dto.Height <= 0
            || dto.Depth <= 0)
            return BadRequest("не верно заполнены слова");

        var sector = await _context.Sectors.FindAsync(Guid.Parse(dto.SectorId));

        if (sector is null)
            return BadRequest($"сектора с Id {dto.SectorId} не существует");

        var cell = new StorageCell()
        {
            Name = dto.Name,
            Width = dto.Width,
            Height = dto.Height,
            Depth = dto.Depth,
        };

        sector.StorageCells.Add(cell);

        await _context.SaveChangesAsync();

        return Ok(cell.Id);
    }

    [HttpGet("Cells/{sectorId}")]
    public async Task<IActionResult> GetCellBySectorId(string sectorId, bool? isFree = null)
    {
        if (string.IsNullOrEmpty(sectorId))
            return BadRequest("поле не должно быть пустым");

        var sector = await _context.Sectors
            .AsNoTracking()
            .Include(s => s.StorageCells)
            .Where(s => isFree.HasValue ? s.StorageCells.Any(sc => sc.IsLocked == !isFree) : true)
            .FirstOrDefaultAsync(s => s.Id == Guid.Parse(sectorId));

        if (sector is null)
            return BadRequest($"sector with id: {sectorId} not found");
        var cells = new List<GetCellDto>();

        foreach (var cell in sector.StorageCells)
        {
            if (!cell.IsLocked)
                cells.Add(
                    new GetCellDto(
                        sectorId,
                        cell.Id.ToString(),
                        cell.Name,
                        cell.Width,
                        cell.Height,
                        cell.Depth));
        }

        return Ok(cells);
    }
}

public record CreateCellDto(
    string SectorId,
    string Name,
    double Width,
    double Height,
    double Depth);

public record GetCellDto(
    string SectorId,
    string CellId,
    string Name,
    double Width,
    double Height,
    double Depth);