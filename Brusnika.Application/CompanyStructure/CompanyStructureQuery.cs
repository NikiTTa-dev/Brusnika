using MediatR;
using ErrorOr;

namespace Brusnika.Application.CompanyStructure;

public record CompanyStructureQuery : IRequest<ErrorOr<CompanyStructureResult>>;