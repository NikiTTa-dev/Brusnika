using Brusnika.Application.Common.Interfaces.Persistence;
using Brusnika.Domain.GroupAggregate;
using Brusnika.Domain.PositionAggregate;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Brusnika.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CompanyStructureController : ControllerBase
{
    private static readonly string[] Summaries = {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly IPositionRepository _positionRepository;
    private readonly IGroupRepository _groupRepository;
    
    public CompanyStructureController(
        IPositionRepository positionRepository, 
        IGroupRepository groupRepository)
    {
        _positionRepository = positionRepository;
        _groupRepository = groupRepository;
    }
    //
    // [HttpPost("GetWeatherForecast1")]
    // public async Task<CompanyStructureResponse> Get1(CompanyStructureResponse request, CompanyStructureResponse request)
    // {
    //     await Task.CompletedTask;
    //     return new CompanyStructureResponse(new List<FilialBranch>());
    // }
    
    [HttpGet("GetWeatherForecast2")]
    public async Task<IActionResult> Get2()
    {
        var group = Group.Create("Group1");
        var group2 = Group.Create("Group2");
        var position = Position.Create("Position1");
        var position2 = Position.Create("Position2");
        await _positionRepository.InsertOneAsync(position);
        await _positionRepository.InsertOneAsync(position2);
        await _groupRepository.InsertOneAsync(group2);
        var groups = await _groupRepository.AsQueryable.ToListAsync();
        group2 = groups.Last(g => g.GroupName == "Group2");
        var positions = await _positionRepository.AsQueryable.ToListAsync();
        position = positions.Last(g => g.Name == "Position1");
        position2 = positions.Last(g => g.Name == "Position2");
        group.AddPosition(position.Id!);
        group.AddPosition(position2.Id!);
        group.AddGroup(group2.Id!);
        
        await _groupRepository.InsertOneAsync(group);
        group = await _groupRepository.AsQueryable.OrderByDescending(g => g.Id).FirstAsync(g => g.GroupName == "Group1");
        
        return Ok(group);
    }
    
    [HttpGet("GetWeatherForecast3")]
    public IEnumerable<WeatherForecast> Get3()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }
    [HttpGet("GetWeatherForecast4")]
    public IEnumerable<WeatherForecast> Get4()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
    
    [HttpGet("GetWeatherForecast5")]
    public IEnumerable<WeatherForecast> Get5()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }
    [HttpGet("GetWeatherForecast6")]
    public IEnumerable<WeatherForecast> Get6()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }
    [HttpGet("GetWeatherForecast7")]
    public IEnumerable<WeatherForecast> Get7()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }
    [HttpGet("GetWeatherForecast8")]
    public IEnumerable<WeatherForecast> Get8()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }
    [HttpGet("GetWeatherForecast9")]
    public IEnumerable<WeatherForecast> Get9()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }
    
}
