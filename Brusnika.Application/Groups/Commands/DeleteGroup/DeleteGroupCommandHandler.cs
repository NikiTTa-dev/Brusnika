using Brusnika.Application.Common.Interfaces.Persistence;
using Brusnika.Application.Groups.Common;
using Brusnika.Domain.GroupAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace Brusnika.Application.Groups.Commands.DeleteGroup;

public class DeleteGroupCommandHandler: IRequestHandler<DeleteGroupCommand, ErrorOr<GroupSuccessCommandResult>>
{
    private readonly IGroupRepository _groupRepository;

    public DeleteGroupCommandHandler(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }
    
    public async Task<ErrorOr<GroupSuccessCommandResult>> Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
    {
        await _groupRepository.DeleteAsync(GroupId.Create(request.Id));

        return new GroupSuccessCommandResult();
    }
}