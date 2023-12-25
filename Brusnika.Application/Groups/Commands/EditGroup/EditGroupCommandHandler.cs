using Brusnika.Application.Common.Interfaces.Persistence;
using Brusnika.Application.Groups.Common;
using Brusnika.Domain.GroupAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace Brusnika.Application.Groups.Commands.EditGroup;

public class EditGroupCommandHandler : IRequestHandler<EditGroupCommand, ErrorOr<GroupSuccessCommandResult>>
{
    private readonly IGroupRepository _groupRepository;

    public EditGroupCommandHandler(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }
    
    public async Task<ErrorOr<GroupSuccessCommandResult>> Handle(EditGroupCommand request, CancellationToken cancellationToken)
    {
        var group = await _groupRepository.FindOneAsync(GroupId.Create(request.Id));
        group.UpdateName(request.Name, request.CategoryName);
        await _groupRepository.UpdateOneAsync(group);
        await _groupRepository.PublishDomainEvents();

        return new GroupSuccessCommandResult();
    }
}