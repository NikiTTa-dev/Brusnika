namespace Brusnika.Infrastructure.Persistence.Configurations.Common;

public interface IMongoDbConfiguration
{
    void Configure();
    int Order { get; }
}