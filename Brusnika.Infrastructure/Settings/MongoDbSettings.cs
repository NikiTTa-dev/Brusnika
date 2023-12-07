namespace Brusnika.Infrastructure.Settings;

public class MongoDbSettings
{
    public const string SectionName = "MongoDbSettings";

    public string ConnectionString { get; init; } = null!;
    public string DatabaseName { get; init; } = null!;
    public string GroupsCollectionName { get; init; } = null!;
    public string PositionsCollectionName { get; init; } = null!;
}