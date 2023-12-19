namespace Brusnika.Application.Common.Interfaces.Persistence;

public interface IGenericRepository<T>
{
    Task PublishDomainEvents();
}