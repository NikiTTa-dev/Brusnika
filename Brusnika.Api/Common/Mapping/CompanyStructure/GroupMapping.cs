using Brusnika.Application.Groups.Commands.AddGroup;
using Brusnika.Application.Groups.Commands.CreateGroup;
using Brusnika.Application.Groups.Commands.DeleteGroup;
using Brusnika.Application.Groups.Commands.EditGroup;
using Brusnika.Application.Groups.Commands.RemoveGroup;
using Brusnika.Contracts.Editing.ChildrenGroup.Requests;
using Brusnika.Contracts.Editing.ChildrenGroup.Responses;
using Mapster;

namespace Brusnika.Api.Common.Mapping.CompanyStructure;

public class GroupMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateChildGroupRequest, CreateGroupCommand>();
        config.NewConfig<CreateGroupCommandResult, CreateChildGroupResponse>();

        config.NewConfig<EditChildGroupRequest, EditGroupCommand>();
        config.NewConfig<DeleteChildGroupRequest, DeleteGroupCommand>();
        config.NewConfig<AddChildGroupRequest, AddGroupCommand>();
        config.NewConfig<RemoveChildFromParentsRequest, RemoveGroupCommand>();
    }
}