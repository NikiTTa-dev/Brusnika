using Brusnika.Application.Common.Interfaces.Persistence;
using Brusnika.Domain.GroupAggregate;
using Brusnika.Domain.GroupAggregate.ValueObjects;
using Brusnika.Domain.PositionAggregate;
using MediatR;
using ErrorOr;

namespace Brusnika.Application.CompanyStructure;

public class CompanyStructureHandler : IRequestHandler<CompanyStructureQuery, ErrorOr<CompanyStructureResult>>
{
    private readonly IGroupRepository _groupRepository;
    private readonly IPositionRepository _positionRepository;

    public CompanyStructureHandler(IGroupRepository groupRepository, IPositionRepository positionRepository)
    {
        _groupRepository = groupRepository;
        _positionRepository = positionRepository;
    }

    public async Task<ErrorOr<CompanyStructureResult>> Handle(
        CompanyStructureQuery request,
        CancellationToken cancellationToken)
    {
        var groups = await _groupRepository.GetAllAsync();
        var positions = await _positionRepository.GetAllAsync();

        var parentGroups = groups
            .Where(g => g.ParentGroupsIds.Count == 0)
            .Select<Group, (GroupId?, Group)>(g => (null, g));
        var result = new CompanyStructureResult(new List<GroupResult>());
        var uncheckedStack = new Stack<(GroupId?, Group)>(parentGroups);
        var parentsGroupsDictionary = new Dictionary<string, GroupResult>();

        while (uncheckedStack.TryPop(out (GroupId? ParentId, Group Group) currentGroup))
        {
            if (currentGroup.ParentId is null)
            {
                var parentGroupResult = CreateGroupResult(currentGroup.Group);
                parentsGroupsDictionary.TryAdd(currentGroup.Group.Id.Value, parentGroupResult);
                result.Groups.Add(parentGroupResult);
            }

            foreach (var childGroupId in currentGroup.Group.ChildGroupsIds)
            {
                var childGroup = groups.FirstOrDefault(g => g.Id == childGroupId);
                if (childGroup == null)
                    continue;
                uncheckedStack.Push((currentGroup.Group.Id, childGroup));

                if (!parentsGroupsDictionary.TryGetValue(childGroup.Id.Value, out var res))
                    res = CreateGroupResult(childGroup);
                parentsGroupsDictionary.TryAdd(childGroup.Id.Value, res);
                parentsGroupsDictionary[currentGroup.Group.Id.Value].ChildrenGroups.Add(res);
            }

            foreach (var positionId in currentGroup.Group.PositionsIds)
            {
                var position = positions.FirstOrDefault(p => p.Id == positionId);
                if (position == null)
                    continue;
                var pos = CreatePosition(position);
                parentsGroupsDictionary[currentGroup.Group.Id.Value].Positions.Add(pos);
            }
        }

        return result;
    }

    private GroupResult CreateGroupResult(Group group) =>
        new GroupResult(
            group.Id.Value,
            group.Title,
            group.CategoryName,
            new List<PositionResult>(),
            new List<GroupResult>());

    private PositionResult CreatePosition(Position position) =>
        new PositionResult(
            position.Id.Value,
            position.Name,
            position.WorkType,
            position.Type,
            position.FirstName,
            position.LastName,
            position.Patronymic);
}