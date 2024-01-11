using Brusnika.Api.Controllers.Common;
using Brusnika.Application.Common.Interfaces.Persistence;
using Brusnika.Application.CompanyStructure;
using Brusnika.Contracts.CompanyStructure;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Position = Brusnika.Domain.PositionAggregate.Position;
using Group = Brusnika.Domain.GroupAggregate.Group;

namespace Brusnika.Api.Controllers;

[Route("[controller]")]
public class CompanyStructureController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;
    private readonly IPositionRepository _positionRepository;
    private readonly IGroupRepository _groupRepository;

    public CompanyStructureController(
        IPositionRepository positionRepository,
        IGroupRepository groupRepository,
        IMapper mapper,
        ISender mediator)
    {
        _positionRepository = positionRepository;
        _groupRepository = groupRepository;
        _mapper = mapper;
        _mediator = mediator;
    }


    [HttpGet("Mock")]
    public async Task<IActionResult> Mock()
    {
        var random = new Random();
        var Names = new[] {"Никита", "Георгий", "Юрий", "Степан", "Антон", "Вячеслав", "Андрей"};
        var SurNames = new[] {"Бабин", "Занков", "Роналдо", "Петров", "Лукоянов", "Шустик", "Килин"};
        var Patronymics = new[]
        {
            "Константинович", "Александрович", "Степанович", "Викторович", "Вячеславович", "Дмитриевич", "Григорьевич"
        };
        var PositionNames = new[]
        {
            "Руководитель направления", "Ведущий бухгалтер", "Руководитель бухгалтерии", "Специалист",
            "Главный специалист", "Ведущий юрисконсульт", "Ведущий инженер-исследователь", "Ведущий архитектор", "Руководитель отдела" 
        };
        var DepartmentNames = new[]
        {
            "Подразделение \"Артемида\"",
            "Подразделение \"Афина\"",
            "Подразделение \"Афродита\"",
            "Подразделение \"Ахилл\"",
            "Подразделение \"Гера\"",
            "Подразделение \"Геракл\"",
            "Подразделение \"Гермес\"",
            "Подразделение \"Гефест\"",
            "Подразделение \"Зевс\"",
            "Подразделение \"Посейдон\"",
            "Подразделение \"Аполлон\"",
            "Подразделение \"Гестия\""
        };
        var DivisionNames = new[]
        {
            "Отдел \"Армения\"",
            "Отдел \"Дания\"",
            "Отдел \"Литва\"",
            "Отдел \"Норвегия\"",
            "Отдел \"Сербия\"",
            "Отдел \"Словения\"",
            "Отдел \"Хорватия\"",
            "Отдел \"Швейцария\"",
            "Отдел \"Болгария\"",
            "Отдел \"Римская империя\"",
            "Отдел \"Казахстан\"",
            "Отдел \"Украина\""
        };
        var SubdivisionNames = new[]
        {
            "Группа \"Амстердам\"",
            "Группа \"Каспийск\"",
            "Группа \"Нюрнберг\"",
            "Группа \"Балашиха\"",
            "Группа \"Милан\"",
            "Группа \"Ростов-на-Дону\"",
            "Группа \"Нижний Новгород\"",
            "Группа \"Самара\"",
            "Группа \"Краснодар\"",
        };
        
        var locations = new List<Group>();
        
        var group = Group.Create("БС3", "ЮЛ");
        locations.Add(Group.Create("Брусника.Екатеринбург", "Локация"));
        locations.Add(Group.Create("Брусника.Курган", "Локация"));
        locations.Add(Group.Create("Брусника.Московская область", "Локация"));
        locations.Add(Group.Create("Брусника.Новосибирск", "Локация"));
        locations.Add(Group.Create("Брусника.Омск", "Локация"));
        locations.Add(Group.Create("Брусника.Сургут", "Локация"));
        locations.Add(Group.Create("Брусника.Тюмень", "Локация"));

        foreach (var location in locations)
        {
            group.AddChildGroup(location.Id);
        }
        
        foreach (var location in locations)
        {
            for (var i = 0; i < random.Next(7) + 1; i++)
            {
                var department = Group.Create(DepartmentNames[random.Next(DepartmentNames.Length)], "Подразделение");
                location.AddChildGroup(department.Id);
                for (var i1 = 0; i1 < random.Next(7) + 1; i1++)
                {
                    var division = Group.Create(DivisionNames[random.Next(DivisionNames.Length)], "Отдел");
                    department.AddChildGroup(division.Id);
                    for (var i2 = 0; i2 < random.Next(7) + 1; i2++)
                    {
                        var subDivision = Group.Create(SubdivisionNames[random.Next(SubdivisionNames.Length)], "Группа");
                        division.AddChildGroup(subDivision.Id);
                        for (var i3 = 0; i3 < random.Next(7) + 1; i3++)
                        {
                            var position = Position.Create(PositionNames[random.Next(PositionNames.Length)],
                                "Сотрудник", "Бизнес", Names[random.Next(Names.Length)],
                                SurNames[random.Next(SurNames.Length)], Patronymics[random.Next(Patronymics.Length)]);
                            division.AddPosition(position.Id);
                            await _positionRepository.InsertOneAsync(position);
                        }
                        for (var i3 = 0; i3 < random.Next(3) + 1; i3++)
                        {
                            var position = Position.Create(PositionNames[random.Next(PositionNames.Length)], 
                                "Вакансия", "Бизнес", null, null, null);
                            division.AddPosition(position.Id);
                            await _positionRepository.InsertOneAsync(position);
                        }
                        
                        await _groupRepository.InsertOneAsync(subDivision);
                    }
                    await _groupRepository.InsertOneAsync(division);
                }
                await _groupRepository.InsertOneAsync(department);

            }
        }

        await _groupRepository.InsertOneAsync(group);
        foreach (var location in locations)
        {
            await _groupRepository.InsertOneAsync(location);
        }
        // group.AddPosition(position.Id);
        // group.AddChildGroup(group2.Id);
        // group2.AddPosition(position2.Id);
        // group2.AddChildGroup(group3.Id);
        // group2.AddChildGroup(group4.Id);

        await _groupRepository.UpdateOneAsync(group);
        
        foreach (var location in locations)
        {
            await _groupRepository.UpdateOneAsync(location);
        }
        await _groupRepository.PublishDomainEvents();
        await _positionRepository.PublishDomainEvents();

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> CompanyStructure()
    {
        var createResult = await _mediator.Send(new CompanyStructureQuery());

        return createResult.Match(
            result => Ok(_mapper.Map<CompanyStructureResponse>(result)),
            errors => Problem(errors));
    }
}