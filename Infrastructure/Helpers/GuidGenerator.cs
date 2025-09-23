using Infrastructure.Interfaces;

namespace Infrastructure.Helpers;

public class GuidGenerator : IGuidGenerator
{
    public static string GenerateGuid()
    {
        return Guid.NewGuid().ToString();
    }
}
