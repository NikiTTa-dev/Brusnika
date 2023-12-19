using Brusnika.Application.Common.Interfaces.Services;

namespace Brusnika.Infrastructure.Services;

public class DateTimeProvider: IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}