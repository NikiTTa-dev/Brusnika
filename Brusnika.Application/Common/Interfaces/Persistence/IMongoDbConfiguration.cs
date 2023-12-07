namespace Brusnika.Application.Common.Interfaces.Persistence;

public interface IMongoDbConfiguration
{
    void Configure();
    int Order { get; }
}