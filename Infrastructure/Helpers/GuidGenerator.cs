using Infrastructure.Interfaces;

namespace Infrastructure.Helpers;

public class GuidGenerator : IGuidGenerator
{
    public string GenerateGuid()
    {
        return Guid.NewGuid().ToString();
    }
}
