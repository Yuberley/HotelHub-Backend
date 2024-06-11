using Asp.Versioning;
using HotelHub.Application.Hotels.Commands.Create;
using HotelHub.Application.Hotels.Queries;
using HotelHub.Application.Hotels.Queries.GetAll;
using HotelHub.Application.Hotels.Queries.GetById;
using HotelHub.Domain.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelHub.WebAPI.Controllers.Hotel;

[ApiController]
[ApiVersion(ApiVersions.V1)]
[Route("api/v{version:apiVersion}/hotels")]
public class HotelController : ControllerBase
{
    private readonly ISender _sender;
    
    public HotelController(ISender sender)
    {
        _sender = sender;
    }
    
    
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var query = new GetAllHotelsQuery();
        Result<IEnumerable<HotelResponse>> result = await _sender.Send(query, cancellationToken);
        
        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }
        
        return Ok(result.Value);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddHotel(
        AddHotelRequest request,
        CancellationToken cancellationToken)
    {
        var command = new AddHotelCommand(
            request.Name,
            request.Description,
            request.Country,
            request.State,
            request.City,
            request.ZipCode,
            request.Street,
            request.IsActive);
        
        Result<Guid> result = await _sender.Send(command, cancellationToken);
        
        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }
        
        return Ok(result.Value);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetHotel(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetHotelByIdQuery(id);
        Result<HotelResponse> result = await _sender.Send(query, cancellationToken);
        
        if (result.IsFailure)
        {
            return NotFound();
        }
        
        return Ok(result.Value);
    }
}