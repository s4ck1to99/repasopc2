using System.Net.Mime;
using repaso_pc2_appsweb.Logistics.Domain.Model.Commands;
using repaso_pc2_appsweb.Logistics.Domain.Model.Repositories;
using repaso_pc2_appsweb.Logistics.Interfaces.REST.Resources;
using repaso_pc2_appsweb.Logistics.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using repaso_pc2_appsweb.Logistics.Domain.Model.Queries;
using repaso_pc2_appsweb.Logistics.Domain.Model.Services;

namespace repaso_pc2_appsweb.Logistics.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class InventoryController(IInventoryCommandService inventoryCommandService, IInventoryQueryService inventoryQueryService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateInventory(CreateInventoryResource resource)
    {
        var createInventoryCommand = CreateInventoryCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await inventoryCommandService.Handle(createInventoryCommand);
        if (result is null) return BadRequest("No se pudo crear el inventario. Verifique los datos ingresados.");
        return CreatedAtAction(nameof(GetInventoryById), new {id = result.Id});
    }

    

    [HttpGet("{id}")]
    public async Task<IActionResult> GetInventoryById(int id)
    {
        var getInventoryByIdQuery = new GetInventoryByIdQuery(id);
        var result = await inventoryQueryService.Handle(getInventoryByIdQuery);
        if (result == null) return NotFound();
        var resource = InventoryResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    private async Task<IActionResult> GetAllInventoriesByProductId(int productId)
    {
        var getAllInventoriesQuery = new GetAllInventoriesQuery();
        var result = await inventoryQueryService.Handle(getAllInventoriesQuery);
        var resources = result.Select(InventoryResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    [HttpGet]
    public async Task<IActionResult> GetInventoryFromQuery([FromQuery] string productId, [FromQuery] string warehouseId = "")
    {
        return string.IsNullOrEmpty(warehouseId)
            ? await GetAllInventoriesByProductId(productId)
            : await GetInventoryByProductIdAndWarehouseId(productId, warehouseId);
    }
}