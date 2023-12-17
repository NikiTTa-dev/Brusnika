using MediatR;
using ErrorOr;

namespace Brusnika.Application.CompanyStructure;

public class CompanyStructureHandler : IRequestHandler<CompanyStructureQuery, ErrorOr<CompanyStructureResult>>
{
    public CompanyStructureHandler() {}
    
    public async Task<ErrorOr<CompanyStructureResult>> Handle(CompanyStructureQuery request, CancellationToken cancellationToken)
    {
        return new CompanyStructureResult(new List<Location>() {new Location(new Guid(), "Denver", new List<Position>(), new List<FilialBranch>())});
    }
}