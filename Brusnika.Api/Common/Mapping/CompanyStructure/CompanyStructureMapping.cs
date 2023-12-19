using Brusnika.Application.CompanyStructure;
using Brusnika.Contracts.CompanyStructure;
using Mapster;

namespace Brusnika.Api.Common.Mapping.CompanyStructure;

public class CompanyStructureMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CompanyStructureRequest, CompanyStructureQuery>();
        config.NewConfig<CompanyStructureResult, CompanyStructureResponse>();
    }
}