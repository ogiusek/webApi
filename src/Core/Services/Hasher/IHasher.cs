namespace WebApi.Core.Services.Hasher;

public interface IHasher
{
    public string Hash(string password);
}