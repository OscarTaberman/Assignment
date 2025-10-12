using Infrastructure.Interfaces;

namespace Infrastructure.Helpers;

public interface IGuidGenerator
{
    string GenerateGuid();
}

public class GuidGenerator : IGuidGenerator
{
    public string GenerateGuid()
    {
        return Guid.NewGuid().ToString();
    }
}
